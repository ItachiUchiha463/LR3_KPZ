/* Скрипт 2 з 4. Наповнення бази.
   Довідники (зали, ПК, жанри, ігри, тарифи, працівники) задані явно,
   клієнти, сесії й поповнення генеруються за останні 180 днів відносно поточної дати.
   Баланс клієнта = сума поповнень - сума завершених сесій (ніколи не від'ємний).
   Облікові записи: admin/admin, manager/manager, решта - логін і пароль = номер телефону.
   Запускати після 01_schema.sql на порожній базі. */

USE PCClub;
GO
SET NOCOUNT ON;

DECLARE @now DATETIME = GETDATE();
DECLARE @today DATE = CAST(@now AS DATE);

-- ---------- Довідники ----------

INSERT INTO Role (name) VALUES (N'Адміністратор'), (N'Менеджер'), (N'Клієнт');

INSERT INTO Hall (name, price_per_hour) VALUES
(N'Стандарт', 60), (N'VIP', 100), (N'Буткемп', 130);

INSERT INTO Genre (name) VALUES
(N'Шутер'), (N'MOBA'), (N'Рольова гра (RPG)'), (N'Спорт'), (N'Стратегія'),
(N'Гонки'), (N'Файтинг'), (N'Виживання'), (N'Симулятор');

INSERT INTO Game (genre_id, title, age_limit) VALUES
(1, N'Counter-Strike 2', 16),
(2, N'Dota 2', 12),
(3, N'Cyberpunk 2077', 18),
(4, N'FIFA', 3),
(1, N'Valorant', 16),
(1, N'Apex Legends', 16),
(1, N'PUBG', 16),
(2, N'League of Legends', 12),
(4, N'EA FC 25', 3),
(5, N'Age of Empires IV', 12),
(5, N'StarCraft II', 12),
(5, N'Civilization VI', 12),
(6, N'Need for Speed Heat', 12),
(6, N'Forza Horizon 5', 3),
(6, N'Assetto Corsa', 3),
(7, N'Mortal Kombat 11', 18),
(7, N'Tekken 8', 16),
(8, N'Rust', 16),
(8, N'The Forest', 16),
(8, N'Minecraft', 7),
(9, N'Euro Truck Simulator 2', 3),
(9, N'Farming Simulator 22', 3),
(3, N'GTA V', 18);

INSERT INTO Tariff (name, hours, discount_percent) VALUES
(N'Погодинний', 1, 0), (N'5 годин', 5, 10), (N'Нічний', 8, 25);

INSERT INTO Computer (hall_id, number, gpu, monitor_hz, status) VALUES
(1, 1, N'GTX 1660', 144, N'Справний'),
(1, 2, N'GTX 1660', 144, N'Справний'),
(1, 3, N'RTX 4060', 165, N'Справний'),
(1, 4, N'RTX 4070', 240, N'Справний'),
(1, 5, N'GTX 1660', 144, N'Справний'),
(1, 6, N'GTX 1660', 144, N'Справний'),
(1, 7, N'RTX 4070', 240, N'Справний'),
(1, 8, N'RTX 4060', 165, N'Справний'),
(1, 9, N'GTX 1660', 144, N'Справний'),
(1, 10, N'GTX 1660', 144, N'Справний'),
(2, 1, N'RTX 3060', 165, N'Справний'),
(2, 2, N'RTX 3060', 165, N'Справний'),
(2, 3, N'GTX 1660', 144, N'Справний'),
(2, 4, N'GTX 1660', 144, N'Справний'),
(2, 5, N'RTX 3060', 165, N'Несправний'),
(2, 6, N'RTX 3060', 165, N'Несправний'),
(2, 7, N'GTX 1660', 144, N'Справний'),
(2, 8, N'RTX 3060', 165, N'Справний'),
(2, 9, N'GTX 1660', 144, N'Справний'),
(2, 10, N'RTX 3060', 165, N'Справний'),
(3, 1, N'RTX 4070', 240, N'Справний'),
(3, 2, N'RTX 4070', 240, N'Справний'),
(3, 3, N'RTX 3060', 165, N'Справний'),
(3, 4, N'GTX 1660', 144, N'Справний'),
(3, 5, N'RTX 4060', 165, N'Справний'),
(3, 6, N'RTX 4070', 240, N'Справний'),
(3, 7, N'RTX 3060', 165, N'Справний'),
(3, 8, N'RTX 4070', 240, N'Справний'),
(3, 9, N'RTX 3060', 165, N'Справний');

