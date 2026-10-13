using System;
using System.Data;
using System.Data.SqlClient;

namespace PC_Club
{
    public static class Errors
    {
        public static string Friendly(Exception ex)
        {
            for (Exception e = ex; e != null; e = e.InnerException)
            {
                var sql = e as SqlException;
                if (sql != null) return FromSql(sql);
            }

            if (ex is NoNullAllowedException) return "Не заповнено обов'язкове поле.";
            if (ex is ConstraintException) return "Такий запис уже існує.";
            if (ex is DBConcurrencyException)
                return "Запис змінено або видалено в іншому місці. Закрийте форму й відкрийте її знову.";
            return ex.Message;
        }

        private static string FromSql(SqlException e)
        {
            string text = e.Message;
            switch (e.Number)
            {
                case 547:
                    if (text.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0)
                        return "Не можна видалити запис: він використовується в інших таблицях " +
                               "(наприклад, є пов'язані сесії чи поповнення).";
                    if (text.IndexOf("CHECK", StringComparison.OrdinalIgnoreCase) >= 0)
                        return "Значення виходить за допустимі межі: баланс не може бути від'ємним, " +
                               "сума поповнення має бути більшою за 0, знижка від 0 до 100%.";
                    return "Вказано пов'язане значення, якого не існує. Виберіть його зі списку.";

                case 2601:
                case 2627:
                    return "Такий запис уже існує: значення має бути унікальним.";

                case 515:
                    return "Не заповнено обов'язкове поле.";

                case 2628:
                case 8152:
                    return "Текст задовгий для цього поля.";

                case 220:
                case 8115:
                    return "Число занадто велике для цього поля.";

                case 241:
                case 242:
                case 245:
                case 8114:
                    return "Значення має неправильний формат.";

                case -2:
                    return "Сервер не відповів вчасно. Спробуйте ще раз.";

                case -1:
                case 2:
                case 53:
                case 233:
                case 10060:
                case 10061:
                    return "Немає зв'язку з сервером бази даних. Перевірте, чи запущено SQL Server.";

                case 4060:
                case 18456:
                    return "Не вдалося увійти в базу даних: перевірте логін і пароль у рядку підключення.";
                case 50010:
                    return text;

                default:
                    return "Помилка бази даних: " + text;
            }
        }
    }
}