﻿using System.Collections.Generic;
using LLE = RawSqlHelper.LinqLikeExtension.LinqLikeExtension;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    /// <summary>
    /// Builder for creating parameters for 'ORDER BY' clause
    /// </summary>
    public class OrderByBuilder : AQueryPartBuilder, ISqlQueryBuilderConvertible
    {
        public const string OrderByKey = "ORDER BY";
        private readonly SqlQueryBuilder m_builder;
        private readonly Dictionary<string, OrderDirection> m_columns = new Dictionary<string, OrderDirection>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName"></param>
        /// <param name="direction"></param>
        protected OrderByBuilder(SqlQueryBuilder builder, string columnName, OrderDirection direction)
        {
            m_builder = builder ?? throw new System.ArgumentNullException(nameof(builder));
            Add(columnName, direction);
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
        /// Parameters for 'ORDER BY'
        /// </summary>
        public override string Value => GetColumns();

        /// <summary>
        /// First column sorted with ascending direction
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal static OrderByBuilder OrderBy(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilder(builder, columnName, OrderDirection.Ascending);
        }

        /// <summary>
        /// First column sorted with descending direction
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        internal static OrderByBuilder OrderByDesc(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilder(builder, columnName, OrderDirection.Descending);
        }

        /// <summary>
        /// Following column sorted with ascending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public OrderByBuilder ThenBy(string columnName)
        {
            return Add(columnName, OrderDirection.Ascending);
        }

        /// <summary>
        /// Following column sorted with descending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public OrderByBuilder ThenByDesc(string columnName)
        {
            return Add(columnName, OrderDirection.Descending);
        }

        public SqlQueryBuilder ToSqlQueryBuilder()
        {
            return m_builder.Add(WithKeyword(OrderByKey));
        }

        /// <summary>
        /// Adds column with sorting direction to list
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <param name="direction">Sorting direction</param>
        /// <returns></returns>
        private OrderByBuilder Add(string columnName, OrderDirection direction)
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
            var columns = new List<string>();
            foreach (var columnName in m_columns.Keys)
            {
                columns.Add(GetColumn(columnName, m_columns[columnName]));
            }

            return columns.StringJoin(LLE.CommaSeparator);
        }

        /// <summary>
        /// Creates string value from column name and its sorting direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <param name="direction">Sorting direction</param>
        /// <returns></returns>
        private string GetColumn(string columnName, OrderDirection direction)
        {
            var directionString = direction == OrderDirection.Ascending ? "ASC" : "DESC";
            return $"{columnName} {directionString}";
        }
    }
}
