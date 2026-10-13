/* Скрипт 7. Функції, збережені процедури й транзакції (ПР7)
   Запускати після 06_triggers.sql: процедури розраховують на те, що баланс ведуть тригери.

   Створити вручну, як у методичці:
   PCClub → Programmability (Програмування) → Stored Procedures (Збережені процедури) → ПКМ → New
   або Functions (Функції) → Scalar-valued / Table-valued → ПКМ → New → замінити шаблон текстом з цього файлу.

   Коди помилок процедур: 50010 (реєстрація), 50030-50039. */

USE PCClub;
GO
SET QUOTED_IDENTIFIER ON;
GO

-- ==================== Скалярні функції ====================

/* Вартість сесії - єдине правило для всієї програми:
   погодинний тариф - за фактичні хвилини;
   пакет («5 годин», «Нічний») - ціна пакета, навіть якщо клієнт пішов раніше,
   а понад пакет - ті самі хвилини за ціною пакета (зі знижкою). */
CREATE OR ALTER FUNCTION dbo.fn_SessionPrice
(
    @computer_id INT,
    @tariff_id   INT,
    @started_at  DATETIME,
    @ended_at    DATETIME
)
RETURNS DECIMAL(8,2)
AS
BEGIN
    DECLARE @minutes INT = DATEDIFF(MINUTE, @started_at, @ended_at);
    DECLARE @price DECIMAL(8,2);

    SELECT @price = ROUND(h.price_per_hour
                          * CASE WHEN t.hours > 1 AND @minutes < t.hours * 60 THEN t.hours * 60 ELSE @minutes END
                          / 60.0 * (100 - t.discount_percent) / 100.0, 2)
    FROM Computer c
    JOIN Hall h   ON h.hall_id = c.hall_id
    JOIN Tariff t ON t.tariff_id = @tariff_id
    WHERE c.computer_id = @computer_id;

    RETURN @price;
END;
GO

-- Повних років на дату @on
CREATE OR ALTER FUNCTION dbo.fn_Age (@birth_date DATE, @on DATE)
RETURNS INT
AS
BEGIN
    IF @birth_date IS NULL RETURN NULL;
    RETURN DATEDIFF(YEAR, @birth_date, @on)
           - CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, @birth_date, @on), @birth_date) > @on THEN 1 ELSE 0 END;
END;
GO

-- «Прізвище Ім'я»
CREATE OR ALTER FUNCTION dbo.fn_FullName (@last_name NVARCHAR(50), @first_name NVARCHAR(50))
RETURNS NVARCHAR(101)
AS
BEGIN
    RETURN LTRIM(RTRIM(ISNULL(@last_name, N'') + N' ' + ISNULL(@first_name, N'')));
END;
GO

-- ==================== Табличні функції ====================

-- Рух коштів клієнта із залишком після кожної операції
CREATE OR ALTER FUNCTION dbo.fn_ClientStatement (@client_id INT)
RETURNS TABLE
AS
RETURN
SELECT op_date,
       operation,
       details,
       amount,
       SUM(amount) OVER (ORDER BY op_date, sort_order, op_id ROWS UNBOUNDED PRECEDING) AS balance_after
FROM (SELECT d.paid_at     AS op_date,
             0             AS sort_order,
             d.deposit_id  AS op_id,
             N'Поповнення' AS operation,
             d.method      AS details,
             d.amount      AS amount
      FROM Deposit d
      WHERE d.client_id = @client_id
      UNION ALL
      SELECT s.ended_at,
             1,
             s.session_id,
             N'Оплата сесії',
             h.name + N' #' + CAST(c.number AS NVARCHAR(10)) + ISNULL(N', ' + g.title, N''),
             -s.total_price
      FROM Session s
      JOIN Computer c  ON c.computer_id = s.computer_id
      JOIN Hall h      ON h.hall_id = c.hall_id
      LEFT JOIN Game g ON g.game_id = s.game_id
      WHERE s.client_id = @client_id
        AND s.ended_at IS NOT NULL) ops;
GO

