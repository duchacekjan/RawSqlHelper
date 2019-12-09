using e = RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        public const string OrderByKey = "ORDER BY";

        /// <summary>
        /// Adds 'ORDER BY' statement with <paramref name="columns"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columns">Names of columns with directions of sorting</param>
        /// <returns></returns>
        public static SqlQueryBuilder OrderBy(this SqlQueryBuilder builder, params string[] columns)
        {
            var statement = string.Join(CommaSeparator, columns);
            return builder.Add($"{OrderByKey} {statement}");
        }

        /// <summary>
        /// Adds 'ORDER BY' statement with parameters created in <paramref name="orderByBuilder"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="orderByBuilder">Parameter builder</param>
        /// <returns></returns>
        public static SqlQueryBuilder OrderBy(this SqlQueryBuilder builder, e.OrderByBuilder orderByBuilder)
        {
            if (orderByBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(orderByBuilder));
            }

            var orderBy = orderByBuilder.WithKeyword(OrderByKey);
            return builder.Add(orderBy);
        }

        public static e.OrderByBuilder OrderBy(this SqlQueryBuilder builder, string columnName)
        {
            return e.OrderByBuilder.OrderBy(builder, columnName);
        }

        public static e.OrderByBuilder OrderByDesc(this SqlQueryBuilder builder, string columnName)
        {
            return e.OrderByBuilder.OrderByDesc(builder, columnName);
        }
    }
}
