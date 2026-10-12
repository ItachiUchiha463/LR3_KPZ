/* Скрипт 4 з 4. Запити (22 + вхід + шапка клієнта)

   Кожен запит у своєму блоці між GO: виділи блок і натисни F5, щоб перевірити.
   Рядки DECLARE задають тестові значення параметрів; у програмі ці значення
   прийдуть з полів форми як параметри SqlCommand (@назва), тож текст після DECLARE
   переноситься в C# без змін.
   Запити на дію (M6, M7, A8, A9) обгорнуто в BEGIN TRAN ... ROLLBACK лише для
   перевірки: вони показують результат, але нічого не змінюють у базі. */

USE PCClub;
GO

/* =====================================================================
   Службові запити
   ===================================================================== */

-- Л1. Вхід: перевірка логіна й пароля, роль і власник облікового запису
-- Конструкції: JOIN, LEFT JOIN, WHERE з параметрами
DECLARE @login NVARCHAR(30) = N'admin';
DECLARE @hash  VARCHAR(64)  = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin'), 2); -- у програмі рахує C#
SELECT ua.user_id,
       r.name                            AS role_name,
       e.employee_id,
       e.last_name + N' ' + e.first_name AS employee_name,
       c.client_id,
       c.last_name + N' ' + c.first_name AS client_name
FROM UserAccount ua
JOIN Role r          ON r.role_id = ua.role_id
LEFT JOIN Employee e ON e.user_id = ua.user_id
LEFT JOIN Client c   ON c.user_id = ua.user_id
WHERE ua.login = @login
  AND ua.password_hash = @hash;
GO

-- Ш1. Шапка вікна клієнта: баланс і підсумки
-- Конструкції: підзапити в SELECT
DECLARE @client_id INT = 1;
SELECT c.last_name + N' ' + c.first_name AS client_name,
       c.balance,
       (SELECT COUNT(*) FROM Session s WHERE s.client_id = c.client_id)                    AS sessions,
       (SELECT ISNULL(SUM(s.total_price), 0) FROM Session s WHERE s.client_id = c.client_id) AS spent,
       (SELECT ISNULL(SUM(d.amount), 0) FROM Deposit d WHERE d.client_id = c.client_id)     AS deposited
FROM Client c
WHERE c.client_id = @client_id;
GO

/* =====================================================================
   КОРИСТУВАЧ (клієнт)
   ===================================================================== */

-- U1. Вільні комп'ютери зараз
-- Параметр: зал (0 = усі). Конструкції: відображення v_FreeComputers, WHERE, ORDER BY
DECLARE @hall_id INT = 0;
SELECT hall           AS [Зал],
       number         AS [Номер],
       gpu            AS [Відеокарта],
       monitor_hz     AS [Монітор, Гц],
       price_per_hour AS [Ціна за годину, грн]
FROM v_FreeComputers
WHERE @hall_id = 0 OR hall_id = @hall_id
ORDER BY hall, number;
GO

-- U2. Де можна пограти в гру
-- Параметр: частина назви гри. Конструкції: JOIN 4 таблиць, LIKE, CASE, підзапит EXISTS
DECLARE @game NVARCHAR(100) = N'Dota';
SELECT g.title  AS [Гра],
       h.name   AS [Зал],
       c.number AS [Номер ПК],
       c.gpu    AS [Відеокарта],
       CASE
           WHEN c.status = N'Несправний' THEN N'Несправний'
           WHEN EXISTS (SELECT 1 FROM Session s
                        WHERE s.computer_id = c.computer_id AND s.ended_at IS NULL) THEN N'Зайнятий'
           ELSE N'Вільний'
       END      AS [Стан]
FROM Game g
JOIN ComputerGame cg ON cg.game_id = g.game_id
JOIN Computer c      ON c.computer_id = cg.computer_id
JOIN Hall h          ON h.hall_id = c.hall_id
WHERE g.title LIKE N'%' + @game + N'%'
ORDER BY g.title, h.name, c.number;
GO