/* Завантаженість клубу: зайняті й доступні ПК-години по залах, днях тижня і годинах.
   Дані для звіту «Завантаженість клубу». Сесія розкладається на годинні слоти (до 12 годин). */
CREATE OR ALTER FUNCTION dbo.fn_ClubLoad (@from DATE, @to DATE)
RETURNS TABLE
AS
RETURN
WITH days AS (
    SELECT TOP (DATEDIFF(DAY, @from, @to) + 1)
           DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1, @from) AS d
    FROM sys.all_objects
),
hours AS (
    SELECT TOP 24 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS h
    FROM sys.all_objects
),
halls AS (
    SELECT hl.name AS hall, COUNT(c.computer_id) AS pcs
    FROM Hall hl
    LEFT JOIN Computer c ON c.hall_id = hl.hall_id
    GROUP BY hl.name
),
capacity AS (
    SELECT hs.hall,
           DATEDIFF(DAY, 0, dd.d) % 7 AS dow,
           hr.h AS hr,
           COUNT(*) * MAX(hs.pcs) AS pcs_hours
    FROM halls hs
    CROSS JOIN days dd
    CROSS JOIN hours hr
    WHERE DATEADD(HOUR, hr.h, CAST(dd.d AS DATETIME)) < GETDATE()
    GROUP BY hs.hall, DATEDIFF(DAY, 0, dd.d) % 7, hr.h
),
steps AS (
    SELECT TOP 12 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS k
    FROM sys.all_objects
),
parts AS (
    SELECT h.name AS hall,
           x.slot,
           s.started_at,
           ISNULL(s.ended_at, GETDATE()) AS finished
    FROM Session s
    JOIN Computer c ON c.computer_id = s.computer_id
    JOIN Hall h     ON h.hall_id = c.hall_id
    CROSS JOIN steps st
    CROSS APPLY (SELECT DATEADD(HOUR, st.k, DATEADD(HOUR, DATEDIFF(HOUR, 0, s.started_at), 0)) AS slot) x
    WHERE s.started_at < DATEADD(DAY, 1, @to)
      AND ISNULL(s.ended_at, GETDATE()) > @from
      AND x.slot < ISNULL(s.ended_at, GETDATE())
      AND x.slot >= @from
      AND x.slot < DATEADD(DAY, 1, @to)
      AND x.slot < GETDATE()
),
busy AS (
    SELECT hall,
           DATEDIFF(DAY, 0, slot) % 7 AS dow,
           DATEPART(HOUR, slot)       AS hr,
           SUM(DATEDIFF(MINUTE,
                        CASE WHEN started_at > slot THEN started_at ELSE slot END,
                        CASE WHEN finished < DATEADD(HOUR, 1, slot) THEN finished ELSE DATEADD(HOUR, 1, slot) END)) / 60.0 AS hours
    FROM parts
    GROUP BY hall, DATEDIFF(DAY, 0, slot) % 7, DATEPART(HOUR, slot)
)
SELECT cp.hall AS Hall,
       cp.dow  AS DayOfWeek,
       CHOOSE(cp.dow + 1, N'Пн', N'Вт', N'Ср', N'Чт', N'Пт', N'Сб', N'Нд') AS DayName,
       CAST(cp.hr AS INT) AS Hour,
       CAST(ISNULL(b.hours, 0) AS DECIMAL(12,2)) AS BusyHours,
       CAST(cp.pcs_hours AS DECIMAL(12,2))       AS CapacityHours
FROM capacity cp
LEFT JOIN busy b ON b.hall = cp.hall AND b.dow = cp.dow AND b.hr = cp.hr;
GO

-- Скільки набіжало у відкритих сесіях тепер рахує fn_SessionPrice (пакет - одразу повна ціна)
CREATE OR ALTER VIEW dbo.v_ActiveSessions
AS
SELECT
    d.session_id,
    d.client_id,
    d.client,
    d.phone,
    d.computer_id,
    d.computer,
    d.hall,
    d.game,
    d.tariff,
    d.employee_id,
    d.employee,
    d.started_at,
    d.minutes,
    dbo.fn_SessionPrice(d.computer_id, d.tariff_id, d.started_at, GETDATE()) AS current_price,
    c.balance