INSERT INTO Employee (last_name, first_name, phone, shift) VALUES
(N'Петренко',   N'Андрій',   N'0991112233', N'Денна'),
(N'Бондар',     N'Софія',    N'0632223344', N'Нічна'),
(N'Бондаренко', N'Ігор',     N'0688932186', N'Денна'),
(N'Ткаченко',   N'Софія',    N'0936982107', N'Денна'),
(N'Мороз',      N'Денис',    N'0684957035', N'Ранкова'),
(N'Романюк',    N'Максим',   N'0680857117', N'Ранкова'),
(N'Шевчук',     N'Вікторія', N'0508449305', N'Нічна'),
(N'Бондаренко', N'Андрій',   N'0639057472', N'Ранкова');

-- Встановлені ігри: halls - у яких залах, max_pc - на скількох ПК (NULL - на всіх)
DECLARE @cov TABLE (game_id INT, halls VARCHAR(3), max_pc INT NULL);
INSERT INTO @cov VALUES
(1, '123', NULL), (2, '123', NULL), (5, '123', NULL), (6, '123', NULL), (7, '123', NULL),
(8, '123', NULL), (23, '123', NULL), (17, '123', NULL),
(4, '12', NULL), (9, '12', NULL), (13, '12', NULL), (16, '12', NULL), (20, '12', NULL),
(3, '23', NULL), (18, '23', NULL), (14, '123', 12),
(19, '2', NULL), (15, '3', 4), (10, '12', 3), (11, '13', 4), (12, '2', 2),
(21, '1', 3), (22, '1', 1);

INSERT INTO ComputerGame (computer_id, game_id)
SELECT computer_id, game_id
FROM (SELECT c.computer_id, v.game_id, v.max_pc,
             ROW_NUMBER() OVER (PARTITION BY v.game_id ORDER BY NEWID()) AS rn
      FROM @cov v
      JOIN Computer c ON CHARINDEX(CAST(c.hall_id AS VARCHAR(1)), v.halls) > 0) x
WHERE max_pc IS NULL OR rn <= max_pc;

-- ---------- Клієнти ----------

DECLARE @ln TABLE (id INT IDENTITY, v NVARCHAR(50));
INSERT INTO @ln (v) VALUES
(N'Шевченко'), (N'Бондаренко'), (N'Ткаченко'), (N'Кравченко'), (N'Олійник'), (N'Шевчук'),
(N'Поліщук'), (N'Бойко'), (N'Ткачук'), (N'Мельник'), (N'Коваль'), (N'Мороз'), (N'Лисенко'),
(N'Руденко'), (N'Савченко'), (N'Марченко'), (N'Романюк'), (N'Гончаренко'), (N'Литвиненко'),
(N'Левченко'), (N'Захарченко'), (N'Кузьменко'), (N'Павленко'), (N'Остапчук'), (N'Гнатюк'),
(N'Петрук'), (N'Іванченко'), (N'Дмитренко'), (N'Федоренко'), (N'Харченко'), (N'Семенюк'),
(N'Пономаренко'), (N'Климчук'), (N'Мартинюк'), (N'Данилюк'), (N'Онищенко'), (N'Гаврилюк'),
(N'Гончар'), (N'Білоус'), (N'Олешко');

DECLARE @mn TABLE (id INT IDENTITY, v NVARCHAR(50));
INSERT INTO @mn (v) VALUES
(N'Олег'), (N'Андрій'), (N'Дмитро'), (N'Максим'), (N'Богдан'), (N'Денис'), (N'Ігор'),
(N'Артем'), (N'Владислав'), (N'Назар'), (N'Тарас'), (N'Юрій'), (N'Олександр'), (N'Віталій'),
(N'Роман'), (N'Сергій'), (N'Євген'), (N'Микола'), (N'Ярослав'), (N'Іван');

DECLARE @fn TABLE (id INT IDENTITY, v NVARCHAR(50));
INSERT INTO @fn (v) VALUES
(N'Марія'), (N'Олена'), (N'Софія'), (N'Анна'), (N'Вікторія'), (N'Дарина'), (N'Ірина'),
(N'Катерина'), (N'Юлія'), (N'Анастасія'), (N'Оксана'), (N'Христина'), (N'Наталія'), (N'Ольга');