-- U3. Каталог ігор (як у методичці: оператор порівняння вибирається зі списку)
-- Параметри: жанр (0 = усі), оператор для віку, вік.
-- Оператор не можна передати параметром: у програмі він підставляється в текст
-- ЛИШЕ зі списку дозволених (=, <, >, <=, >=, <>). Тут для прикладу <=.
-- Конструкції: WHERE з операторами порівняння й AND, підзапит, ORDER BY
DECLARE @genre_id INT = 0, @age INT = 16;
SELECT g.title       AS [Гра],
       ge.name       AS [Жанр],
       g.age_limit   AS [Вікове обмеження],
       (SELECT COUNT(*) FROM ComputerGame cg WHERE cg.game_id = g.game_id) AS [Встановлено на ПК]
FROM Game g
JOIN Genre ge ON ge.genre_id = g.genre_id
WHERE (@genre_id = 0 OR g.genre_id = @genre_id)
  AND g.age_limit <= @age
ORDER BY ge.name, g.title;
GO

-- U4. Калькулятор вартості: усі зали × усі тарифи
-- Параметр: зал (0 = усі). Конструкції: CROSS JOIN, обчислювані поля, псевдоніми
DECLARE @hall_id INT = 0;
SELECT h.name             AS [Зал],
       t.name             AS [Тариф],
       t.hours            AS [Годин],
       t.discount_percent AS [Знижка, %],
       h.price_per_hour * t.hours                                                      AS [Без знижки, грн],
       CAST(h.price_per_hour * t.hours * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2)) AS [До сплати, грн],
       CAST(h.price_per_hour * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2))           AS [За годину, грн]
FROM Hall h
CROSS JOIN Tariff t
WHERE @hall_id = 0 OR h.hall_id = @hall_id
ORDER BY h.name, [До сплати, грн];
GO

-- U5. Топ-5 популярних ігор
-- Параметр: за скільки останніх днів. Конструкції: TOP, GROUP BY, COUNT, SUM, ORDER BY
DECLARE @days INT = 30;
SELECT TOP 5
       g.title  AS [Гра],
       ge.name  AS [Жанр],
       COUNT(*) AS [Сесій],
       CAST(SUM(DATEDIFF(MINUTE, s.started_at, ISNULL(s.ended_at, GETDATE()))) / 60.0 AS DECIMAL(10,1)) AS [Годин зіграно]
FROM Session s
JOIN Game g   ON g.game_id = s.game_id
JOIN Genre ge ON ge.genre_id = g.genre_id
WHERE s.started_at >= DATEADD(DAY, -@days, GETDATE())
GROUP BY g.title, ge.name
ORDER BY [Сесій] DESC, [Годин зіграно] DESC;
GO

