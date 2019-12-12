using System;
using e = RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        #region Join
        public static SqlQueryBuilder Join(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, false);
        }
        public static SqlQueryBuilder Join(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, false);
        }
        public static SqlQueryBuilder JoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, true);
        }
        public static SqlQueryBuilder JoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, true);
        }
        #endregion
        #region LeftJoin
        public static SqlQueryBuilder LeftJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, false);
        }

        public static SqlQueryBuilder LeftJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, false);
        }

        public static SqlQueryBuilder LeftJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, true);
        }

        public static SqlQueryBuilder LeftJoinSubSelect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, true);
        }
        #endregion
        #region LeftInnerJoin
        public static SqlQueryBuilder LeftInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, false);
        }
        public static SqlQueryBuilder LeftInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, false);
        }
        public static SqlQueryBuilder LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, true);
        }
        public static SqlQueryBuilder LeftInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, true);
        }
        #endregion
        #region LeftOuterJoin
        public static SqlQueryBuilder LeftOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, false);
        }
        public static SqlQueryBuilder LeftOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, false);
        }
        public static SqlQueryBuilder LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, true);
        }
        public static SqlQueryBuilder LeftOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, true);
        }
        #endregion
        #region RightJoin
        public static SqlQueryBuilder RightJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, false);
        }
        public static SqlQueryBuilder RightJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, false);
        }
        public static SqlQueryBuilder RightJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, true);
        }
        public static SqlQueryBuilder RightJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, true);
        }
        #endregion
        #region RightInnerJoin
        public static SqlQueryBuilder RightInnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, false);
        }
        public static SqlQueryBuilder RightInnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, false);
        }
        public static SqlQueryBuilder RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, true);
        }
        public static SqlQueryBuilder RightInnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, true);
        }
        #endregion
        #region RightOuterJoin
        public static SqlQueryBuilder RightOuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, false);
        }
        public static SqlQueryBuilder RightOuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, false);
        }
        public static SqlQueryBuilder RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, true);
        }
        public static SqlQueryBuilder RightOuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, true);
        }
        #endregion
        #region InnerJoin
        public static SqlQueryBuilder InnerJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, false);
        }
        public static SqlQueryBuilder InnerJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, false);
        }
        public static SqlQueryBuilder InnerJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, true);
        }
        public static SqlQueryBuilder InnerJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, true);
        }
        #endregion
        #region OuterJoin
        public static SqlQueryBuilder OuterJoin(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, false);
        }
        public static SqlQueryBuilder OuterJoin(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, false, tableName, alias, false);
        }
        public static SqlQueryBuilder OuterJoinSubselect(this SqlQueryBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, true);
        }
        public static SqlQueryBuilder OuterJoinSubselect(this SqlQueryBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, false, tableName, alias, true);
        }
        #endregion

        /// <summary>
        /// Conditions for 'ON' part of 'JOIN' clause
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static SqlQueryBuilder On(this SqlQueryBuilder builder, params string[] conditions)
        {
            if (builder is e.JoinBuilder joinBuilder)
            {
                return joinBuilder.On(conditions);
            }

            throw new NotSupportedException();
        }
    }
}