DECLARE @prefix TABLE (id INT IDENTITY, v NCHAR(2));
INSERT INTO @prefix (v) VALUES
(N'50'), (N'63'), (N'66'), (N'67'), (N'68'), (N'73'), (N'93'), (N'95'), (N'96'), (N'97'), (N'98'), (N'99');

DECLARE @lnCount INT = (SELECT COUNT(*) FROM @ln),
        @mnCount INT = (SELECT COUNT(*) FROM @mn),
        @fnCount INT = (SELECT COUNT(*) FROM @fn);

-- Тестовий клієнт для входу: 0501112233 / 0501112233
INSERT INTO Client (last_name, first_name, phone, birth_date, registered_at)
VALUES (N'Коваленко', N'Іван', N'0501112233', '2003-05-10', DATEADD(DAY, -300, @today));

-- Випадкові числа спершу записуються в таблицю, щоб NEWID() не обчислювався повторно при з'єднаннях
CREATE TABLE #rnd (n INT PRIMARY KEY, r1 INT, r2 INT, r3 INT, r4 INT, r5 INT, female BIT);
INSERT INTO #rnd
SELECT TOP 200
       ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
       ABS(CHECKSUM(NEWID())), ABS(CHECKSUM(NEWID())), ABS(CHECKSUM(NEWID())),
       ABS(CHECKSUM(NEWID())), ABS(CHECKSUM(NEWID())),
       CASE WHEN ABS(CHECKSUM(NEWID())) % 100 < 30 THEN 1 ELSE 0 END
FROM sys.all_objects;

INSERT INTO Client (last_name, first_name, phone, birth_date, registered_at)
SELECT l.v,
       CASE WHEN r.female = 1 THEN f.v ELSE m.v END,
       N'0' + p.v + RIGHT(N'0000000' + CAST((r.n * 7919 + 1234567) % 10000000 AS NVARCHAR(7)), 7),
       DATEADD(DAY, -(16 * 365 + r.r4 % (22 * 365)), @today),
       DATEADD(DAY, -(r.r5 % 420), @today)
FROM #rnd r
JOIN @ln l     ON l.id = r.r1 % @lnCount + 1
JOIN @mn m     ON m.id = r.r2 % @mnCount + 1
JOIN @fn f     ON f.id = r.r2 % @fnCount + 1
JOIN @prefix p ON p.id = r.r3 % 12 + 1
ORDER BY r.n;

-- Неактивні клієнти: давно зареєстровані, без сесій і поповнень (для запиту A9)
INSERT INTO Client (last_name, first_name, phone, birth_date, registered_at) VALUES
(N'Гнатюк',    N'Петро',  N'0990000001', '1999-03-14', DATEADD(DAY, -400, @today)),
(N'Сидоренко', N'Ольга',  N'0990000002', '2002-07-01', DATEADD(DAY, -350, @today)),
(N'Кравець',   N'Ігор',   N'0990000003', '1997-11-23', DATEADD(DAY, -300, @today)),
(N'Литвин',    N'Дарина', N'0990000004', '2004-01-09', DATEADD(DAY, -250, @today)),
(N'Марченко',  N'Василь', N'0990000005', '2000-05-30', DATEADD(DAY, -200, @today));

-- ---------- Сесії ----------

-- Популярність ігор: чим більша вага, тим частіше гру вибирають
DECLARE @gw TABLE (game_id INT PRIMARY KEY, w INT);
INSERT INTO @gw VALUES
(1, 10), (2, 9), (5, 8), (23, 7), (8, 6), (7, 5), (6, 4), (9, 4), (4, 3), (20, 3),
(3, 3), (17, 3), (16, 2), (14, 2), (13, 2), (18, 2), (19, 2), (11, 1), (10, 1),
(12, 1), (15, 1), (21, 1), (22, 1);

CREATE TABLE #s (
    id INT IDENTITY, client_id INT, computer_id INT, employee_id INT, tariff_id INT,
    game_id INT NULL, started_at DATETIME, ended_at DATETIME NULL, total_price DECIMAL(8,2) NULL
);

DECLARE @made INT = 0, @tries INT = 0, @d INT, @day DATE, @tf INT, @hour INT, @dur INT,
        @st DATETIME, @en DATETIME, @pc INT, @cl INT, @age INT, @gm INT, @em INT,
        @shift NVARCHAR(20), @price DECIMAL(8,2), @r INT;

