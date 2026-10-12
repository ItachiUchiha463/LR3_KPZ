using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Club
{
    public static class Captions
    {
        private static readonly Dictionary<string, string> map = new Dictionary<string, string>
        {
            { "Client.client_id", "Код" },
            { "Client.user_id", "Акаунт" },
            { "Client.last_name", "Прізвище" },
            { "Client.first_name", "Ім'я" },
            { "Client.phone", "Телефон" },
            { "Client.birth_date", "Дата народження" },
            { "Client.registered_at", "Дата реєстрації" },
            { "Client.balance", "Баланс (грн)" },

            { "Employee.employee_id", "Код" },
            { "Employee.user_id", "Акаунт" },
            { "Employee.last_name", "Прізвище" },
            { "Employee.first_name", "Ім'я" },
            { "Employee.phone", "Телефон" },
            { "Employee.shift", "Зміна" },

            { "Hall.hall_id", "Код" },
            { "Hall.name", "Назва" },
            { "Hall.price_per_hour", "Ціна за годину (грн)" },

            { "Computer.computer_id", "Код" },
            { "Computer.hall_id", "Зал" },
            { "Computer.number", "Номер" },
            { "Computer.gpu", "Відеокарта" },
            { "Computer.monitor_hz", "Частота монітора (Гц)" },
            { "Computer.status", "Статус" },

            { "Genre.genre_id", "Код" },
            { "Genre.name", "Назва" },

            { "Game.game_id", "Код" },
            { "Game.genre_id", "Жанр" },
            { "Game.title", "Назва" },
            { "Game.age_limit", "Вікове обмеження" },

            { "Tariff.tariff_id", "Код" },
            { "Tariff.name", "Назва" },
            { "Tariff.hours", "Тривалість (год)" },
            { "Tariff.discount_percent", "Знижка (%)" },

            { "Session.session_id", "Код" },
            { "Session.client_id", "Клієнт" },
            { "Session.computer_id", "Комп'ютер" },
            { "Session.employee_id", "Працівник" },
            { "Session.tariff_id", "Тариф" },
            { "Session.game_id", "Гра" },
            { "Session.started_at", "Початок" },
            { "Session.ended_at", "Завершення" },
            { "Session.total_price", "Сума (грн)" },

            { "Deposit.deposit_id", "Код" },
            { "Deposit.client_id", "Клієнт" },
            { "Deposit.employee_id", "Працівник" },
            { "Deposit.amount", "Сума (грн)" },
            { "Deposit.paid_at", "Дата й час" },
            { "Deposit.method", "Спосіб оплати" },

            { "ComputerGame.computer_id", "Комп'ютер" },
            { "ComputerGame.game_id", "Гра" }
        };

        public static string Get(string table, string column)
        {
            string key = table + "." + column;
            return map.ContainsKey(key) ? map[key] : column;
        }
    }
}
