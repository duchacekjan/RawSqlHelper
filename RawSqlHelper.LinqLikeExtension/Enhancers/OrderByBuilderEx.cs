namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    public class OrderByBuilderEx : OrderByBuilder, ISqlQueryBuilderConvertible
    {
        public const string OrderByKey = "ORDER BY";
        private readonly SqlQueryBuilder m_builder;

        private OrderByBuilderEx(SqlQueryBuilder builder, string columnName, OrderDirection direction)
            : base(columnName, direction)
        {
            m_builder = builder;
        }

        public static OrderByBuilderEx OrderByEx(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilderEx(builder, columnName, OrderDirection.Ascending);
        }

        public static OrderByBuilderEx OrderByDescEx(SqlQueryBuilder builder, string columnName)
        {
            return new OrderByBuilderEx(builder, columnName, OrderDirection.Descending);
        }

        /// <summary>
        /// Following column sorted with ascending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public new OrderByBuilderEx ThenBy(string columnName)
        {
            base.ThenBy(columnName);
            return this;
        }

        /// <summary>
        /// Following column sorted with descending direction
        /// </summary>
        /// <param name="columnName">Name of column</param>
        /// <returns></returns>
        public new OrderByBuilderEx ThenByDesc(string columnName)
        {
            base.ThenByDesc(columnName);
            return this;
        }

        public SqlQueryBuilder ToSqlQueryBuilder()
        {
            return m_builder.Add(WithKeyword(OrderByKey));
        }
    }
}
