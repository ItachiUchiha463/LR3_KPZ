using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PC_Club
{
    // Каталог запитів ЛР4: текст SQL, параметри й ролі, яким запит доступний
    public static class QueryCatalog
    {
        private static readonly UserRole[] Everyone = { UserRole.User, UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] ClientOnly = { UserRole.User };
        private static readonly UserRole[] Staff = { UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] AdminOnly = { UserRole.Admin };

        public static readonly List<QueryDef> All = Build();

        public static QueryDef Get(string code)
        {
            return All.FirstOrDefault(q => q.Code == code);
        }

        public static IEnumerable<QueryDef> ForRole(UserRole role)
        {
            return All.Where(q => q.Roles.Contains(role));
        }

        // ---------- Короткі способи описати параметр ----------

        private static QueryParam Txt(string name, string caption, bool required = false, int width = 180)
        {
            return new QueryParam { Name = name, Caption = caption, Kind = ParamKind.Text, Required = required, Width = width };
        }

        private static QueryParam Int(string name, string caption, int def, int min, int max)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Int,
                Default = () => def,
                Min = min,
                Max = max,
                Width = 90
            };
        }

        private static QueryParam Dec(string name, string caption, decimal def, decimal min, decimal max)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Decimal,
                Default = () => def,
                Min = min,
                Max = max,
                Width = 100
            };
        }

        // Дата: сьогодні + offsetDays
        private static QueryParam DateP(string name, string caption, int offsetDays)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Date,
                Default = () => DateTime.Today.AddDays(offsetDays),
                Width = 110
            };
        }

        private static QueryParam OptDate(string name, string caption)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.OptionalDate,
                Required = false,
                Width = 130
            };
        }

        private static QueryParam Phone(string name, string caption)
        {
            return new QueryParam { Name = name, Caption = caption, Kind = ParamKind.Phone, Width = 130 };
        }

        private static QueryParam Look(string name, string caption, Func<DataTable> source,
                                       bool allOption, Func<object> def = null, int width = 200)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Lookup,
                Source = source,
                AllOption = allOption,
                Default = def,
                Width = width
            };
        }

        private static QueryParam Choice(string name, string caption, params string[] choices)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Choice,
                Choices = choices,
                Width = 130
            };
        }

        private static QueryParam Op(string name, string caption, string def)
        {
            return new QueryParam
            {
                Name = name,
                Caption = caption,
                Kind = ParamKind.Operator,
                Default = () => def,
                Width = 60
            };
        }

        private static QueryParam CurrentClient()
        {
            return new QueryParam { Name = "client_id", Caption = "Клієнт", Kind = ParamKind.CurrentClient };
        }

        // ---------- Запити ----------

        private static List<QueryDef> Build()
        {
            return new List<QueryDef>
            {
                // =============== КОРИСТУВАЧ (клієнт) ===============

                new QueryDef
                {
                    Code = "U1", Roles = Everyone,
                    Title = "Вільні комп'ютери",
                    Sql = @"
SELECT hall           AS [Зал],
       number         AS [Номер],
       gpu            AS [Відеокарта],
       monitor_hz     AS [Монітор, Гц],
       price_per_hour AS [Ціна за годину, грн]
FROM v_FreeComputers
ORDER BY hall, number;"
                },

                new QueryDef
                {
                    Code = "U2", Roles = Everyone,
                    Title = "Де пограти в гру",
                    Params = { Txt("game", "Назва гри або жанр") },
                    Sql = @"
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
JOIN Genre ge        ON ge.genre_id = g.genre_id
WHERE g.title LIKE N'%' + @game + N'%'
   OR ge.name LIKE N'%' + @game + N'%'
ORDER BY g.title, h.name, c.number;"
                },

                new QueryDef
                {
                    Code = "U3", Roles = Everyone,
                    Title = "Каталог ігор",
                    Params =
                    {
                        Look("genre_id", "Жанр", Lookups.Genres, true),
                        Op("op", "Вік", "<="),
                        Int("age", "років", 16, 0, 21)
                    },
                    Sql = @"
SELECT g.title     AS [Гра],
       ge.name     AS [Жанр],
       g.age_limit AS [Вікове обмеження],
       (SELECT COUNT(*) FROM ComputerGame cg WHERE cg.game_id = g.game_id) AS [Встановлено на ПК]
FROM Game g
JOIN Genre ge ON ge.genre_id = g.genre_id
WHERE (@genre_id = 0 OR g.genre_id = @genre_id)
  AND g.age_limit {op} @age
ORDER BY ge.name, g.title;"
                },

                new QueryDef
                {
                    Code = "U4", Roles = Everyone,
                    Title = "Калькулятор вартості",
                    Sql = @"
SELECT h.name             AS [Зал],
       t.name             AS [Тариф],
       t.hours            AS [Годин],
       t.discount_percent AS [Знижка, %],
       h.price_per_hour * t.hours AS [Без знижки, грн],
       CAST(h.price_per_hour * t.hours * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2)) AS [До сплати, грн],
       CAST(h.price_per_hour * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2))           AS [За годину, грн]
FROM Hall h
CROSS JOIN Tariff t
ORDER BY h.name, [До сплати, грн];"
                },

                new QueryDef
                {
                    Code = "U5", Roles = Everyone,
                    Title = "Топ-5 популярних ігор",
                    Params = { Int("days", "За останні днів", 30, 1, 365) },
                    Sql = @"
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
ORDER BY [Сесій] DESC, [Годин зіграно] DESC;"
                },

                new QueryDef
                {
                    Code = "U6", Roles = ClientOnly,
                    Title = "Мої сесії",
                    Params = { CurrentClient() },
                    Sql = @"
SELECT started_at  AS [Початок],
       ended_at    AS [Завершення],
       computer    AS [Комп'ютер],
       tariff      AS [Тариф],
       game        AS [Гра],
       hours       AS [Годин],
       total_price AS [Сума, грн]
FROM v_SessionDetails
WHERE client_id = @client_id
ORDER BY started_at DESC;"
                },

                // =============== МЕНЕДЖЕР (працівник зміни) ===============

                new QueryDef
                {
                    Code = "M1", Roles = Staff,
                    Title = "Хто зараз грає",
                    Sql = @"
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
ORDER BY started_at;"
                },

                new QueryDef
                {
                    Code = "M4", Roles = Staff,
                    Title = "Рух коштів клієнта",
                    Params = { Look("client_id", "Клієнт", Lookups.Clients, false, null, 230) },
                    AutoRun = false,
                    Sql = @"
SELECT d.paid_at     AS [Дата],
       N'Поповнення' AS [Операція],
       d.method      AS [Деталі],
       d.amount      AS [Сума, грн]
FROM Deposit d
WHERE d.client_id = @client_id
UNION ALL
SELECT s.ended_at,
       N'Оплата сесії',
       h.name + N' #' + CAST(c.number AS NVARCHAR(10)) + ISNULL(N', ' + g.title, N''),
       -s.total_price
FROM Session s
JOIN Computer c  ON c.computer_id = s.computer_id
JOIN Hall h      ON h.hall_id = c.hall_id
LEFT JOIN Game g ON g.game_id = s.game_id
WHERE s.client_id = @client_id
  AND s.ended_at IS NOT NULL
ORDER BY [Дата] DESC;"
                },

                new QueryDef
                {
                    Code = "M5", Roles = Staff,
                    Title = "Поповнення за період",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
SELECT e.last_name + N' ' + e.first_name AS [Працівник],
       d.method      AS [Спосіб оплати],
       COUNT(*)      AS [Поповнень],
       SUM(d.amount) AS [Сума, грн]
FROM Deposit d
JOIN Employee e ON e.employee_id = d.employee_id
WHERE d.paid_at >= @from
  AND d.paid_at < DATEADD(DAY, 1, @to)
GROUP BY e.last_name, e.first_name, d.method
ORDER BY [Працівник], [Спосіб оплати];"
                },

                new QueryDef
                {
                    Code = "M7", Roles = Staff, IsAction = true, AutoRun = false,
                    Title = "Реєстрація клієнта",
                    Params =
                    {
                        Txt("last", "Прізвище", true, 150),
                        Txt("first", "Ім'я", true, 150),
                        Phone("phone", "Телефон"),
                        OptDate("birth", "Дата народження")
                    },
                    ConfirmText = "Зареєструвати нового клієнта?",
                    SuccessText = "Клієнта зареєстровано. Логін і пароль для входу: його номер телефону.",
                    Sql = @"
IF EXISTS (SELECT 1 FROM UserAccount WHERE login = @phone)
       OR EXISTS (SELECT 1 FROM Client WHERE phone = @phone)
    THROW 50010, N'Клієнт з таким номером телефону вже зареєстрований.', 1;

INSERT INTO UserAccount (role_id, login, password_hash)
SELECT r.role_id, @phone, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CAST(@phone AS VARCHAR(30))), 2)
FROM Role r
WHERE r.name IN (N'Клієнт', N'Client');

