using e = RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        #region Join
        public static SqlQueryBuilder Join(this SqlQueryBuilder builder, e.JoinBuilder joinBuilder)
        {
            return builder.Add(joinBuilder);
        }
        public static e.JoinBuilder Join(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, false);
        }
        public static e.JoinBuilder Join(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, false);
        }
        public static e.JoinBuilder JoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, true);
        }
        public static e.JoinBuilder JoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, true);
        }
        #endregion
        #region LeftJoin
        public static e.JoinBuilder LeftJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, false);
        }

        public static e.JoinBuilder LeftJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, false);
        }

        public static e.JoinBuilder LeftJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, true);
        }

        public static e.JoinBuilder LeftJoinSubSelect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, true);
        }
        #endregion
        #region LeftInnerJoin
        public static e.JoinBuilder LeftInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, false);
        }
        public static e.JoinBuilder LeftInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, false);
        }
        public static e.JoinBuilder LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, true);
        }
        public static e.JoinBuilder LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, true);
        }
        #endregion
        #region LeftOuterJoin
        public static e.JoinBuilder LeftOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, false);
        }
        public static e.JoinBuilder LeftOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, false);
        }
        public static e.JoinBuilder LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, true);
        }
        public static e.JoinBuilder LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, true);
        }
        #endregion
        #region RightJoin
        public static e.JoinBuilder RightJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, false);
        }
        public static e.JoinBuilder RightJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, false);
        }
        public static e.JoinBuilder RightJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, true);
        }
        public static e.JoinBuilder RightJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, true);
        }
        #endregion
        #region RightInnerJoin
        public static e.JoinBuilder RightInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, false);
        }
        public static e.JoinBuilder RightInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, false);
        }
        public static e.JoinBuilder RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, true);
        }
        public static e.JoinBuilder RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, true);
        }
        #endregion
        #region RightOuterJoin
        public static e.JoinBuilder RightOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, false);
        }
        public static e.JoinBuilder RightOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, false);
        }
        public static e.JoinBuilder RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, true);
        }
        public static e.JoinBuilder RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, true);
        }
        #endregion
        #region InnerJoin
        public static e.JoinBuilder InnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, false);
        }
        public static e.JoinBuilder InnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, false);
        }
        public static e.JoinBuilder InnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, true);
        }
        public static e.JoinBuilder InnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, true);
        }
        #endregion
        #region OuterJoin
        public static e.JoinBuilder OuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, false);
        }
        public static e.JoinBuilder OuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, false, tableName, alias, false);
        }
        public static e.JoinBuilder OuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, true);
        }
        public static e.JoinBuilder OuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, false, tableName, alias, true);
        }
        #endregion
    }
}