WHILE @made < 650 AND @tries < 20000
BEGIN
    SET @tries += 1;

    -- мінімум з двох випадкових днів: свіжих сесій більше (клуб росте)
    SELECT @d = MIN(v) FROM (VALUES (ABS(CHECKSUM(NEWID())) % 180), (ABS(CHECKSUM(NEWID())) % 180)) x(v);
    SET @day = DATEADD(DAY, -@d, @today);

    -- з понеділка по четвер відвідувачів менше
    IF DATEDIFF(DAY, 0, @day) % 7 < 4 AND ABS(CHECKSUM(NEWID())) % 100 < 30 CONTINUE;

    SET @r = ABS(CHECKSUM(NEWID())) % 100;
    SET @tf = CASE WHEN @r < 68 THEN 1 WHEN @r < 88 THEN 2 ELSE 3 END;

    IF @tf = 3
        SELECT @hour = 22 + ABS(CHECKSUM(NEWID())) % 2, @dur = 480;
    ELSE IF @tf = 2
        SELECT @hour = 10 + ABS(CHECKSUM(NEWID())) % 9, @dur = 300;
    ELSE
    BEGIN
        SELECT @hour = 10 + MAX(v) FROM (VALUES (ABS(CHECKSUM(NEWID())) % 13), (ABS(CHECKSUM(NEWID())) % 13)) x(v);
        SET @dur = 60 + (ABS(CHECKSUM(NEWID())) % 13) * 15;
    END;

    SET @st = DATEADD(MINUTE, @hour * 60 + ABS(CHECKSUM(NEWID())) % 60, CAST(@day AS DATETIME));
    SET @en = DATEADD(MINUTE, @dur, @st);
    IF @en > DATEADD(MINUTE, -30, @now) CONTINUE;

    -- несправні ПК не працюють останні два тижні
    SET @pc = NULL;
    SELECT TOP 1 @pc = c.computer_id
    FROM Computer c
    WHERE (c.status = N'Справний' OR @st < DATEADD(DAY, -14, @now))
      AND NOT EXISTS (SELECT 1 FROM #s s
                      WHERE s.computer_id = c.computer_id AND s.started_at < @en AND s.ended_at > @st)
    ORDER BY NEWID();
    IF @pc IS NULL CONTINUE;

    -- майже половину сесій дають постійні клієнти (перші 40)
    SET @cl = NULL;
    SET @r = ABS(CHECKSUM(NEWID())) % 100;
    SELECT TOP 1 @cl = c.client_id, @age = DATEDIFF(YEAR, c.birth_date, @st)
    FROM Client c
    WHERE c.registered_at <= CAST(@st AS DATE)
      AND c.phone NOT LIKE N'09900000%'
      AND (@r >= 45 OR c.client_id <= 41)
      AND NOT EXISTS (SELECT 1 FROM #s s
                      WHERE s.client_id = c.client_id AND s.started_at < @en AND s.ended_at > @st)
    ORDER BY NEWID();
    IF @cl IS NULL CONTINUE;

    -- гра з тих, що встановлені на ПК і дозволені за віком; іноді без гри
    SET @gm = NULL;
    IF ABS(CHECKSUM(NEWID())) % 100 >= 8
        SELECT TOP 1 @gm = cg.game_id
        FROM ComputerGame cg
        JOIN Game g  ON g.game_id = cg.game_id
        JOIN @gw w   ON w.game_id = cg.game_id
        WHERE cg.computer_id = @pc AND g.age_limit <= @age
        ORDER BY -LOG((ABS(CHECKSUM(NEWID())) % 1000000 + 1) / 1000001.0) / w.w;

    -- працівник зміни, на яку припав початок сесії (власник клубу сесій не відкриває)
    SET @shift = CASE WHEN DATEPART(HOUR, @st) < 6 OR DATEPART(HOUR, @st) >= 22 THEN N'Нічна'
                      WHEN DATEPART(HOUR, @st) < 14 THEN N'Ранкова'
                      ELSE N'Денна' END;
    SELECT TOP 1 @em = employee_id FROM Employee
    WHERE shift = @shift AND employee_id <> 1
    ORDER BY NEWID();

    SELECT @price = ROUND(h.price_per_hour * @dur / 60.0 * (100 - t.discount_percent) / 100.0, 2)
    FROM Computer c
    JOIN Hall h   ON h.hall_id = c.hall_id
    JOIN Tariff t ON t.tariff_id = @tf
    WHERE c.computer_id = @pc;

    INSERT INTO #s (client_id, computer_id, employee_id, tariff_id, game_id, started_at, ended_at, total_price)
    VALUES (@cl, @pc, @em, @tf, @gm, @st, @en, @price);
    SET @made += 1;
