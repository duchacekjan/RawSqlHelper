using System.Collections.Generic;

namespace RawSqlHelper.Enhancers.LinqLikeExtension
{
    /// <summary>
    /// Builder for creating parameters for 'ORDER BY' clause
    /// </summary>
    public class OrderByBuilder
    {
        private readonly Dictionary<string, OrderDirection> m_columns = new Dictionary<string, OrderDirection>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="direction"></param>
        private OrderByBuilder(string columnName, OrderDirection direction)
        {
            Add(columnName, direction);
        }

        /// <summary>
        /// Direction of ordering
        /// </summary>
        private enum OrderDirection
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
        public string Columns => GetColumns();

        /// <summary>
        /// First column sorted with ascending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public static OrderByBuilder OrderBy(string columnName)
        {
            return new OrderByBuilder(columnName, OrderDirection.Ascending);
        }

        /// <summary>
        /// First column sorted with descending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public static OrderByBuilder OrderByDesc(string columnName)
        {
            return new OrderByBuilder(columnName, OrderDirection.Descending);
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

        /// <summary>
        /// Returns <see cref="Columns"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Columns;
        }

        /// <summary>
        /// Adds column with sorting direction to list
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <param name="direction">Sorting direction</param>
        /// <returns></returns>
        private OrderByBuilder Add(string columnName, OrderDirection direction)
        {
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

            return columns.StringJoin(LinqLikeExtension.CommaSeparator);
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
