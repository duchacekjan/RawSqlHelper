using e = RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtensions
    {
        #region Join
        public static SqlQueryBuilder Join(this SqlQueryBuilder builder, e.JoinBuilder joinBuilder)
        {
            return builder.Add(joinBuilder);
        }
        public static e.JoinBuilderEx Join(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, null, tableName, null, false);
        }
        public static e.JoinBuilderEx Join(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, null, tableName, alias, false);
        }
        public static e.JoinBuilderEx JoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, null, tableName, null, true);
        }
        public static e.JoinBuilderEx JoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, null, tableName, alias, true);
        }
        #endregion
        #region LeftJoin
        public static e.JoinBuilderEx LeftJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, null, tableName, null, false);
        }

        public static e.JoinBuilderEx LeftJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, null, tableName, alias, false);
        }

        public static e.JoinBuilderEx LeftJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, null, tableName, null, true);
        }

        public static e.JoinBuilderEx LeftJoinSubSelect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, null, tableName, alias, true);
        }
        #endregion
        #region LeftInnerJoin
        public static e.JoinBuilderEx LeftInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, true, tableName, null, false);
        }
        public static e.JoinBuilderEx LeftInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, true, tableName, alias, false);
        }
        public static e.JoinBuilderEx LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, true, tableName, null, true);
        }
        public static e.JoinBuilderEx LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, true, tableName, alias, true);
        }
        #endregion
        #region LegtOuterJoin
        public static e.JoinBuilderEx LeftOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, false, tableName, null, false);
        }
        public static e.JoinBuilderEx LeftOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, false, tableName, alias, false);
        }
        public static e.JoinBuilderEx LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, true, false, tableName, null, true);
        }
        public static e.JoinBuilderEx LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, true, false, tableName, alias, true);
        }
        #endregion
        #region RightJoin
        public static e.JoinBuilderEx RightJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, null, tableName, null, false);
        }
        public static e.JoinBuilderEx RightJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, null, tableName, alias, false);
        }
        public static e.JoinBuilderEx RightJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, null, tableName, null, true);
        }
        public static e.JoinBuilderEx RightJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, null, tableName, alias, true);
        }
        #endregion
        #region RightInnerJoin
        public static e.JoinBuilderEx RightInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, true, tableName, null, false);
        }
        public static e.JoinBuilderEx RightInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, true, tableName, alias, false);
        }
        public static e.JoinBuilderEx RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, true, tableName, null, true);
        }
        public static e.JoinBuilderEx RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, true, tableName, alias, true);
        }
        #endregion
        #region RightOuterJoin
        public static e.JoinBuilderEx RightOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, false, tableName, null, false);
        }
        public static e.JoinBuilderEx RightOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, false, tableName, alias, false);
        }
        public static e.JoinBuilderEx RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, false, false, tableName, null, true);
        }
        public static e.JoinBuilderEx RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, false, false, tableName, alias, true);
        }
        #endregion
        #region InnerJoin
        public static e.JoinBuilderEx InnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, true, tableName, null, false);
        }
        public static e.JoinBuilderEx InnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, true, tableName, alias, false);
        }
        public static e.JoinBuilderEx InnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, true, tableName, null, true);
        }
        public static e.JoinBuilderEx InnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, true, tableName, alias, true);
        }
        #endregion
        #region OuterJoin
        public static e.JoinBuilderEx OuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, false, tableName, null, false);
        }
        public static e.JoinBuilderEx OuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, false, tableName, alias, false);
        }
        public static e.JoinBuilderEx OuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilderEx(builder, null, false, tableName, null, true);
        }
        public static e.JoinBuilderEx OuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilderEx(builder, null, false, tableName, alias, true);
        }
        #endregion
    }
}