-- U6. Мої сесії
-- Параметри: клієнт (береться з облікового запису, не вводиться), період.
-- Конструкції: відображення, WHERE з параметрами, діапазон дат
DECLARE @client_id INT = 1;
DECLARE @from DATE = DATEADD(MONTH, -2, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT started_at  AS [Початок],
       ended_at    AS [Завершення],
       computer    AS [Комп'ютер],
       tariff      AS [Тариф],
       game        AS [Гра],
       hours       AS [Годин],
       total_price AS [Сума, грн]
FROM v_SessionDetails
WHERE client_id = @client_id
  AND started_at >= @from
  AND started_at < DATEADD(DAY, 1, @to)
ORDER BY started_at DESC;
GO

/* =====================================================================
   МЕНЕДЖЕР (працівник зміни)
   ===================================================================== */

-- M1. Хто зараз грає
-- Конструкції: відображення v_ActiveSessions, обчислюване поле, CASE
SELECT client        AS [Клієнт],
       phone         AS [Телефон],
       computer      AS [Комп'ютер],
       game          AS [Гра],
       tariff        AS [Тариф],
       started_at    AS [Початок],
       minutes       AS [Грає, хв],
       current_price AS [Набіжало, грн],
       balance       AS [Баланс, грн],
       CASE WHEN balance < current_price THEN N'Не вистачає' ELSE N'' END AS [Увага]
FROM v_ActiveSessions
ORDER BY started_at;
GO

-- M2. Пошук клієнта за прізвищем, іменем або телефоном
-- Конструкції: LIKE, OR, LEFT JOIN, підзапити (кількість сесій, останній візит)
DECLARE @text NVARCHAR(50) = N'Кова';
SELECT c.client_id   AS [Код],
       c.last_name   AS [Прізвище],
       c.first_name  AS [Ім'я],
       c.phone       AS [Телефон],
       ua.login      AS [Логін],
       c.balance     AS [Баланс, грн],
       c.registered_at AS [Зареєстрований],
       (SELECT COUNT(*) FROM Session s WHERE s.client_id = c.client_id)        AS [Сесій],
       (SELECT MAX(s.started_at) FROM Session s WHERE s.client_id = c.client_id) AS [Останній візит]
FROM Client c
LEFT JOIN UserAccount ua ON ua.user_id = c.user_id
WHERE c.last_name  LIKE N'%' + @text + N'%'
   OR c.first_name LIKE N'%' + @text + N'%'
   OR c.phone      LIKE N'%' + @text + N'%'
ORDER BY c.last_name, c.first_name;
GO

-- M3. Клієнти з балансом нижче заданого
-- Цей запит додається в ClientTableAdapter як FillByLowBalance (другий механізм з методички),
-- тому він повертає ВСІ колонки таблиці Client у тому ж порядку, що й основний запит адаптера.
-- Конструкції: WHERE з параметром, ORDER BY
DECLARE @limit DECIMAL(8,2) = 50;
SELECT client_id, user_id, last_name, first_name, phone, birth_date, registered_at, balance
FROM Client
WHERE balance < @limit
ORDER BY balance, last_name;
GO

-- M4. Рух коштів клієнта: поповнення й оплати сесій в одному списку
-- Параметр: клієнт (вибір зі списку). Конструкції: UNION ALL, JOIN, LEFT JOIN, ORDER BY
DECLARE @client_id INT = 1;
SELECT d.paid_at  AS [Дата],
       N'Поповнення' AS [Операція],
       d.method   AS [Деталі],
       d.amount   AS [Сума, грн]
FROM Deposit d
WHERE d.client_id = @client_id
UNION ALL
SELECT s.ended_at,
       N'Оплата сесії',
       h.name + N' #' + CAST(c.number AS NVARCHAR(10)) + ISNULL(N', ' + g.title, N''),
       -s.total_price
FROM Session s
JOIN Computer c ON c.computer_id = s.computer_id
JOIN Hall h     ON h.hall_id = c.hall_id
LEFT JOIN Game g ON g.game_id = s.game_id
WHERE s.client_id = @client_id
  AND s.ended_at IS NOT NULL
ORDER BY [Дата] DESC;
GO

-- M5. Поповнення за період по працівниках і способах оплати
-- Параметри: період, працівник (0 = усі; за замовчуванням поточний менеджер).
-- Конструкції: GROUP BY двох полів, COUNT, SUM
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
DECLARE @employee_id INT = 0;
SELECT e.last_name + N' ' + e.first_name AS [Працівник],
       d.method        AS [Спосіб оплати],
       COUNT(*)        AS [Поповнень],
       SUM(d.amount)   AS [Сума, грн]
FROM Deposit d
JOIN Employee e ON e.employee_id = d.employee_id
WHERE d.paid_at >= @from
  AND d.paid_at < DATEADD(DAY, 1, @to)
  AND (@employee_id = 0 OR d.employee_id = @employee_id)
GROUP BY e.last_name, e.first_name, d.method
ORDER BY [Працівник], [Спосіб оплати];
GO

-- M6. Змінити статус комп'ютера (запит на дію: UPDATE)
-- Параметри: комп'ютер, новий статус. Зробити «Вільним» ПК з відкритою сесією не можна.
DECLARE @computer_id INT = 1, @status NVARCHAR(20) = N'Несправний';
BEGIN TRAN;   -- лише для перевірки в SSMS
UPDATE Computer
SET status = @status
WHERE computer_id = @computer_id
  AND (@status <> N'Вільний'
       OR NOT EXISTS (SELECT 1 FROM Session s
                      WHERE s.computer_id = @computer_id AND s.ended_at IS NULL));
SELECT @@ROWCOUNT AS [Змінено записів];   -- 0 означає: умова не дозволила зміну
SELECT computer_id, number, status FROM Computer WHERE computer_id = @computer_id;
ROLLBACK;
GO

-- M7. Швидка реєстрація клієнта разом з обліковим записом (запит на дію: INSERT)
-- Параметри: прізвище, ім'я, телефон, дата народження. Логін і пароль = телефон.
-- Дві вставки одним пакетом; атомарність (транзакція) буде темою наступної роботи.
DECLARE @last NVARCHAR(50) = N'Тестовий', @first NVARCHAR(50) = N'Клієнт',
        @phone NVARCHAR(20) = N'0671234567', @birth DATE = '2003-04-15';
IF EXISTS (SELECT 1 FROM UserAccount WHERE login = @phone)
       OR EXISTS (SELECT 1 FROM Client WHERE phone = @phone)
    THROW 50010, N'Клієнт з таким номером телефону вже зареєстрований.', 1;

BEGIN TRAN;   -- лише для перевірки в SSMS
INSERT INTO UserAccount (role_id, login, password_hash)
SELECT r.role_id, @phone, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CAST(@phone AS VARCHAR(30))), 2)
FROM Role r
WHERE r.name IN (N'Клієнт', N'Client');

INSERT INTO Client (user_id, last_name, first_name, phone, birth_date, balance)
VALUES (SCOPE_IDENTITY(), @last, @first, @phone, @birth, 0);

SELECT c.client_id, c.last_name, c.first_name, c.phone, ua.login
FROM Client c JOIN UserAccount ua ON ua.user_id = c.user_id
WHERE c.phone = @phone;
ROLLBACK;
GO

/* =====================================================================
   АДМІНІСТРАТОР (власник)
   ===================================================================== */

-- A1. Виручка по днях за період
-- Конструкції: відображення, BETWEEN-діапазон, GROUP BY за обчислюваним полем, SUM, AVG, COUNT
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT CAST(ended_at AS DATE)                AS [Дата],
       COUNT(*)                              AS [Сесій],
       SUM(hours)                            AS [Годин],
       SUM(total_price)                      AS [Виручка, грн],
       CAST(AVG(total_price) AS DECIMAL(8,2)) AS [Середній чек, грн]
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to)
GROUP BY CAST(ended_at AS DATE)
ORDER BY [Дата];
GO

-- A2. Виручка по залах (лише зали з виручкою більше заданої)
-- Конструкції: GROUP BY, HAVING, SUM, AVG
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
DECLARE @min DECIMAL(10,2) = 0;
SELECT hall                                   AS [Зал],
       COUNT(*)                               AS [Сесій],
       SUM(hours)                             AS [Годин],
       SUM(total_price)                       AS [Виручка, грн],
       CAST(AVG(total_price) AS DECIMAL(8,2)) AS [Середній чек, грн]
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to)
GROUP BY hall
HAVING SUM(total_price) > @min
ORDER BY [Виручка, грн] DESC;
GO