FROM dbo.v_SessionDetails d
JOIN Client c ON c.client_id = d.client_id
WHERE d.ended_at IS NULL;
GO

-- ==================== Процедури ====================

-- Вибірка сесій з необов'язковими параметрами: NULL означає «без обмеження»
CREATE OR ALTER PROCEDURE dbo.sp_GetSessions
    @client_id INT  = NULL,
    @from      DATE = NULL,
    @to        DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT started_at  AS [Початок],
           ended_at    AS [Завершення],
           client      AS [Клієнт],
           computer    AS [Комп'ютер],
           tariff      AS [Тариф],
           game        AS [Гра],
           hours       AS [Годин],
           total_price AS [Сума (грн)]
    FROM v_SessionDetails
    WHERE (@client_id IS NULL OR client_id = @client_id)
      AND (@from IS NULL OR started_at >= @from)
      AND (@to IS NULL OR started_at < DATEADD(DAY, 1, @to))
    ORDER BY started_at DESC;
END;
GO

-- Відкрити сесію. Перевірки ПК, зайнятості, гри й віку робить тригер trg_Session_Validate
CREATE OR ALTER PROCEDURE dbo.sp_StartSession
    @client_id   INT,
    @computer_id INT,
    @tariff_id   INT,
    @game_id     INT = NULL,
    @employee_id INT,
    @session_id  INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Пакет оплачується наперед: на рахунку має бути щонайменше його ціна
    DECLARE @now DATETIME = GETDATE(), @hours INT, @package DECIMAL(8,2), @balance DECIMAL(8,2), @msg NVARCHAR(400);
    SELECT @hours = hours FROM Tariff WHERE tariff_id = @tariff_id;
    SELECT @balance = balance FROM Client WHERE client_id = @client_id;

    IF @hours > 1
    BEGIN
        SET @package = dbo.fn_SessionPrice(@computer_id, @tariff_id, @now, @now);
        IF @balance < @package
        BEGIN
            SET @msg = N'Пакет коштує ' + CAST(@package AS NVARCHAR(20)) + N' грн, на рахунку '
                     + CAST(@balance AS NVARCHAR(20)) + N' грн. Спершу поповніть рахунок.';
            THROW 50030, @msg, 1;
        END;
    END;

    INSERT INTO Session (client_id, computer_id, employee_id, tariff_id, game_id, started_at)
    VALUES (@client_id, @computer_id, @employee_id, @tariff_id, @game_id, @now);

    SET @session_id = SCOPE_IDENTITY();
END;
GO

-- Поповнити рахунок. Баланс збільшить тригер trg_Deposit_Balance
CREATE OR ALTER PROCEDURE dbo.sp_TopUp
    @client_id   INT,
    @amount      DECIMAL(8,2),
    @method      NVARCHAR(20),
    @employee_id INT,
    @deposit_id  INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Deposit (client_id, employee_id, amount, paid_at, method)
    VALUES (@client_id, @employee_id, @amount, GETDATE(), @method);
    SET @deposit_id = SCOPE_IDENTITY();
END;
GO

/* Завершити сесію. Одна транзакція з трьох кроків:
   1) прийняти доплату (якщо є) - тригер збільшить баланс;
   2) порахувати ціну й закрити сесію - тригер спише гроші;
   3) якщо грошей не вистачає - відкотити все, включно з доплатою. */
CREATE OR ALTER PROCEDURE dbo.sp_CloseSession
    @session_id  INT,
    @pay_amount  DECIMAL(8,2) = 0,
    @method      NVARCHAR(20) = N'Готівка',
    @employee_id INT,
    @total_price DECIMAL(8,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @client_id INT, @computer_id INT, @tariff_id INT, @started_at DATETIME,
            @now DATETIME = GETDATE(), @balance DECIMAL(8,2), @msg NVARCHAR(400);

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @client_id = client_id, @computer_id = computer_id,
               @tariff_id = tariff_id, @started_at = started_at
        FROM Session WITH (UPDLOCK)
        WHERE session_id = @session_id AND ended_at IS NULL;

        IF @client_id IS NULL
            THROW 50031, N'Сесію не знайдено або вона вже завершена.', 1;

        IF @pay_amount > 0
            INSERT INTO Deposit (client_id, employee_id, amount, paid_at, method)
            VALUES (@client_id, @employee_id, @pay_amount, @now, @method);

        SET @total_price = dbo.fn_SessionPrice(@computer_id, @tariff_id, @started_at, @now);
        SELECT @balance = balance FROM Client WHERE client_id = @client_id;

        IF @balance < @total_price
        BEGIN
            SET @msg = N'Недостатньо коштів: до сплати ' + CAST(@total_price AS NVARCHAR(20))
                     + N' грн, на рахунку ' + CAST(@balance AS NVARCHAR(20))
                     + N' грн. Потрібно доплатити ще ' + CAST(@total_price - @balance AS NVARCHAR(20)) + N' грн.';
            THROW 50032, @msg, 1;
        END;

        UPDATE Session
        SET ended_at = @now, total_price = @total_price
        WHERE session_id = @session_id;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

-- Зареєструвати клієнта: обліковий запис і клієнт створюються разом або не створюються зовсім
CREATE OR ALTER PROCEDURE dbo.sp_RegisterClient
    @last       NVARCHAR(50),
    @first      NVARCHAR(50),
    @phone      NVARCHAR(20),
    @birth      DATE = NULL,
    @client_id  INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM UserAccount WHERE login = @phone)
           OR EXISTS (SELECT 1 FROM Client WHERE phone = @phone)
            THROW 50010, N'Клієнт з таким номером телефону вже зареєстрований.', 1;

        DECLARE @user_id INT;
        INSERT INTO UserAccount (role_id, login, password_hash)
        SELECT r.role_id, @phone, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CAST(@phone AS VARCHAR(30))), 2)
        FROM Role r
        WHERE r.name = N'Клієнт';
        SET @user_id = SCOPE_IDENTITY();

        IF @user_id IS NULL
            THROW 50033, N'У базі немає ролі «Клієнт».', 1;

        INSERT INTO Client (user_id, last_name, first_name, phone, birth_date, balance)
        VALUES (@user_id, @last, @first, @phone, @birth, 0);
        SET @client_id = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

