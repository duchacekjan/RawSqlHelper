namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    public class JoinBuilderEx : JoinBuilder
    {
        private readonly SqlQueryBuilder m_builder;

        internal JoinBuilderEx(SqlQueryBuilder builder, bool? isLeft, bool? isInner, string tableName, string alias, bool isSubSelect)
            : base(isLeft, isInner, tableName, alias, isSubSelect)
        {
            m_builder = builder;
        }

        public new JoinBuilderEx On(params string[] conditions)
        {
            base.On(conditions);
            return this;
        }

        public SqlQueryBuilder ToSqlQueryBuilder()
        {
            return m_builder.Add(Value);
        }
    }
}
