/* Скрипт 6. Тригери (ПР6)
   Запускати після 01, 02, 03: тригери ставляться на вже заповнену базу,
   інакше генератор даних списав би баланс двічі.

   Тригер можна створити й вручну, як у методичці:
   PCClub → Tables → dbo.Session → Triggers (Тригери) → ПКМ → New Trigger (Створити тригер)
   → замінити шаблон текстом тригера з цього файлу → Execute (F5).

   Коди помилок тригерів: 50020-50029. Програма показує їхній текст як є. */

USE PCClub;
GO
SET QUOTED_IDENTIFIER ON;
GO

-- ---------- Зміни схеми ----------

-- Клієнта з історією сесій чи поповнень видалити не можна: інакше зникли б гроші у звітах
ALTER TABLE Session DROP CONSTRAINT FK_Session_Client;
ALTER TABLE Session ADD CONSTRAINT FK_Session_Client FOREIGN KEY (client_id) REFERENCES Client (client_id)
    ON UPDATE NO ACTION ON DELETE NO ACTION;
ALTER TABLE Deposit DROP CONSTRAINT FK_Deposit_Client;
ALTER TABLE Deposit ADD CONSTRAINT FK_Deposit_Client FOREIGN KEY (client_id) REFERENCES Client (client_id)
    ON UPDATE NO ACTION ON DELETE NO ACTION;
GO

-- Індекси для перевірки перетину сесій у trg_Session_Validate
CREATE INDEX IX_Session_Computer ON Session (computer_id, started_at);
CREATE INDEX IX_Session_Client   ON Session (client_id, started_at);
GO

/* Журнал змін. changed_by: програма передає логін користувача в Application Name
   підключення («PC_Club:admin»), для змін з SSMS записується обліковий запис Windows. */
CREATE TABLE ChangeLog (
    log_id     INT IDENTITY PRIMARY KEY,
    changed_at DATETIME      NOT NULL CONSTRAINT DF_ChangeLog_at DEFAULT GETDATE(),
    changed_by NVARCHAR(128) NOT NULL CONSTRAINT DF_ChangeLog_by DEFAULT
        (CASE WHEN APP_NAME() LIKE N'PC[_]Club:%' THEN SUBSTRING(APP_NAME(), 9, 128) ELSE SUSER_SNAME() END),
    table_name NVARCHAR(30)  NOT NULL,
    action     NVARCHAR(10)  NOT NULL,
    record_id  INT           NOT NULL,
    old_values NVARCHAR(MAX) NULL,
    new_values NVARCHAR(MAX) NULL
);
GO

-- ---------- 1. Баланс клієнта ----------
-- Правило: баланс = сума поповнень - сума оплачених сесій. Його ведуть два тригери нижче.

-- Поповнення: баланс += нова сума - стара сума (працює і для зміни, і для видалення)
CREATE OR ALTER TRIGGER trg_Deposit_Balance ON Deposit
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @delta TABLE (client_id INT PRIMARY KEY, amount DECIMAL(10,2));
    INSERT INTO @delta
    SELECT client_id, SUM(amount)
    FROM (SELECT client_id, amount FROM inserted
          UNION ALL
          SELECT client_id, -amount FROM deleted) t
    GROUP BY client_id
    HAVING SUM(amount) <> 0;

    IF EXISTS (SELECT 1 FROM Client c JOIN @delta d ON d.client_id = c.client_id
               WHERE c.balance + d.amount < 0)
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50020, N'Не можна зменшити чи видалити поповнення: ці гроші клієнт уже витратив на сесії.', 1;
    END;

    UPDATE c SET balance = c.balance + d.amount
    FROM Client c
    JOIN @delta d ON d.client_id = c.client_id;
END;
GO