-- A3. Завантаженість комп'ютерів (разом із тими, що не мали жодної сесії)
-- Конструкції: LEFT JOIN з умовою в ON (щоб не втратити ПК без сесій), COUNT, SUM, ISNULL
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT h.name   AS [Зал],
       c.number AS [Номер],
       c.gpu    AS [Відеокарта],
       c.status AS [Статус],
       COUNT(s.session_id) AS [Сесій],
       CAST(ISNULL(SUM(DATEDIFF(MINUTE, s.started_at, ISNULL(s.ended_at, GETDATE()))), 0) / 60.0 AS DECIMAL(10,1)) AS [Годин],
       ISNULL(SUM(s.total_price), 0) AS [Виручка, грн]
FROM Computer c
JOIN Hall h ON h.hall_id = c.hall_id
LEFT JOIN Session s ON s.computer_id = c.computer_id
                   AND s.started_at >= @from
                   AND s.started_at < DATEADD(DAY, 1, @to)
GROUP BY c.computer_id, h.name, c.number, c.gpu, c.status
ORDER BY [Годин] DESC, [Зал], [Номер];
GO

-- A4. Найкращі клієнти: витратили більше за середнього клієнта
-- Конструкції: GROUP BY, HAVING з підзапитом, вкладений підзапит з AVG
SELECT c.last_name + N' ' + c.first_name AS [Клієнт],
       c.phone            AS [Телефон],
       COUNT(*)           AS [Сесій],
       SUM(s.total_price) AS [Витрачено, грн],
       c.balance          AS [Баланс, грн]
