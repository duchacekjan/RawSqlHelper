using System;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    public class JoinBuilder : AQueryPartBuilder, ISqlQueryBuilderConvertible
    {
        public const string JoinKey = "JOIN";
        public const string InnerKey = "INNER";
        public const string OuterKey = "OUTER";
        public const string LeftKey = "LEFT";
        public const string RightKey = "RIGHT";
        public const string OnKey = "ON";
        public const string AndKey = "AND";

        private readonly string m_keyWord;
        private readonly string m_tableName;
        private readonly SqlQueryBuilder m_builder;
        private string m_on;

        internal JoinBuilder(SqlQueryBuilder builder, bool? isLeft, bool? isInner, string tableName, string alias, bool isSubSelect)
        {
            m_builder = builder ?? throw new ArgumentNullException(nameof(builder));
            m_keyWord = CreateKeyword(isLeft, isInner);
            m_tableName = CreateTableWithAlias(tableName, alias, isSubSelect);
        }

        public override string Value => GetValue();

        public JoinBuilder On(params string[] conditions)
        {
            m_on = conditions.StringJoin($" {AndKey} ");
            return this;
        }

        public SqlQueryBuilder ToSqlQueryBuilder()
        {
            return m_builder.Add(Value);
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
                direction = isLeft.Value ? LeftKey : RightKey;
            }

            var inner = string.Empty;
            if (isInner.HasValue)
            {
                inner = isInner.Value ? InnerKey : OuterKey;
            }

            var keyword = $"{direction} {inner} {JoinKey}";

            return keyword.Trim();
        }

        private string GetValue()
        {
            if (string.IsNullOrEmpty(m_on))
            {
                throw new ArgumentOutOfRangeException(nameof(On), $"Condition '{OnKey}' is not defined.");
            }
            return $"{m_keyWord} {m_tableName} {OnKey} {m_on}";
        }
    }
}