END;

-- ---------- Поповнення й баланс ----------

CREATE TABLE #bal (client_id INT PRIMARY KEY, bal DECIMAL(10,2));
INSERT INTO #bal SELECT client_id, 0 FROM Client;

CREATE TABLE #d (client_id INT, employee_id INT, amount DECIMAL(8,2), paid_at DATETIME, method NVARCHAR(20));

DECLARE @b DECIMAL(10,2), @amt DECIMAL(8,2);

-- Перед кожною сесією клієнт поповнює рахунок, якщо грошей не вистачає
DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT client_id, employee_id, started_at, total_price FROM #s ORDER BY started_at;
OPEN cur;
FETCH NEXT FROM cur INTO @cl, @em, @st, @price;
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @b = bal FROM #bal WHERE client_id = @cl;
    IF @b < @price
    BEGIN
        SET @amt = CEILING((@price - @b) / 100.0) * 100 + (ABS(CHECKSUM(NEWID())) % 4) * 100;
        INSERT INTO #d VALUES (@cl, @em, @amt, DATEADD(MINUTE, -(1 + ABS(CHECKSUM(NEWID())) % 10), @st),
                               CASE WHEN ABS(CHECKSUM(NEWID())) % 100 < 60 THEN N'Готівка' ELSE N'Картка' END);
        SET @b += @amt;
    END;
    UPDATE #bal SET bal = @b - @price WHERE client_id = @cl;
    FETCH NEXT FROM cur INTO @cl, @em, @st, @price;
END;
CLOSE cur;
DEALLOCATE cur;

-- Кілька клієнтів поповнили рахунок, але ще не грали
INSERT INTO #d (client_id, employee_id, amount, paid_at, method)
SELECT TOP 12 c.client_id,
       3 + ABS(CHECKSUM(NEWID())) % 6,
       100 * (1 + ABS(CHECKSUM(NEWID())) % 4),
       DATEADD(MINUTE, 10 * 60 + ABS(CHECKSUM(NEWID())) % 600,
               CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % DATEDIFF(DAY, c.registered_at, @today), c.registered_at) AS DATETIME)),
       CASE WHEN ABS(CHECKSUM(NEWID())) % 100 < 60 THEN N'Готівка' ELSE N'Картка' END