-- Сесії: баланс -= нова сума + стара сума (видалення сесії повертає гроші)
CREATE OR ALTER TRIGGER trg_Session_Charge ON Session
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @delta TABLE (client_id INT PRIMARY KEY, amount DECIMAL(10,2));
    INSERT INTO @delta
    SELECT client_id, SUM(amount)
    FROM (SELECT client_id, ISNULL(total_price, 0) AS amount FROM inserted
          UNION ALL
          SELECT client_id, -ISNULL(total_price, 0) FROM deleted) t
    GROUP BY client_id
    HAVING SUM(amount) <> 0;

    IF EXISTS (SELECT 1 FROM Client c JOIN @delta d ON d.client_id = c.client_id
               WHERE c.balance - d.amount < 0)
    BEGIN
        DECLARE @msg NVARCHAR(400);
        SELECT TOP 1 @msg = N'Недостатньо коштів на рахунку клієнта ' + c.last_name + N' ' + c.first_name
                          + N': потрібно ' + CAST(d.amount AS NVARCHAR(20))
                          + N' грн, на рахунку ' + CAST(c.balance AS NVARCHAR(20)) + N' грн.'
        FROM Client c JOIN @delta d ON d.client_id = c.client_id
        WHERE c.balance - d.amount < 0;

        ROLLBACK TRANSACTION;
        THROW 50021, @msg, 1;
    END;

    UPDATE c SET balance = c.balance - d.amount
    FROM Client c
    JOIN @delta d ON d.client_id = c.client_id;
END;
GO

/* Баланс вручну не змінюється. Якщо змінити його напряму (у таблиці «Клієнти» чи UPDATE у SSMS),
   тригер поверне попереднє значення. Зміни з тригерів поповнень і сесій мають рівень вкладеності 2
   і проходять. Новий клієнт завжди починає з нульового балансу. */
CREATE OR ALTER TRIGGER trg_Client_Balance ON Client
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF TRIGGER_NESTLEVEL() > 1 OR NOT UPDATE(balance) RETURN;

    UPDATE c SET balance = ISNULL(d.balance, 0)
    FROM Client c
    JOIN inserted i      ON i.client_id = c.client_id
    LEFT JOIN deleted d  ON d.client_id = c.client_id
    WHERE c.balance <> ISNULL(d.balance, 0);
END;
GO

-- ---------- 2. Перевірка сесії ----------
CREATE OR ALTER TRIGGER trg_Session_Validate ON Session
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @msg NVARCHAR(400);

    -- Закрити сесію можна лише разом із сумою, а суму має лише закрита сесія
    IF EXISTS (SELECT 1 FROM inserted
               WHERE (ended_at IS NULL AND total_price IS NOT NULL)
                  OR (ended_at IS NOT NULL AND total_price IS NULL))
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50022, N'Сесію треба завершувати разом із сумою оплати. Скористайтеся операцією «Завершити сесію».', 1;
    END;

    -- Новий ПК для відкритої сесії має бути справним
    SELECT TOP 1 @msg = N'Комп''ютер ' + h.name + N' #' + CAST(c.number AS NVARCHAR(10)) + N' несправний.'
    FROM inserted i
    LEFT JOIN deleted d ON d.session_id = i.session_id
    JOIN Computer c     ON c.computer_id = i.computer_id
    JOIN Hall h         ON h.hall_id = c.hall_id
    WHERE i.ended_at IS NULL
      AND c.status = N'Несправний'
      AND (d.session_id IS NULL OR d.computer_id <> i.computer_id);
    IF @msg IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50023, @msg, 1;
    END;

    -- На одному ПК не можуть одночасно йти дві сесії (відкрита сесія триває «до нескінченності»)
    SELECT TOP 1 @msg = N'Комп''ютер ' + h.name + N' #' + CAST(c.number AS NVARCHAR(10))
                      + N' у цей час зайнятий (сесія № ' + CAST(s.session_id AS NVARCHAR(10)) + N').'
    FROM inserted i
    JOIN Session s  ON s.computer_id = i.computer_id AND s.session_id <> i.session_id
    JOIN Computer c ON c.computer_id = i.computer_id
    JOIN Hall h     ON h.hall_id = c.hall_id
    WHERE s.started_at < ISNULL(i.ended_at, '99991231')
      AND ISNULL(s.ended_at, '99991231') > i.started_at;
    IF @msg IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50024, @msg, 1;
    END;

    -- Клієнт не може одночасно грати за двома ПК
    SELECT TOP 1 @msg = N'Клієнт ' + cl.last_name + N' ' + cl.first_name
                      + N' у цей час уже грає (сесія № ' + CAST(s.session_id AS NVARCHAR(10)) + N').'
    FROM inserted i
    JOIN Session s ON s.client_id = i.client_id AND s.session_id <> i.session_id
    JOIN Client cl ON cl.client_id = i.client_id
    WHERE s.started_at < ISNULL(i.ended_at, '99991231')
      AND ISNULL(s.ended_at, '99991231') > i.started_at;
    IF @msg IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50025, @msg, 1;
    END;

    -- Гра має бути встановлена на цьому ПК і дозволена клієнту за віком на день сесії
    SELECT TOP 1 @msg = N'Гра «' + g.title + N'» не встановлена на вибраному комп''ютері.'
    FROM inserted i
    LEFT JOIN deleted d ON d.session_id = i.session_id
    JOIN Game g         ON g.game_id = i.game_id
    WHERE (d.session_id IS NULL OR d.computer_id <> i.computer_id OR ISNULL(d.game_id, 0) <> i.game_id)
      AND NOT EXISTS (SELECT 1 FROM ComputerGame cg
                      WHERE cg.computer_id = i.computer_id AND cg.game_id = i.game_id);
    IF @msg IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50026, @msg, 1;
    END;

    SELECT TOP 1 @msg = N'Гра «' + g.title + N'» має вікове обмеження ' + CAST(g.age_limit AS NVARCHAR(10))
                      + N'+, а клієнту ' + CAST(x.age AS NVARCHAR(10)) + N'.'
    FROM inserted i
    LEFT JOIN deleted d ON d.session_id = i.session_id
    JOIN Game g         ON g.game_id = i.game_id
    JOIN Client cl      ON cl.client_id = i.client_id
    CROSS APPLY (SELECT DATEDIFF(YEAR, cl.birth_date, i.started_at)
                        - CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, cl.birth_date, i.started_at), cl.birth_date) > i.started_at
                               THEN 1 ELSE 0 END AS age) x
    WHERE cl.birth_date IS NOT NULL
      AND x.age < g.age_limit
      AND (d.session_id IS NULL OR d.client_id <> i.client_id OR ISNULL(d.game_id, 0) <> i.game_id);
    IF @msg IS NOT NULL
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 50027, @msg, 1;
    END;
