using System;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    public class JoinBuilder : AQueryPartBuilder
    {
        private readonly string m_keyWord;
        private readonly string m_tableName;
        private string m_on;

        private JoinBuilder(bool? isLeft, bool? isInner, string tableName, string alias, bool isSubSelect)
        {
            m_keyWord = CreateKeyword(isLeft, isInner);
            m_tableName = CreateTableWithAlias(tableName, alias, isSubSelect);
        }

        public override string Value => GetValue();

        public static JoinBuilder Join(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(null, null, tableName, alias, isSubSelect);
        }

        public static JoinBuilder LeftJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(true, null, tableName, alias, isSubSelect);
        }

        public static JoinBuilder LeftInnerJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(true, true, tableName, alias, isSubSelect);
        }

        public static JoinBuilder LeftOuterJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(true, false, tableName, alias, isSubSelect);
        }

        public static JoinBuilder RightJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(false, null, tableName, alias, isSubSelect);
        }

        public static JoinBuilder RightInnerJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(false, true, tableName, alias, isSubSelect);
        }

        public static JoinBuilder RightOuterJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(false, false, tableName, alias, isSubSelect);
        }

        public static JoinBuilder InnerJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(null, true, tableName, alias, isSubSelect);
        }

        public static JoinBuilder OuterJoin(string tableName, string alias = null, bool isSubSelect = false)
        {
            return new JoinBuilder(null, false, tableName, alias, isSubSelect);
        }

        private JoinBuilder On(params string[] conditions)
        {
            m_on = conditions.StringJoin(" AND ");
            return this;
        }

        private static string CreateTableWithAlias(string tableName, string alias, bool isSubSelect)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            if (isSubSelect)
            {
                tableName = tableName.Brackets();
            }
            return $"{tableName} {alias}".Trim();
        }

        private static string CreateKeyword(bool? isLeft, bool? isInner)
        {
            var direction = string.Empty;
            if (isLeft.HasValue)
            {
                direction = isLeft.Value ? "LEFT" : "RIGHT";
            }

            var inner = string.Empty;
            if (isInner.HasValue)
            {
                inner = isInner.Value ? "INNER" : "OUTER";
            }

            var keyword = $"{direction} {inner} JOIN";

            return keyword.Trim();
        }

        private string GetValue()
        {
            if(string.IsNullOrEmpty(m_on))
            {
                throw new ArgumentOutOfRangeException(nameof(On), "Condition 'On' is not defined");
            }
            return $"{m_keyWord} {m_tableName} ON {m_on}";
        }
    }
}