FROM Client c
JOIN Session s ON s.client_id = c.client_id
WHERE s.total_price IS NOT NULL
GROUP BY c.client_id, c.last_name, c.first_name, c.phone, c.balance
HAVING SUM(s.total_price) > (SELECT AVG(t.spent)
                             FROM (SELECT SUM(total_price) AS spent
                                   FROM Session
                                   WHERE total_price IS NOT NULL
                                   GROUP BY client_id) t)
ORDER BY [Витрачено, грн] DESC;
GO

-- A5. Робота працівників за період: сесії й прийняті кошти
-- Конструкції: корельовані підзапити в SELECT, ISNULL
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT e.last_name + N' ' + e.first_name AS [Працівник],
       e.shift AS [Зміна],
       (SELECT COUNT(*) FROM Session s
         WHERE s.employee_id = e.employee_id
           AND s.started_at >= @from AND s.started_at < DATEADD(DAY, 1, @to)) AS [Відкрито сесій],
       (SELECT ISNULL(SUM(s.total_price), 0) FROM Session s
         WHERE s.employee_id = e.employee_id
           AND s.started_at >= @from AND s.started_at < DATEADD(DAY, 1, @to)) AS [Сесій на суму, грн],
       (SELECT COUNT(*) FROM Deposit d
         WHERE d.employee_id = e.employee_id
           AND d.paid_at >= @from AND d.paid_at < DATEADD(DAY, 1, @to))      AS [Поповнень],
       (SELECT ISNULL(SUM(d.amount), 0) FROM Deposit d
         WHERE d.employee_id = e.employee_id
           AND d.paid_at >= @from AND d.paid_at < DATEADD(DAY, 1, @to))      AS [Прийнято коштів, грн]
FROM Employee e
ORDER BY [Прийнято коштів, грн] DESC;
GO

-- A6. Ігри, яких бракує на комп'ютерах (встановлені менш ніж на N ПК, у т. ч. ніде)
-- Конструкції: LEFT JOIN, GROUP BY, HAVING, COUNT по стовпцю (не рахує NULL)
DECLARE @max_pc INT = 5;
SELECT g.title     AS [Гра],
       ge.name     AS [Жанр],
       g.age_limit AS [Вікове обмеження],
       COUNT(cg.computer_id) AS [Встановлено на ПК]
FROM Game g
JOIN Genre ge ON ge.genre_id = g.genre_id
LEFT JOIN ComputerGame cg ON cg.game_id = g.game_id
GROUP BY g.game_id, g.title, ge.name, g.age_limit
HAVING COUNT(cg.computer_id) < @max_pc
ORDER BY [Встановлено на ПК], [Гра];
GO

