using System;
using System.Collections.Generic;
using System.Data;

namespace PC_Club
{
    public enum ParamKind
    {
        Text,
        Int,
        Decimal,
        Date,
        OptionalDate,
        Phone,
        Lookup,
        CurrentClient
    }

    public class QueryParam
    {
        public string Name;
        public string Caption;
        public ParamKind Kind;
        public Func<object> Default;
        public Func<DataTable> Source;
        public bool AllOption;
        public decimal Min = 0;
        public decimal Max = 100000;
        public bool Required = true;
        public int Width = 150;
    }

    public class QueryDef
    {
        public string Code;
        public string Title;
        public string Section;
        public string Sql;
        public UserRole[] Roles;
        public List<QueryParam> Params = new List<QueryParam>();

        public bool AutoRun = true;
        public bool ShowFilter = true;

        public bool IsAction;
        public string PreviewSql;
        public string ConfirmText;
        public string SuccessText;
        public string ResultSql;
    }
}