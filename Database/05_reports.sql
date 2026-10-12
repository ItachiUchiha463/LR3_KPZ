/* Скрипт 5. Дані для звітів (ПР5)
   Звіти будуються в програмі (RDLC), а ці запити дають їм рядки.
   Групування, підсумки й діаграми рахує сам звіт, тому запити повертають
   окремі сесії чи поповнення без GROUP BY.
   Назви колонок англійською: за ними звіт знаходить поля свого набору даних. */

USE PCClub;
GO

DECLARE @from DATE = DATEADD(DAY, -30, CAST(GETDATE() AS DATE)), @to DATE = CAST(GETDATE() AS DATE);

-- 1. Виручка за період (набір даних Sessions)
SELECT CAST(ended_at AS DATE) AS SessionDate,
       hall                   AS Hall,
       hours                  AS Hours,
       total_price            AS TotalPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);

-- 2. Виручка по залах (набір даних Sessions)
SELECT hall                             AS Hall,
       DATEDIFF(DAY, 0, ended_at) % 7   AS DayOfWeek,
       CHOOSE(DATEDIFF(DAY, 0, ended_at) % 7 + 1,
              N'Пн', N'Вт', N'Ср', N'Чт', N'Пт', N'Сб', N'Нд') AS DayName,
       hours                            AS Hours,
       total_price                      AS TotalPrice
FROM v_SessionDetails
WHERE total_price IS NOT NULL
  AND ended_at >= @from
  AND ended_at < DATEADD(DAY, 1, @to);

-- 3. Поповнення по працівниках (набір даних Deposits)
SELECT paid_at  AS PaidAt,
       employee AS Employee,
       method   AS Method,
       client   AS Client,
       amount   AS Amount
FROM v_DepositDetails
WHERE paid_at >= @from
  AND paid_at < DATEADD(DAY, 1, @to);
GO
