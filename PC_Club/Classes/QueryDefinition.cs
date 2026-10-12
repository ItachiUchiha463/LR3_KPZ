using System;
using System.Collections.Generic;
using System.Data;

namespace PC_Club
{
    // Вид поля параметра у формі запиту
    public enum ParamKind
    {
        Text,           // TextBox
        Int,            // NumericUpDown без дробової частини
        Decimal,        // NumericUpDown з двома знаками
        Date,           // DateTimePicker
        OptionalDate,   // DateTimePicker з галочкою (без галочки передається NULL)
        Phone,          // MaskedTextBox з маскою телефону, передаються лише цифри
        Lookup,         // ComboBox зі списку id / text (клієнти, зали, ...)
        CurrentClient   // поля немає: береться код клієнта, який увійшов
    }

    // Один параметр запиту
    public class QueryParam
    {
        public string Name;              // ім'я параметра в SQL без @
        public string Caption;           // підпис над полем
        public ParamKind Kind;
        public Func<object> Default;     // значення за замовчуванням (може бути null)
        public Func<DataTable> Source;   // для Lookup: таблиця з колонками id і text
        public bool AllOption;           // для Lookup: додати першим пункт «Усі» з кодом 0
        public decimal Min = 0;          // для Int і Decimal
        public decimal Max = 100000;
        public bool Required = true;     // для Text, Phone, Lookup: чи можна лишити порожнім
        public int Width = 150;          // ширина поля
    }

    // Опис одного запиту з каталогу
    public class QueryDef
    {
        public string Code;              // U1, M4, A7 ...
        public string Title;
        public string Sql;
        public UserRole[] Roles;         // кому доступний
        public List<QueryParam> Params = new List<QueryParam>();

        public bool AutoRun = true;      // виконати одразу при відкритті форми
        public bool ShowFilter = true;

        // Лише для запитів на дію (INSERT / UPDATE / DELETE)
        public bool IsAction;
        public string PreviewSql;        // що буде змінено: показується до виконання
        public string ConfirmText;       // {0} = кількість рядків попереднього перегляду
        public string SuccessText;       // {0} = змінено записів, {1} = кількість рядків попереднього перегляду
        public string ResultSql;         // що показати після виконання
    }
}