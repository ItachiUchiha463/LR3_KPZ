using System.Collections.Generic;
using System.Linq;

namespace PC_Club
{
    public class ReportDef
    {
        public string Code;
        public string Title;
        public UserRole[] Roles;
        public int DefaultDays = 30;
        public Dictionary<string, string> DataSets = new Dictionary<string, string>();

        public string Resource
        {
            get { return "PC_Club.Reports." + Code + ".rdlc"; }
        }
    }

    public static class ReportCatalog
    {
        private static readonly UserRole[] Staff = { UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] AdminOnly = { UserRole.Admin };

        private const string LoadCte = @"
WITH days AS (
    SELECT TOP (DATEDIFF(DAY, @from, @to) + 1)
           DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1, CAST(@from AS DATE)) AS d
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
),
agg AS (
    SELECT cp.hall AS Hall,
           cp.dow  AS DayOfWeek,
           CHOOSE(cp.dow + 1, N'Пн', N'Вт', N'Ср', N'Чт', N'Пт', N'Сб', N'Нд') AS DayName,
           CAST(cp.hr AS INT) AS Hour,
           CAST(ISNULL(b.hours, 0) AS DECIMAL(12,2)) AS BusyHours,
           CAST(cp.pcs_hours AS DECIMAL(12,2))       AS CapacityHours
    FROM capacity cp
    LEFT JOIN busy b ON b.hall = cp.hall AND b.dow = cp.dow AND b.hr = cp.hr
)";

        private const string PrevFrom = "DATEADD(DAY, -(DATEDIFF(DAY, @from, @to) + 1), @from)";

        public static readonly List<ReportDef> All = new List<ReportDef>
        {
            new ReportDef
            {
                Code = "ClubLoad", Roles = Staff,
                Title = "Завантаженість клубу",
                DataSets =
                {
                    { "Load", LoadCte + @"
SELECT Hall, DayOfWeek, DayName, Hour, BusyHours, CapacityHours FROM agg;" },

                    { "LoadKpi", LoadCte + @"
SELECT (SELECT SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) FROM agg) AS AvgLoad,
       p.DayName AS PeakDay,
       p.Hour    AS PeakHour,
       p.Load    AS PeakLoad,
       h.Hall    AS TopHall,
       h.Load    AS TopHallLoad
FROM (SELECT TOP 1 DayName, Hour, SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) AS Load
      FROM agg GROUP BY DayOfWeek, DayName, Hour ORDER BY Load DESC) p
CROSS JOIN (SELECT TOP 1 Hall, SUM(BusyHours) / NULLIF(SUM(CapacityHours), 0) AS Load
            FROM agg GROUP BY Hall ORDER BY Load DESC) h;" }
                }
            },

            new ReportDef
            {
                Code = "Finance", Roles = AdminOnly,
                Title = "Фінанси за період",
                DataSets =
                {
                    { "Sessions", @"
SELECT CAST(ended_at AS DATE)                                  AS Day,
       hall                                                    AS Hall,
       total_price                                             AS Revenue,
       CAST(price_per_hour * minutes / 60.0 AS DECIMAL(10,2))  AS FullPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);" },

                    { "Deposits", @"
SELECT employee AS Employee,
       method   AS Method,
       amount   AS Amount
FROM v_DepositDetails
WHERE paid_at >= @from
  AND paid_at < DATEADD(DAY, 1, @to);" },

                    { "Summary", @"
SELECT (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Revenue,
       (SELECT ISNULL(SUM(total_price), 0) FROM Session
         WHERE ended_at >= " + PrevFrom + @" AND ended_at < @from)             AS PrevRevenue,
       (SELECT COUNT(*) FROM Session
         WHERE ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Sessions,
       (SELECT COUNT(*) FROM Session
         WHERE ended_at >= " + PrevFrom + @" AND ended_at < @from)             AS PrevSessions,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= @from AND paid_at < DATEADD(DAY, 1, @to))            AS Deposits,
       (SELECT ISNULL(SUM(amount), 0) FROM Deposit
         WHERE paid_at >= " + PrevFrom + @" AND paid_at < @from)               AS PrevDeposits,
       (SELECT ISNULL(SUM(price_per_hour * minutes / 60.0 - total_price), 0) FROM v_SessionDetails
         WHERE total_price IS NOT NULL
           AND ended_at >= @from AND ended_at < DATEADD(DAY, 1, @to))          AS Discounts,
       (SELECT ISNULL(SUM(balance), 0) FROM Client)                            AS Balances;" }
                }
            },

            new ReportDef
            {
                Code = "Clients", Roles = Staff, DefaultDays = 90,
                Title = "Клієнтська база",
                DataSets =
                {
                    { "Weekly", @"
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
GROUP BY v.WeekStart;" },

                    { "Top", @"
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
CROSS JOIN weeks w;" },

                    { "Lost", @"
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
ORDER BY x.spent DESC;" },

                    { "ClientKpi", @"
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
                                 AND COUNT(*) >= 3) l)                       AS Lost;" }
                }
            }
        };

        public static ReportDef Get(string code)
        {
            return All.FirstOrDefault(r => r.Code == code);
        }
    }
}