INSERT INTO Client (user_id, last_name, first_name, phone, birth_date, balance)
VALUES (SCOPE_IDENTITY(), @last, @first, @phone, @birth, 0);",
                    ResultSql = @"
SELECT c.client_id     AS [Код],
       c.last_name     AS [Прізвище],
       c.first_name    AS [Ім'я],
       c.phone         AS [Телефон],
       ua.login        AS [Логін],
       c.registered_at AS [Зареєстрований]
FROM Client c
JOIN UserAccount ua ON ua.user_id = c.user_id
WHERE c.phone = @phone;"
                },

                // =============== АДМІНІСТРАТОР (власник) ===============

                new QueryDef
                {
                    Code = "A1", Roles = AdminOnly,
                    Title = "Виручка по днях",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
SELECT CAST(ended_at AS DATE)                 AS [Дата],
       COUNT(*)                               AS [Сесій],
       SUM(hours)                             AS [Годин],
       SUM(total_price)                       AS [Виручка, грн],
       CAST(AVG(total_price) AS DECIMAL(8,2)) AS [Середній чек, грн]
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to)
GROUP BY CAST(ended_at AS DATE)
ORDER BY [Дата];"
                },

                new QueryDef
                {
                    Code = "A2", Roles = AdminOnly,
                    Title = "Виручка по залах",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
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
ORDER BY [Виручка, грн] DESC;"
                },

                new QueryDef
                {
                    Code = "A3", Roles = AdminOnly,
                    Title = "Завантаженість комп'ютерів",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
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
ORDER BY [Годин] DESC, [Зал], [Номер];"
                },

                new QueryDef
                {
                    Code = "A4", Roles = AdminOnly,
                    Title = "Найкращі клієнти",
                    Sql = @"
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
ORDER BY [Витрачено, грн] DESC;"
                },

                new QueryDef
                {
                    Code = "A5", Roles = AdminOnly,
                    Title = "Робота працівників",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
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
ORDER BY [Прийнято коштів, грн] DESC;"
                },

                new QueryDef
                {
                    Code = "A7", Roles = AdminOnly,
                    Title = "Виручка залів по днях тижня",
                    Params = { DateP("from", "З", -60), DateP("to", "По", 0) },
                    Sql = @"
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
ORDER BY [Разом, грн] DESC;"
                },

                new QueryDef
                {
                    Code = "A8", Roles = AdminOnly, IsAction = true, AutoRun = false,
                    Title = "Змінити ціни залів",
                    Params =
                    {
                        Look("hall_id", "Зал", Lookups.Halls, true),
                        Dec("percent", "Зміна, %", 10, -50, 100)
                    },
                    PreviewSql = @"
SELECT name           AS [Зал],
       price_per_hour AS [Ціна зараз, грн],
       ROUND(price_per_hour * (100 + @percent) / 100, 0) AS [Нова ціна, грн]
FROM Hall
WHERE @hall_id = 0 OR hall_id = @hall_id
ORDER BY name;",
                    ConfirmText = "Змінити ціну в залах: {0}?",
                    Sql = @"
UPDATE Hall
SET price_per_hour = ROUND(price_per_hour * (100 + @percent) / 100, 0)
WHERE @hall_id = 0 OR hall_id = @hall_id;",
                    ResultSql = @"
SELECT name AS [Зал], price_per_hour AS [Ціна за годину, грн]
FROM Hall
ORDER BY name;"
                },

                new QueryDef
                {
                    Code = "A9", Roles = AdminOnly, IsAction = true, AutoRun = false,
                    Title = "Видалити неактивних клієнтів",
                    Params = { Int("days", "Зареєстровані понад днів тому", 180, 1, 3650) },
                    PreviewSql = @"
SELECT c.client_id     AS [Код],
       c.last_name     AS [Прізвище],
       c.first_name    AS [Ім'я],
       c.phone         AS [Телефон],
       c.registered_at AS [Зареєстрований]
FROM Client c
WHERE c.balance = 0
  AND c.registered_at < DATEADD(DAY, -@days, CAST(GETDATE() AS DATE))
  AND NOT EXISTS (SELECT 1 FROM Session s WHERE s.client_id = c.client_id)
  AND NOT EXISTS (SELECT 1 FROM Deposit d WHERE d.client_id = c.client_id)
ORDER BY c.registered_at;",
                    ConfirmText = "Буде видалено клієнтів: {0} (разом з їхніми обліковими записами). Продовжити?",
                    SuccessText = "Видалено неактивних клієнтів: {1}.",
                    Sql = @"
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
  AND NOT EXISTS (SELECT 1 FROM Deposit d WHERE d.client_id = Client.client_id);"
                }
            };
        }
    }
}