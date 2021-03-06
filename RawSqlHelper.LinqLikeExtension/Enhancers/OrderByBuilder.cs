﻿using System.Collections.Generic;
using LLE = RawSqlHelper.LinqLikeExtension.LinqLikeExtension;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    internal class OrderByBuilder : LinqLikeBuilder
    {
        internal const string OrderByKey = "ORDER BY";
        private readonly Dictionary<string, OrderDirection> m_columns = new Dictionary<string, OrderDirection>();

        protected OrderByBuilder(SqlQueryBuilder builder, string columnName, OrderDirection direction)
            : base(builder)
        {
            AddColumn(columnName, direction);
        }

        /// <summary>
        /// Direction of ordering
        /// </summary>
        protected enum OrderDirection
        {
            /// <summary>
            /// Ascending order
            /// </summary>
            Ascending,

            /// <summary>
            /// Descending order
            /// </summary>
            Descending
        }

        /// <summary>
        /// First column sorted with ascending direction
        /// </summary>
        /// <param name="builder">SQL query builder</param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal static LinqLikeBuilder OrderBy(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilder(builder, columnName, OrderDirection.Ascending);
        }

        /// <summary>
        /// First column sorted with descending direction
        /// </summary>
        /// <param name="builder">SQL query builder</param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal static LinqLikeBuilder OrderByDesc(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilder(builder, columnName, OrderDirection.Descending);
        }

        /// <summary>
        /// Following column sorted with ascending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal LinqLikeBuilder ThenBy(string columnName)
        {
            return AddColumn(columnName, OrderDirection.Ascending);
        }

        /// <summary>
        /// Following column sorted with descending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal LinqLikeBuilder ThenByDesc(string columnName)
        {
            return AddColumn(columnName, OrderDirection.Descending);
        }

        /// <summary>
        /// Creates 'ORDER BY' statement
        /// </summary>
        /// <returns></returns>
        protected override string GetPartQuery()
        {
            var columns = GetColumns();
            if (string.IsNullOrEmpty(columns))
            {
                throw new RequiredPartNotDefinedException(OrderByKey);
            }

            return $"{OrderByKey} {columns}";
        }

        /// <summary>
        /// Creates string value from column name and its sorting direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <param name="direction">Sorting direction</param>
        /// <returns></returns>
        private static string GetColumn(string columnName, OrderDirection direction)
        {
            var directionString = direction == OrderDirection.Ascending ? "ASC" : "DESC";
            return $"{columnName} {directionString}";
        }

        /// <summary>
        /// Adds column with sorting direction to list
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <param name="direction">Sorting direction</param>
        /// <returns></returns>
        private OrderByBuilder AddColumn(string columnName, OrderDirection direction)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new System.ArgumentNullException(columnName);
            }

            m_columns.Add(columnName, direction);
            return this;
        }

        /// <summary>
        /// Methods joins all columns with their direction to string values
        /// which are separated by comma
        /// </summary>
        /// <returns></returns>
        private string GetColumns()
        {
            //TODO Optimize. ASC or DESC is not necessary when all is same
            var columns = new List<string>();
            foreach (var columnName in m_columns.Keys)
            {
                columns.Add(GetColumn(columnName, m_columns[columnName]));
            }

            return columns.StringJoin(LLE.CommaSeparator);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
