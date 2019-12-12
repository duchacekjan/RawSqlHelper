using System;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    /// <summary>
    /// Builder for 'JOIN' clause
    /// </summary>
    internal class JoinBuilder : LinqLikeBuilder
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
        private string m_on;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="isLeft"></param>
        /// <param name="isInner"></param>
        /// <param name="tableName"></param>
        /// <param name="alias"></param>
        /// <param name="isSubSelect"></param>
        internal JoinBuilder(SqlQueryBuilder builder, bool? isLeft, bool? isInner, string tableName, string alias, bool isSubSelect)
            : base(builder)
        {
            m_keyWord = CreateKeyword(isLeft, isInner);
            m_tableName = CreateTableWithAlias(tableName, alias, isSubSelect);
        }

        /// <summary>
        /// Conditions for 'ON' part of 'JOIN' clause
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        internal LinqLikeBuilder On(params string[] conditions)
        {
            m_on = conditions.StringJoin($" {AndKey} ");
            return this;
        }

        /// <summary>
        /// Creates 'ORDER BY' statement
        /// </summary>
        /// <returns></returns>
        protected override string GetPartQuery()
        {
            if (string.IsNullOrEmpty(m_on))
            {
                throw new RequiredPartNotDefinedException(OnKey);
            }

            return $"{m_keyWord} {m_tableName} {OnKey} {m_on}";
        }

        /// <summary>
        /// Creates name of table (subselect) which will be joined
        /// </summary>
        /// <param name="tableName">Table name or subselect</param>
        /// <param name="alias">Alias for table or subselect</param>
        /// <param name="isSubSelect">Mark, that <paramref name="tableName"/> is subselect</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates correct 'JOIN' keyword
        /// </summary>
        /// <param name="isLeft">Mark, that 'JOIN' is 'LEFT'</param>
        /// <param name="isInner">Mark, tht 'JOIN' is 'INNER'</param>
        /// <returns></returns>
        /// <remarks>
        /// <see langword="null"/> in parameters marks, that that keyword is ommitted
        /// </remarks>
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

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
