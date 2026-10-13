using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PC_Club
{
    public static class QueryCatalog
    {
        private static readonly UserRole[] Everyone = { UserRole.User, UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] ClientOnly = { UserRole.User };
        private static readonly UserRole[] Staff = { UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] AdminOnly = { UserRole.Admin };

        public const string ShiftSection = "Робота зміни";
        public const string ClubSection = "Клуб";
        public const string AdminSection = "Адміністрування";

        public static readonly List<QueryDef> All = Build();

        public static QueryDef Get(string code)
        {
            return All.FirstOrDefault(q => q.Code == code);
        }

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

        private static QueryParam CurrentClient()
        {
            return new QueryParam { Name = "client_id", Caption = "Клієнт", Kind = ParamKind.CurrentClient };
        }

        private static QueryParam CurrentEmployee()
        {
            return new QueryParam { Name = "employee_id", Caption = "Працівник", Kind = ParamKind.CurrentEmployee };
        }

        private static List<QueryDef> Build()
        {
            return new List<QueryDef>
            {

                new QueryDef
                {
                    Code = "U1", Roles = Everyone,
                    Section = ClubSection,
                    Title = "Вільні комп'ютери",
                    Sql = @"
SELECT hall           AS [Зал],
       number         AS [Номер],
       gpu            AS [Відеокарта],
       monitor_hz     AS [Монітор (Гц)],
       price_per_hour AS [Ціна за годину (грн)]
FROM v_FreeComputers
ORDER BY hall, number;"
                },

                new QueryDef
                {
                    Code = "U2", Roles = Everyone,
                    Section = ClubSection,
                    Title = "Де пограти в гру",
                    Sql = @"
SELECT g.title  AS [Гра],
       ge.name  AS [Жанр],
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
ORDER BY g.title, h.name, c.number;"
                },

                new QueryDef
                {
                    Code = "U3", Roles = Everyone,
                    Section = ClubSection,
                    Title = "Каталог ігор",
                    Sql = @"
SELECT g.title     AS [Гра],
       ge.name     AS [Жанр],
       g.age_limit AS [Вікове обмеження],
       (SELECT COUNT(*) FROM ComputerGame cg WHERE cg.game_id = g.game_id) AS [Встановлено на ПК]
FROM Game g
JOIN Genre ge ON ge.genre_id = g.genre_id
ORDER BY ge.name, g.title;"
                },

                new QueryDef
                {
                    Code = "U4", Roles = Everyone, ShowFilter = false,
                    Section = ClubSection,
                    Title = "Калькулятор вартості",
                    Sql = @"
SELECT h.name             AS [Зал],
       t.name             AS [Тариф],
       t.hours            AS [Годин],
       t.discount_percent AS [Знижка (%)],
       h.price_per_hour * t.hours AS [Без знижки (грн)],
       CAST(h.price_per_hour * t.hours * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2)) AS [До сплати (грн)],
       CAST(h.price_per_hour * (100 - t.discount_percent) / 100.0 AS DECIMAL(8,2))           AS [За годину (грн)]
FROM Hall h
CROSS JOIN Tariff t
ORDER BY h.name, [До сплати (грн)];"
                },

                new QueryDef
                {
                    Code = "U5", Roles = Everyone, ShowFilter = false,
                    Section = ClubSection,
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
                    Section = ClubSection,
                    Title = "Мої сесії",
                    Params = { CurrentClient(), OptDate("from", "З"), OptDate("to", "По") },
                    Procedure = "sp_GetSessions"
                },

                new QueryDef
                {
                    Code = "S1", Roles = Staff, ShowFilter = false, IsAction = true, AutoRun = false,
                    Section = ShiftSection,
                    Title = "Почати сесію",
                    Params =
                    {
                        Look("client_id", "Клієнт", Lookups.Clients, false, null, 230),
                        Look("computer_id", "Вільний комп'ютер", Lookups.FreeComputers, false, null, 260),
                        Look("tariff_id", "Тариф", Lookups.Tariffs, false, () => 1, 130),
                        new QueryParam
                        {
                            Name = "game_id", Caption = "Гра", Kind = ParamKind.Lookup,
                            Source = Lookups.Games, Required = false, Width = 180
                        },
                        CurrentEmployee()
                    },
                    Procedure = "sp_StartSession",
                    Output = "session_id",
                    ConfirmText = "Почати сесію?",
                    SuccessText = "Сесію № {2} розпочато.",
                    ResultSql = @"
SELECT client        AS [Клієнт],
       computer      AS [Комп'ютер],
       tariff        AS [Тариф],
       game          AS [Гра],
       started_at    AS [Початок],
       current_price AS [Набіжало (грн)],
       balance       AS [Баланс (грн)]
FROM v_ActiveSessions
WHERE session_id = @session_id;"
                },

                new QueryDef
                {
                    Code = "S2", Roles = Staff, ShowFilter = false, IsAction = true, AutoRun = false,
                    Section = ShiftSection,
                    Title = "Завершити сесію",
                    Params =
                    {
                        Look("session_id", "Сесія", Lookups.ActiveSessions, false, null, 300),
                        Dec("pay_amount", "Доплата (грн)", 0, 0, 10000),
                        Look("method", "Спосіб оплати", Lookups.PayMethods, false, () => "Готівка", 110),
                        CurrentEmployee()
                    },
                    PreviewSql = @"
SELECT client        AS [Клієнт],
       computer      AS [Комп'ютер],
       tariff        AS [Тариф],
       started_at    AS [Початок],
       minutes       AS [Хвилин],
       current_price AS [До сплати (грн)],
       balance       AS [На рахунку (грн)],
       @pay_amount   AS [Доплата (грн)],
       CASE WHEN current_price > balance + @pay_amount
            THEN current_price - balance - @pay_amount ELSE 0 END AS [Не вистачає (грн)]
FROM v_ActiveSessions
WHERE session_id = @session_id;",
                    Procedure = "sp_CloseSession",
                    Output = "total_price",
                    OutputType = SqlDbType.Decimal,
                    ConfirmText = "Завершити сесію й списати оплату?",
                    SuccessText = "Сесію завершено. Сплачено {2:N2} грн.",
                    ResultSql = @"
SELECT d.client      AS [Клієнт],
       d.computer    AS [Комп'ютер],
       d.started_at  AS [Початок],
       d.ended_at    AS [Завершення],
       d.minutes     AS [Хвилин],
       d.total_price AS [Сплачено (грн)],
       c.balance     AS [Залишок (грн)]
FROM v_SessionDetails d
JOIN Client c ON c.client_id = d.client_id
WHERE d.session_id = @session_id;"
                },

                new QueryDef
                {
                    Code = "S3", Roles = Staff, ShowFilter = false, IsAction = true, AutoRun = false,
                    Section = ShiftSection,
                    Title = "Поповнити рахунок",
                    Params =
                    {
                        Look("client_id", "Клієнт", Lookups.Clients, false, null, 230),
                        Dec("amount", "Сума (грн)", 100, 1, 10000),
                        Look("method", "Спосіб оплати", Lookups.PayMethods, false, () => "Готівка", 110),
                        CurrentEmployee()
                    },
                    Procedure = "sp_TopUp",
                    Output = "deposit_id",
                    ConfirmText = "Зарахувати поповнення?",
                    SuccessText = "Рахунок поповнено. Квитанція D-{2:000000}.",
                    ResultSql = @"
SELECT dbo.fn_FullName(last_name, first_name) AS [Клієнт],
       phone   AS [Телефон],
       balance AS [Баланс (грн)]
FROM Client
WHERE client_id = @client_id;"
                },

                new QueryDef
                {
                    Code = "M1", Roles = Staff, ShowFilter = false,
                    Section = ShiftSection,
                    Title = "Хто зараз грає",
                    Sql = @"
SELECT client        AS [Клієнт],
       phone         AS [Телефон],
       computer      AS [Комп'ютер],
       game          AS [Гра],
       tariff        AS [Тариф],
       started_at    AS [Початок],
       minutes       AS [Грає (хв)],
       current_price AS [Набіжало (грн)],
       balance       AS [Баланс (грн)],
       CASE WHEN balance < current_price THEN N'Не вистачає' ELSE N'' END AS [Увага]
FROM v_ActiveSessions
ORDER BY started_at;"
                },

                new QueryDef
                {
                    Code = "M4", Roles = Staff, ShowFilter = false,
                    Section = ShiftSection,
                    Title = "Рух коштів клієнта",
                    Params = { Look("client_id", "Клієнт", Lookups.Clients, false, null, 230) },
                    AutoRun = false,
                    Sql = @"
SELECT op_date       AS [Дата],
       operation     AS [Операція],
       details       AS [Деталі],
       amount        AS [Сума (грн)],
       balance_after AS [Залишок (грн)]
FROM dbo.fn_ClientStatement(@client_id)
ORDER BY op_date DESC;"
                },

                new QueryDef
                {
                    Code = "M7", Roles = Staff, ShowFilter = false, IsAction = true, AutoRun = false,
                    Section = ShiftSection,
                    Title = "Реєстрація клієнта",
                    Params =
                    {
                        Txt("last", "Прізвище", true, 150),
                        Txt("first", "Ім'я", true, 150),
                        Phone("phone", "Телефон"),
                        OptDate("birth", "Дата народження")
                    },
                    ConfirmText = "Зареєструвати нового клієнта?",
                    SuccessText = "Клієнта зареєстровано (код {2}). Логін і пароль для входу: його номер телефону.",
                    Procedure = "sp_RegisterClient",
                    Output = "client_id",
                    ResultSql = @"
SELECT c.client_id     AS [Код],
       c.last_name     AS [Прізвище],
       c.first_name    AS [Ім'я],
       c.phone         AS [Телефон],
       ua.login        AS [Логін],
       c.registered_at AS [Зареєстрований]
FROM Client c
JOIN UserAccount ua ON ua.user_id = c.user_id
WHERE c.client_id = @client_id;"
                },

                new QueryDef
                {
                    Code = "A3", Roles = AdminOnly,
                    Section = AdminSection,
                    Title = "Завантаженість комп'ютерів",
                    Params = { DateP("from", "З", -30), DateP("to", "По", 0) },
                    Sql = @"
SELECT h.name   AS [Зал],
       c.number AS [Номер],
       c.gpu    AS [Відеокарта],
       c.status AS [Статус],
       COUNT(s.session_id) AS [Сесій],
       CAST(ISNULL(SUM(DATEDIFF(MINUTE, s.started_at, ISNULL(s.ended_at, GETDATE()))), 0) / 60.0 AS DECIMAL(10,1)) AS [Годин],
       ISNULL(SUM(s.total_price), 0) AS [Виручка (грн)]
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
                    Section = AdminSection,
                    Title = "Найкращі клієнти",
                    Sql = @"
SELECT dbo.fn_FullName(c.last_name, c.first_name) AS [Клієнт],
       c.phone            AS [Телефон],
       dbo.fn_Age(c.birth_date, CAST(GETDATE() AS DATE)) AS [Вік],
       COUNT(*)           AS [Сесій],
       SUM(s.total_price) AS [Витрачено (грн)],
       c.balance          AS [Баланс (грн)]
FROM Client c
JOIN Session s ON s.client_id = c.client_id
WHERE s.total_price IS NOT NULL
GROUP BY c.client_id, c.last_name, c.first_name, c.phone, c.birth_date, c.balance
HAVING SUM(s.total_price) > (SELECT AVG(t.spent)
                             FROM (SELECT SUM(total_price) AS spent
                                   FROM Session
                                   WHERE total_price IS NOT NULL
                                   GROUP BY client_id) t)
ORDER BY [Витрачено (грн)] DESC;"
                },

                new QueryDef
                {
                    Code = "A5", Roles = AdminOnly, ShowFilter = false,
                    Section = AdminSection,
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
           AND s.started_at >= @from AND s.started_at < DATEADD(DAY, 1, @to)) AS [Сесій на суму (грн)],
       (SELECT COUNT(*) FROM Deposit d
         WHERE d.employee_id = e.employee_id
           AND d.paid_at >= @from AND d.paid_at < DATEADD(DAY, 1, @to))      AS [Поповнень],
       (SELECT ISNULL(SUM(d.amount), 0) FROM Deposit d
         WHERE d.employee_id = e.employee_id
           AND d.paid_at >= @from AND d.paid_at < DATEADD(DAY, 1, @to))      AS [Прийнято коштів (грн)]
FROM Employee e
ORDER BY [Прийнято коштів (грн)] DESC;"
                },

                new QueryDef
                {
                    Code = "A8", Roles = AdminOnly, ShowFilter = false, IsAction = true, AutoRun = false,
                    Section = AdminSection,
                    Title = "Змінити ціни залів",
                    Params =
                    {
                        Look("hall_id", "Зал", Lookups.Halls, true),
                        Dec("percent", "Зміна, %", 10, -50, 100)
                    },
                    PreviewSql = @"
SELECT name           AS [Зал],
       price_per_hour AS [Ціна зараз (грн)],
       ROUND(price_per_hour * (100 + @percent) / 100, 0) AS [Нова ціна (грн)]
FROM Hall
WHERE @hall_id = 0 OR hall_id = @hall_id
ORDER BY name;",
                    ConfirmText = "Змінити ціну в залах: {0}?",
                    SuccessText = "Ціни змінено в залах: {1}.",
                    Procedure = "sp_ChangeHallPrices",
                    ResultSql = @"
SELECT name AS [Зал], price_per_hour AS [Ціна за годину (грн)]
FROM Hall
ORDER BY name;"
                },

                new QueryDef
                {
                    Code = "A9", Roles = AdminOnly,
                    Section = AdminSection,
                    Title = "Журнал змін",
                    Params = { DateP("from", "З", -7), DateP("to", "По", 0) },
                    Sql = @"
SELECT changed_at     AS [Час],
       changed_by     AS [Користувач],
       table_caption  AS [Таблиця],
       action_caption AS [Дія],
       record_id      AS [Код запису],
       record_name    AS [Запис],
       old_values     AS [Було],
       new_values     AS [Стало]
FROM v_ChangeLog
WHERE changed_at >= @from
  AND changed_at < DATEADD(DAY, 1, @to)
ORDER BY log_id DESC;"
                }
            };
        }
    }
}