END;
GO

-- ---------- 3. Обліковий запис клієнта ----------

-- Логін клієнта = номер телефону: змінився телефон - змінюється й логін
CREATE OR ALTER TRIGGER trg_Client_PhoneLogin ON Client
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT UPDATE(phone) RETURN;

    UPDATE ua SET login = i.phone
    FROM UserAccount ua
    JOIN inserted i ON i.user_id = ua.user_id
    JOIN deleted d  ON d.client_id = i.client_id
    WHERE i.phone IS NOT NULL
      AND ISNULL(d.phone, N'') <> i.phone;
END;
GO

-- Видалили клієнта - видаляється і його обліковий запис
CREATE OR ALTER TRIGGER trg_Client_Delete ON Client
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DELETE ua
    FROM UserAccount ua
    JOIN deleted d ON d.user_id = ua.user_id;
END;
GO

-- ---------- 4. Журнал змін (аудит) ----------
-- Старі й нові значення рядка пишуться у форматі JSON. Нові значення читаються з таблиці,
-- тож у журнал потрапляє те, що реально збережено (наприклад, після trg_Client_Balance).

CREATE OR ALTER TRIGGER trg_Audit_Client ON Client
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChangeLog (table_name, action, record_id, old_values, new_values)
    SELECT N'Client',
           CASE WHEN d.client_id IS NULL THEN N'INSERT' WHEN i.client_id IS NULL THEN N'DELETE' ELSE N'UPDATE' END,
           ISNULL(i.client_id, d.client_id),
           (SELECT * FROM deleted x WHERE x.client_id = d.client_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
           (SELECT * FROM Client x WHERE x.client_id = i.client_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL JOIN deleted d ON d.client_id = i.client_id;
END;
GO

CREATE OR ALTER TRIGGER trg_Audit_Deposit ON Deposit
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChangeLog (table_name, action, record_id, old_values, new_values)
    SELECT N'Deposit',
           CASE WHEN d.deposit_id IS NULL THEN N'INSERT' WHEN i.deposit_id IS NULL THEN N'DELETE' ELSE N'UPDATE' END,
           ISNULL(i.deposit_id, d.deposit_id),
           (SELECT * FROM deleted x WHERE x.deposit_id = d.deposit_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
           (SELECT * FROM Deposit x WHERE x.deposit_id = i.deposit_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL JOIN deleted d ON d.deposit_id = i.deposit_id;
END;
GO

CREATE OR ALTER TRIGGER trg_Audit_Hall ON Hall
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChangeLog (table_name, action, record_id, old_values, new_values)
    SELECT N'Hall',
           CASE WHEN d.hall_id IS NULL THEN N'INSERT' WHEN i.hall_id IS NULL THEN N'DELETE' ELSE N'UPDATE' END,
           ISNULL(i.hall_id, d.hall_id),
           (SELECT * FROM deleted x WHERE x.hall_id = d.hall_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
           (SELECT * FROM Hall x WHERE x.hall_id = i.hall_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL JOIN deleted d ON d.hall_id = i.hall_id;
END;
GO

CREATE OR ALTER TRIGGER trg_Audit_Tariff ON Tariff
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO ChangeLog (table_name, action, record_id, old_values, new_values)
    SELECT N'Tariff',
           CASE WHEN d.tariff_id IS NULL THEN N'INSERT' WHEN i.tariff_id IS NULL THEN N'DELETE' ELSE N'UPDATE' END,
           ISNULL(i.tariff_id, d.tariff_id),
           (SELECT * FROM deleted x WHERE x.tariff_id = d.tariff_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
           (SELECT * FROM Tariff x WHERE x.tariff_id = i.tariff_id FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
    FROM inserted i
    FULL JOIN deleted d ON d.tariff_id = i.tariff_id;
END;
GO

-- Спершу повертається баланс, потім пишеться журнал, щоб у нього потрапило збережене значення
EXEC sp_settriggerorder @triggername = N'trg_Client_Balance', @order = N'First', @stmttype = N'UPDATE';
EXEC sp_settriggerorder @triggername = N'trg_Client_Balance', @order = N'First', @stmttype = N'INSERT';
GO

-- Журнал з назвами українською
CREATE OR ALTER VIEW dbo.v_ChangeLog
AS
SELECT l.log_id,
       l.changed_at,
       l.changed_by,
       l.table_name,
       CASE l.table_name WHEN N'Client'  THEN N'Клієнти'
                         WHEN N'Deposit' THEN N'Поповнення'
                         WHEN N'Hall'    THEN N'Зали'
                         WHEN N'Tariff'  THEN N'Тарифи'
                         ELSE l.table_name END                  AS table_caption,
       l.action,
       CASE l.action WHEN N'INSERT' THEN N'Додано'
                     WHEN N'UPDATE' THEN N'Змінено'
                     ELSE N'Видалено' END                       AS action_caption,
       l.record_id,
       CASE l.table_name
           WHEN N'Client'  THEN ISNULL(JSON_VALUE(l.new_values, '$.last_name'), JSON_VALUE(l.old_values, '$.last_name'))
                                + N' ' + ISNULL(JSON_VALUE(l.new_values, '$.first_name'), JSON_VALUE(l.old_values, '$.first_name'))
           WHEN N'Hall'    THEN ISNULL(JSON_VALUE(l.new_values, '$.name'), JSON_VALUE(l.old_values, '$.name'))
           WHEN N'Tariff'  THEN ISNULL(JSON_VALUE(l.new_values, '$.name'), JSON_VALUE(l.old_values, '$.name'))
           WHEN N'Deposit' THEN ISNULL(JSON_VALUE(l.new_values, '$.amount'), JSON_VALUE(l.old_values, '$.amount')) + N' грн'
       END                                                      AS record_name,
       l.old_values,
       l.new_values
FROM ChangeLog l;
GO

-- ---------- Перевірка ----------
SELECT t.name AS [Тригер], OBJECT_NAME(t.parent_id) AS [Таблиця]
FROM sys.triggers t
ORDER BY [Таблиця], [Тригер];
