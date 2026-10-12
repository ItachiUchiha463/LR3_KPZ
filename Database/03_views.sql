/* Скрипт 3 з 4. Відображення (VIEW)

   Для звіту v_SessionDetails варто створити через конструктор, як у методичці:
   PCClub → Views (Представления) → ПКМ → New View (Створити подання) → додати таблиці
   Session, Client, Computer, Hall, Employee, Tariff, Game, Genre → у нижній панелі SQL
   замінити текст на SELECT ... (тіло з блоку нижче, без рядка CREATE OR ALTER VIEW ... AS)
   → зберегти з іменем v_SessionDetails. Скріншоти: вікно конструктора зі зв'язками, збереження.
   Решту відображень можна створити цим скриптом. Якщо v_SessionDetails зроблено в
   конструкторі, перший блок просто перезапише його тим самим текстом. */

USE PCClub;
GO

-- 1. Сесії з назвами замість кодів. Основа для більшості звітів
CREATE OR ALTER VIEW dbo.v_SessionDetails
AS
SELECT
    s.session_id,
    s.client_id,
    c.last_name + N' ' + c.first_name                      AS client,
    c.phone,
    s.computer_id,
    p.hall_id,
    h.name                                                AS hall,
    p.number                                              AS computer_number,
    h.name + N' #' + CAST(p.number AS NVARCHAR(10))       AS computer,
    h.price_per_hour,
    s.employee_id,
    e.last_name + N' ' + e.first_name                      AS employee,
    s.tariff_id,
    t.name                                                AS tariff,
    t.discount_percent,
    s.game_id,
    ISNULL(g.title, N'—')                                 AS game,
    ISNULL(ge.name, N'—')                                 AS genre,
    s.started_at,
    s.ended_at,
    DATEDIFF(MINUTE, s.started_at, ISNULL(s.ended_at, GETDATE()))                          AS minutes,
    CAST(DATEDIFF(MINUTE, s.started_at, ISNULL(s.ended_at, GETDATE())) / 60.0 AS DECIMAL(10,1)) AS hours,
    s.total_price,
    CAST(CASE WHEN s.ended_at IS NULL THEN 1 ELSE 0 END AS BIT)                            AS is_active
FROM Session s
JOIN Client   c  ON c.client_id   = s.client_id
JOIN Computer p  ON p.computer_id = s.computer_id
JOIN Hall     h  ON h.hall_id     = p.hall_id
JOIN Employee e  ON e.employee_id = s.employee_id
JOIN Tariff   t  ON t.tariff_id   = s.tariff_id
LEFT JOIN Game  g  ON g.game_id   = s.game_id
LEFT JOIN Genre ge ON ge.genre_id = g.genre_id;
GO

-- 2. Незавершені сесії: хто зараз грає, скільки вже набіжало і чи вистачає балансу
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
    CAST(d.price_per_hour * d.minutes / 60.0 * (100 - d.discount_percent) / 100.0 AS DECIMAL(8,2)) AS current_price,
    c.balance
FROM dbo.v_SessionDetails d
JOIN Client c ON c.client_id = d.client_id
WHERE d.ended_at IS NULL;
GO

-- 3. Вільні комп'ютери: справні й без відкритої сесії
CREATE OR ALTER VIEW dbo.v_FreeComputers
AS
SELECT
    c.computer_id,
    c.hall_id,
    h.name AS hall,
    c.number,
    c.gpu,
    c.monitor_hz,
    h.price_per_hour
FROM Computer c
JOIN Hall h ON h.hall_id = c.hall_id
WHERE c.status <> N'Несправний'
  AND NOT EXISTS (SELECT 1 FROM Session s
                  WHERE s.computer_id = c.computer_id AND s.ended_at IS NULL);
GO

-- 4. Поповнення з іменами клієнта й працівника. Основа звіту «Поповнення по працівниках»
CREATE OR ALTER VIEW dbo.v_DepositDetails
AS
SELECT
    d.deposit_id,
    d.paid_at,
    d.client_id,
    c.last_name + N' ' + c.first_name AS client,
    d.employee_id,
    e.last_name + N' ' + e.first_name AS employee,
    d.method,
    d.amount
FROM Deposit d
JOIN Client   c ON c.client_id   = d.client_id
JOIN Employee e ON e.employee_id = d.employee_id;
GO

-- Перевірка
SELECT N'v_SessionDetails' AS [Відображення], COUNT(*) AS [Рядків] FROM v_SessionDetails
UNION ALL SELECT N'v_ActiveSessions', COUNT(*) FROM v_ActiveSessions
UNION ALL SELECT N'v_FreeComputers',  COUNT(*) FROM v_FreeComputers
UNION ALL SELECT N'v_DepositDetails', COUNT(*) FROM v_DepositDetails;
-- v_SessionDetails = кількість сесій, v_ActiveSessions = 6, v_FreeComputers = 29 - 2 несправні - 6 зайняті = 21, v_DepositDetails = кількість поповнень
