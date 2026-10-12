using System.Collections.Generic;
using System.Linq;

namespace PC_Club
{
    public class ReportDef
    {
        public string Code;
        public string Title;
        public string DataSetName;
        public string Sql;
        public UserRole[] Roles;
        public int DefaultDays = 30;

        public string Resource
        {
            get { return "PC_Club.Reports." + Code + ".rdlc"; }
        }
    }

    public static class ReportCatalog
    {
        private static readonly UserRole[] Staff = { UserRole.Manager, UserRole.Admin };
        private static readonly UserRole[] AdminOnly = { UserRole.Admin };

        public static readonly List<ReportDef> All = new List<ReportDef>
        {
            new ReportDef
            {
                Code = "RevenueByDay", Roles = AdminOnly,
                Title = "Виручка за період",
                DataSetName = "Sessions",
                Sql = @"
SELECT CAST(ended_at AS DATE) AS SessionDate,
       hall                   AS Hall,
       hours                  AS Hours,
       total_price            AS TotalPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);"
            },

            new ReportDef
            {
                Code = "RevenueByHall", Roles = AdminOnly,
                Title = "Виручка по залах",
                DataSetName = "Sessions",
                Sql = @"
SELECT hall                             AS Hall,
       DATEDIFF(DAY, 0, ended_at) % 7   AS DayOfWeek,
       CHOOSE(DATEDIFF(DAY, 0, ended_at) % 7 + 1,
              N'Пн', N'Вт', N'Ср', N'Чт', N'Пт', N'Сб', N'Нд') AS DayName,
       hours                            AS Hours,
       total_price                      AS TotalPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);"
            },

            new ReportDef
            {
                Code = "DepositsByEmployee", Roles = Staff,
                Title = "Поповнення по працівниках",
                DataSetName = "Deposits",
                Sql = @"
SELECT paid_at  AS PaidAt,
       employee AS Employee,
       method   AS Method,
       client   AS Client,
       amount   AS Amount
FROM v_DepositDetails
WHERE paid_at >= @from
  AND paid_at < DATEADD(DAY, 1, @to);"
            }
        };

        public static ReportDef Get(string code)
        {
            return All.FirstOrDefault(r => r.Code == code);
        }
    }
}