-- A7. Виручка залів по днях тижня (перехресний запит: зали в рядках, дні в колонках)
-- День тижня рахується як DATEDIFF(DAY, 0, дата) % 7, бо 01.01.1900 був понеділком:
-- так результат не залежить від налаштування SET DATEFIRST.
-- Конструкції: PIVOT, підзапит у FROM, ISNULL, обчислюване поле «Разом»
DECLARE @from DATE = DATEADD(DAY, -60, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT hall AS [Зал],
       ISNULL([0], 0) AS [Пн], ISNULL([1], 0) AS [Вт], ISNULL([2], 0) AS [Ср],
       ISNULL([3], 0) AS [Чт], ISNULL([4], 0) AS [Пт], ISNULL([5], 0) AS [Сб],
       ISNULL([6], 0) AS [Нд],
       ISNULL([0], 0) + ISNULL([1], 0) + ISNULL([2], 0) + ISNULL([3], 0)
     + ISNULL([4], 0) + ISNULL([5], 0) + ISNULL([6], 0) AS [Разом, грн]
FROM (SELECT hall,
             DATEDIFF(DAY, 0, started_at) % 7 AS dow,
             total_price
      FROM v_SessionDetails
      WHERE total_price IS NOT NULL
        AND started_at >= @from
        AND started_at < DATEADD(DAY, 1, @to)) src
PIVOT (SUM(total_price) FOR dow IN ([0], [1], [2], [3], [4], [5], [6])) p
ORDER BY [Разом, грн] DESC;
GO

-- A8. Змінити ціни залу на X % (запит на дію: масовий UPDATE з обчисленням)
-- Параметри: зал (0 = усі), відсоток (від'ємний = знижка). Ціна округлюється до гривні.
DECLARE @hall_id INT = 0, @percent DECIMAL(5,2) = 10;
BEGIN TRAN;   -- лише для перевірки в SSMS
SELECT name, price_per_hour AS [Було] FROM Hall WHERE @hall_id = 0 OR hall_id = @hall_id;
UPDATE Hall
SET price_per_hour = ROUND(price_per_hour * (100 + @percent) / 100, 0)
WHERE @hall_id = 0 OR hall_id = @hall_id;
SELECT @@ROWCOUNT AS [Змінено записів];
SELECT name, price_per_hour AS [Стало] FROM Hall WHERE @hall_id = 0 OR hall_id = @hall_id;
ROLLBACK;
GO

-- A9. Видалити неактивних клієнтів (запит на дію: DELETE з підзапитами)
-- Неактивний: зареєстрований понад N днів тому, нуль на балансі, жодної сесії й поповнення.
-- Спочатку попередній перегляд (у програмі показується перед підтвердженням),
-- потім видалення облікових записів і самих клієнтів.
DECLARE @days INT = 180;

SELECT c.client_id, c.last_name, c.first_name, c.phone, c.registered_at
FROM Client c
WHERE c.balance = 0
  AND c.registered_at < DATEADD(DAY, -@days, CAST(GETDATE() AS DATE))
  AND NOT EXISTS (SELECT 1 FROM Session s WHERE s.client_id = c.client_id)
  AND NOT EXISTS (SELECT 1 FROM Deposit d WHERE d.client_id = c.client_id);

BEGIN TRAN;   -- лише для перевірки в SSMS
DELETE ua
FROM UserAccount ua
JOIN Client c ON c.user_id = ua.user_id
WHERE c.balance = 0
  AND c.registered_at < DATEADD(DAY, -@days, CAST(GETDATE() AS DATE))
  AND NOT EXISTS (SELECT 1 FROM Session s WHERE s.client_id = c.client_id)
  AND NOT EXISTS (SELECT 1 FROM Deposit d WHERE d.client_id = c.client_id);

DELETE FROM Client
WHERE balance = 0
  AND registered_at < DATEADD(DAY, -@days, CAST(GETDATE() AS DATE))
  AND NOT EXISTS (SELECT 1 FROM Session s WHERE s.client_id = Client.client_id)
  AND NOT EXISTS (SELECT 1 FROM Deposit d WHERE d.client_id = Client.client_id);
SELECT @@ROWCOUNT AS [Видалено клієнтів];
ROLLBACK;
GO
