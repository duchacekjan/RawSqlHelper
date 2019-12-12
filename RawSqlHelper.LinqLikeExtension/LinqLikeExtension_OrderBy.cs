using System;
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
        public static SqlQueryBuilder OrderByRaw(this SqlQueryBuilder builder, params string[] columns)
        {
            var statement = string.Join(CommaSeparator, columns);
            return builder.Add($"{OrderByKey} {statement}");
        }

        /// <summary>
        /// Ascending order by column
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public static SqlQueryBuilder OrderBy(this SqlQueryBuilder builder, string columnName)
        {
            return e.OrderByBuilder.OrderBy(builder, columnName);
        }

        /// <summary>
        /// Descending order by column
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        /// <returns></returns>
        public static SqlQueryBuilder OrderByDesc(this SqlQueryBuilder builder, string columnName)
        {
            return e.OrderByBuilder.OrderByDesc(builder, columnName);
        }

        /// <summary>
        /// Ascending order by next column
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public static SqlQueryBuilder ThenBy(this SqlQueryBuilder builder, string columnName)
        {
            if (builder is e.OrderByBuilder orderBuilder)
            {
                return orderBuilder.ThenBy(columnName);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Descending order by next column
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public static SqlQueryBuilder ThenByDesc(this SqlQueryBuilder builder, string columnName)
        {
            if (builder is e.OrderByBuilder orderBuilder)
            {
                return orderBuilder.ThenByDesc(columnName);
            }

            throw new NotSupportedException();
        }
    }
}