FROM Client c
WHERE NOT EXISTS (SELECT 1 FROM #s s WHERE s.client_id = c.client_id)
  AND c.phone NOT LIKE N'09900000%'
  AND c.registered_at < @today
ORDER BY NEWID();

UPDATE b SET bal = b.bal + d.total
FROM #bal b
JOIN (SELECT client_id, SUM(amount) AS total FROM #d
      WHERE client_id NOT IN (SELECT client_id FROM #s) GROUP BY client_id) d ON d.client_id = b.client_id;

-- ---------- Відкриті сесії (хто грає зараз) ----------

DECLARE @k INT = 0;
WHILE @k < 6
BEGIN
    SET @st = DATEADD(MINUTE, -(15 + ABS(CHECKSUM(NEWID())) % 150), @now);

    SET @pc = NULL;
    SELECT TOP 1 @pc = c.computer_id FROM Computer c
    WHERE c.status = N'Справний'
      AND NOT EXISTS (SELECT 1 FROM #s s
                      WHERE s.computer_id = c.computer_id AND (s.ended_at IS NULL OR s.ended_at > @st))
    ORDER BY NEWID();

    -- перші два клієнти з майже порожнім балансом (для позначки «Не вистачає»)
    SET @cl = NULL;
    SELECT TOP 1 @cl = c.client_id, @age = DATEDIFF(YEAR, c.birth_date, @now)
    FROM Client c
    JOIN #bal b ON b.client_id = c.client_id
    WHERE c.phone NOT LIKE N'09900000%'
      AND (@k >= 2 OR b.bal < 40)
      AND EXISTS (SELECT 1 FROM #s s WHERE s.client_id = c.client_id)
      AND NOT EXISTS (SELECT 1 FROM #s s
                      WHERE s.client_id = c.client_id AND (s.ended_at IS NULL OR s.ended_at > @st))
    ORDER BY NEWID();
    IF @pc IS NULL OR @cl IS NULL BREAK;

    SET @shift = CASE WHEN DATEPART(HOUR, @st) < 6 OR DATEPART(HOUR, @st) >= 22 THEN N'Нічна'
                      WHEN DATEPART(HOUR, @st) < 14 THEN N'Ранкова'
                      ELSE N'Денна' END;
    SELECT TOP 1 @em = employee_id FROM Employee
    WHERE shift = @shift AND employee_id <> 1
    ORDER BY NEWID();

    SET @gm = NULL;
    SELECT TOP 1 @gm = cg.game_id
    FROM ComputerGame cg
    JOIN Game g ON g.game_id = cg.game_id
    JOIN @gw w  ON w.game_id = cg.game_id
    WHERE cg.computer_id = @pc AND g.age_limit <= @age
    ORDER BY -LOG((ABS(CHECKSUM(NEWID())) % 1000000 + 1) / 1000001.0) / w.w;

    IF @k >= 2
    BEGIN
        SELECT @b = bal FROM #bal WHERE client_id = @cl;
        IF @b < 400
        BEGIN
            SET @amt = CEILING((400 - @b) / 100.0) * 100;
            INSERT INTO #d VALUES (@cl, @em, @amt, DATEADD(MINUTE, -5, @st), N'Готівка');
            UPDATE #bal SET bal = bal + @amt WHERE client_id = @cl;
        END;
    END;

    INSERT INTO #s (client_id, computer_id, employee_id, tariff_id, game_id, started_at)
    VALUES (@cl, @pc, @em, 1, @gm, @st);
    SET @k += 1;
END;

-- ---------- Запис у таблиці ----------

INSERT INTO Session (client_id, computer_id, employee_id, tariff_id, game_id, started_at, ended_at, total_price)
SELECT client_id, computer_id, employee_id, tariff_id, game_id, started_at, ended_at, total_price
FROM #s ORDER BY started_at;

INSERT INTO Deposit (client_id, employee_id, amount, paid_at, method)
SELECT client_id, employee_id, amount, paid_at, method
FROM #d ORDER BY paid_at;

UPDATE c SET balance = b.bal
FROM Client c JOIN #bal b ON b.client_id = c.client_id;

-- ---------- Облікові записи ----------

INSERT INTO UserAccount (role_id, login, password_hash) VALUES (1, N'admin', ''), (2, N'manager', '');
INSERT INTO UserAccount (role_id, login, password_hash)
SELECT 2, phone, '' FROM Employee WHERE employee_id > 2 ORDER BY employee_id;
INSERT INTO UserAccount (role_id, login, password_hash)
SELECT 3, phone, '' FROM Client ORDER BY client_id;

UPDATE e SET user_id = u.user_id
FROM Employee e
JOIN UserAccount u ON u.login = CASE e.employee_id WHEN 1 THEN N'admin' WHEN 2 THEN N'manager' ELSE e.phone END;

UPDATE c SET user_id = u.user_id
FROM Client c JOIN UserAccount u ON u.login = c.phone AND u.role_id = 3;

-- Пароль = логін. CAST до VARCHAR, бо програма хешує байти UTF-8, а HASHBYTES від NVARCHAR рахує UTF-16
UPDATE UserAccount
SET password_hash = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CAST(login AS VARCHAR(30))), 2);

DROP TABLE #rnd, #s, #bal, #d;
GO

-- Перевірка
SELECT N'Клієнтів' AS [Показник], COUNT(*) AS [Кількість] FROM Client
UNION ALL SELECT N'Сесій', COUNT(*) FROM Session
UNION ALL SELECT N'Відкритих сесій', COUNT(*) FROM Session WHERE ended_at IS NULL
UNION ALL SELECT N'Поповнень', COUNT(*) FROM Deposit
UNION ALL SELECT N'Облікових записів', COUNT(*) FROM UserAccount
UNION ALL SELECT N'Несправних ПК', COUNT(*) FROM Computer WHERE status = N'Несправний'
UNION ALL SELECT N'Баланс не сходиться', COUNT(*)
          FROM Client c
          WHERE c.balance <> ISNULL((SELECT SUM(amount) FROM Deposit d WHERE d.client_id = c.client_id), 0)
                           - ISNULL((SELECT SUM(total_price) FROM Session s WHERE s.client_id = c.client_id), 0);
