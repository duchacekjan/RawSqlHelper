namespace RawSqlHelper.LinqLikeExtension
{
    public static class LinqLikeExtension
    {
        public const string SelectKey = "SELECT";
        public const string FromKey = "FROM";
        public const string WhereKey = "WHERE";
        public const string OrderByKey = "ORDER BY";
        public const string CommaSeparator = ", ";
        /// <summary>
        /// Adds 'SELECT' statement. If <paramref name="fields"/> is <see langword="null"/> or empty, then '*' value used
        /// </summary>
        /// <param name="fields">Fields to select.</param>
        /// <returns></returns>
        public static SqlQueryBuilder Select(this SqlQueryBuilder builder, params string[] fields)
        {
            if (fields == null || fields.Length == 0)
            {
                fields = new string[] { };
            }
            var parameters = string.Join(CommaSeparator, fields);
            if (string.IsNullOrEmpty(parameters))
            {
                parameters = "*";
            }
            var select = $"{SelectKey} {parameters}";
            return builder.Add(select);
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
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
        /// Adds 'WHERE' statement with <paramref name="condition"/>
        /// </summary>
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

        /// <summary>
        /// Adds 'ORDER BY' statement with <paramref name="column"/>
        /// </summary>
        /// <param name="column">Name of column with direction of sorting</param>
        /// <returns></returns>
        public static SqlQueryBuilder OrderBy(this SqlQueryBuilder builder, string column)
        {
            if (string.IsNullOrEmpty(column))
            {
                throw new System.ArgumentNullException(column);
            }

            var orderBy = $"{OrderByKey} {column}";
            return builder.Add(orderBy);
        }

        /// <summary>
        /// Adds 'ORDER BY' statement with <paramref name="columns"/>
        /// </summary>
        /// <param name="columns">Names of columns with directions of sorting</param>
        /// <returns></returns>
        public static SqlQueryBuilder OrderBy(this SqlQueryBuilder builder, params string[] columns)
        {
            var statement = string.Join(CommaSeparator, columns);
            return builder.OrderBy(statement);
        }
    }
}
