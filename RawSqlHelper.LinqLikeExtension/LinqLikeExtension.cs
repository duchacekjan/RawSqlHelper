namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        public const string SelectKey = "SELECT";
        public const string FromKey = "FROM";
        public const string WhereKey = "WHERE";
        public const string CommaSeparator = ", ";

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="tableName">Table name for 'FROM' clause</param>
        /// <returns></returns>
        public static SqlQueryBuilder From(this SqlQueryBuilder builder, string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new System.ArgumentNullException(nameof(tableName));
            }

            var from = $"{FromKey} {tableName}";
            return builder.Add(from);
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="subselect">Subselect for 'FROM' clause</param>
        /// <returns></returns>
        public static SqlQueryBuilder FromSubselect(this SqlQueryBuilder builder, string subselect)
        {
            if (string.IsNullOrEmpty(subselect))
            {
                throw new System.ArgumentNullException(nameof(subselect));
            }

            var from = $"{FromKey} {subselect.Brackets()}";
            return builder.Add(from);
        }

        /// <summary>
        /// Adds 'WHERE' statement with <paramref name="condition"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="condition">Condition added to 'WHERE' clause</param>
        /// <returns></returns>
        public static SqlQueryBuilder Where(this SqlQueryBuilder builder, string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                throw new System.ArgumentNullException(condition);
            }

            var where = $"{WhereKey} {condition}";
            return builder.Add(where);
        }
    }
}