-- Змінити ціни залів на відсоток. @hall_id = 0 або NULL - усі зали
CREATE OR ALTER PROCEDURE dbo.sp_ChangeHallPrices
    @hall_id INT = NULL,
    @percent DECIMAL(6,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Hall
        SET price_per_hour = ROUND(price_per_hour * (100 + @percent) / 100, 0)
        WHERE ISNULL(@hall_id, 0) = 0 OR hall_id = @hall_id;

        IF EXISTS (SELECT 1 FROM Hall WHERE price_per_hour <= 0)
            THROW 50034, N'Після зміни ціна години стала б нульовою. Зміни скасовано.', 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

-- ==================== Перевірка ====================

-- Скалярні функції викликаються в SELECT
SELECT dbo.fn_FullName(last_name, first_name)        AS [Клієнт],
       birth_date                                    AS [Дата народження],
       dbo.fn_Age(birth_date, CAST(GETDATE() AS DATE)) AS [Вік]
FROM Client
WHERE client_id = 1;

SELECT t.name AS [Тариф],
       dbo.fn_SessionPrice(1, t.tariff_id, '20250101 10:00', '20250101 12:00') AS [2 години в залі Стандарт (грн)]
FROM Tariff t;

-- Таблична функція викликається у FROM
SELECT TOP 10 * FROM dbo.fn_ClientStatement(1) ORDER BY op_date DESC;
SELECT TOP 5 * FROM dbo.fn_ClubLoad(DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), CAST(GETDATE() AS DATE));

-- Процедура з необов'язковими параметрами
EXEC dbo.sp_GetSessions @client_id = 1;
DECLARE @week_ago DATE = DATEADD(DAY, -7, GETDATE());
EXEC dbo.sp_GetSessions @from = @week_ago;
