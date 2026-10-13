/* Скрипт 5. Дані для звітів (ПР5)
   Звіти будуються в програмі (RDLC), ці запити дають їм рядки.
   Кожен звіт має кілька наборів даних; назва набору вказана над запитом.
   Назви колонок англійською: за ними звіт знаходить поля свого набору.
   Завантаженість рахує таблична функція dbo.fn_ClubLoad зі скрипту 07_procedures.sql. */

USE PCClub;
GO

-- Звіт «Завантаженість клубу», набір даних Load
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT Hall, DayOfWeek, DayName, Hour, BusyHours, CapacityHours FROM dbo.fn_ClubLoad(@from, @to);
GO

-- Звіт «Завантаженість клубу», набір даних LoadKpi
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
WITH agg AS (
    SELECT Hall, DayOfWeek, DayName, Hour, BusyHours, CapacityHours
    FROM dbo.fn_ClubLoad(@from, @to)
)
SELECT (SELECT SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) FROM agg) AS AvgLoad,
       p.DayName AS PeakDay,
       p.Hour    AS PeakHour,
       p.Load    AS PeakLoad,
       h.Hall    AS TopHall,
       h.Load    AS TopHallLoad
FROM (SELECT TOP 1 DayName, Hour, SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) AS Load
      FROM agg GROUP BY DayOfWeek, DayName, Hour ORDER BY Load DESC) p
CROSS JOIN (SELECT TOP 1 Hall, SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) AS Load
            FROM agg GROUP BY Hall ORDER BY Load DESC) h;
GO

-- Звіт «Фінанси за період», набір даних Sessions
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT CAST(ended_at AS DATE)                                  AS Day,
       hall                                                    AS Hall,
       total_price                                             AS Revenue,
       CAST(price_per_hour * minutes / 60.0 AS DECIMAL(10,2))  AS FullPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);
GO

-- Звіт «Фінанси за період», набір даних Deposits
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT employee AS Employee,
       method   AS Method,
       amount   AS Amount
FROM v_DepositDetails
WHERE paid_at >= @from
  AND paid_at < DATEADD(DAY, 1, @to);
GO

-- Звіт «Фінанси за період», набір даних Summary
DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Revenue,
       (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= DATEADD(DAY, -(DATEDIFF(DAY, @from, @to) + 1), @from) AND ended_at < @from)             AS PrevRevenue,
       (SELECT COUNT(*) FROM Session
         WHERE ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Sessions,
       (SELECT COUNT(*) FROM Session
         WHERE ended_at >= DATEADD(DAY, -(DATEDIFF(DAY, @from, @to) + 1), @from) AND ended_at < @from)             AS PrevSessions,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= @from AND paid_at < DATEADD(DAY, 1, @to))            AS Deposits,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= DATEADD(DAY, -(DATEDIFF(DAY, @from, @to) + 1), @from) AND paid_at < @from)               AS PrevDeposits,
       (SELECT ISNULL(SUM(price_per_hour * minutes / 60.0 - total_price), 0) FROM v_SessionDetails
         WHERE total_price IS NOT NULL
           AND ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Discounts,
       (SELECT ISNULL(SUM(balance), 0) FROM Client)                            AS Balances;
GO

-- Звіт «Клієнтська база», набір даних Weekly
DECLARE @from DATE = DATEADD(DAY, -90, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
WITH visits AS (
    SELECT DISTINCT s.client_id,
           DATEADD(DAY, -(DATEDIFF(DAY, 0, s.started_at) % 7), CAST(s.started_at AS DATE)) AS WeekStart
    FROM Session s
    WHERE s.started_at >= @from AND s.started_at < DATEADD(DAY, 1, @to)
)
SELECT v.WeekStart,
       SUM(CASE WHEN v.WeekStart <  DATEADD(DAY, 30, c.registered_at) THEN 1 ELSE 0 END) AS NewClients,
       SUM(CASE WHEN v.WeekStart >= DATEADD(DAY, 30, c.registered_at) THEN 1 ELSE 0 END) AS ReturningClients
FROM visits v
JOIN Client c ON c.client_id = v.client_id
GROUP BY v.WeekStart;
GO

-- Звіт «Клієнтська база», набір даних Top
DECLARE @from DATE = DATEADD(DAY, -90, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
WITH weeks AS (
    SELECT TOP (DATEDIFF(DAY, DATEADD(DAY, -(DATEDIFF(DAY, 0, @from) % 7), @from), @to) / 7 + 1)
           DATEADD(DAY, 7 * (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1),
                   DATEADD(DAY, -(DATEDIFF(DAY, 0, @from) % 7), @from)) AS WeekStart
    FROM sys.all_objects
),
top10 AS (
    SELECT TOP 10 client_id, SUM(total_price) AS spent, COUNT(*) AS visits
    FROM Session
    WHERE total_price IS NOT NULL
      AND started_at >= @from AND started_at < DATEADD(DAY, 1, @to)
    GROUP BY client_id
    ORDER BY spent DESC
)
SELECT c.last_name + N' ' + c.first_name AS Client,
       c.phone   AS Phone,
       t.visits  AS Visits,
       t.spent   AS Spent,
       w.WeekStart,
       ISNULL((SELECT SUM(s.total_price) FROM Session s
               WHERE s.client_id = t.client_id
                 AND s.total_price IS NOT NULL
                 AND s.started_at >= w.WeekStart AND s.started_at < DATEADD(DAY, 7, w.WeekStart)
                 AND s.started_at >= @from AND s.started_at < DATEADD(DAY, 1, @to)), 0) AS WeekSpent
FROM top10 t
JOIN Client c ON c.client_id = t.client_id
CROSS JOIN weeks w;
GO

-- Звіт «Клієнтська база», набір даних Lost
DECLARE @from DATE = DATEADD(DAY, -90, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
SELECT TOP 25
       c.last_name + N' ' + c.first_name AS Client,
       c.phone                           AS Phone,
       x.last_visit                      AS LastVisit,
       DATEDIFF(DAY, x.last_visit, @to)  AS DaysAway,
       x.visits                          AS Visits,
       x.spent                           AS Spent,
       c.balance                         AS Balance
FROM (SELECT client_id, MAX(started_at) AS last_visit, COUNT(*) AS visits, SUM(ISNULL(total_price, 0)) AS spent
      FROM Session
      WHERE started_at < DATEADD(DAY, 1, @to)
      GROUP BY client_id) x
JOIN Client c ON c.client_id = x.client_id
WHERE x.last_visit < DATEADD(DAY, -30, @to)
  AND x.visits >= 3
ORDER BY x.spent DESC;
GO

-- Звіт «Клієнтська база», набір даних ClientKpi
DECLARE @from DATE = DATEADD(DAY, -90, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);
WITH period AS (
    SELECT client_id, total_price
    FROM Session
    WHERE started_at >= @from AND started_at < DATEADD(DAY, 1, @to)
)
SELECT (SELECT COUNT(DISTINCT client_id) FROM period)                        AS Active,
       (SELECT COUNT(*) FROM Client
         WHERE registered_at >= @from AND registered_at < DATEADD(DAY, 1, @to))  AS NewClients,
       (SELECT COUNT(*) FROM period)                                         AS Visits,
       (SELECT ISNULL(SUM(total_price), 0) FROM period)                      AS Spent,
       (SELECT COUNT(*) FROM (SELECT client_id FROM Session
                              WHERE started_at < DATEADD(DAY, 1, @to)
                              GROUP BY client_id
                              HAVING MAX(started_at) < DATEADD(DAY, -30, @to)
                                 AND COUNT(*) >= 3) l)                       AS Lost;
GO
