using System;
using e = RawSqlHelper.LinqLikeExtension.Enhancers;

namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        #region Join
        public static e.LinqLikeBuilder Join(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, false);
        }
        public static e.LinqLikeBuilder Join(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, false);
        }
        public static e.LinqLikeBuilder JoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, null, tableName, null, true);
        }
        public static e.LinqLikeBuilder JoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, null, tableName, alias, true);
        }
        #endregion
        #region LeftJoin
        public static e.LinqLikeBuilder LeftJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, false);
        }

        public static e.LinqLikeBuilder LeftJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, false);
        }

        public static e.LinqLikeBuilder LeftJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, null, tableName, null, true);
        }

        public static e.LinqLikeBuilder LeftJoinSubSelect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, null, tableName, alias, true);
        }
        #endregion
        #region LeftInnerJoin
        public static e.LinqLikeBuilder LeftInnerJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, false);
        }
        public static e.LinqLikeBuilder LeftInnerJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, false);
        }
        public static e.LinqLikeBuilder LeftInnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, true, tableName, null, true);
        }
        public static e.LinqLikeBuilder LeftInnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, true, tableName, alias, true);
        }
        #endregion
        #region LeftOuterJoin
        public static e.LinqLikeBuilder LeftOuterJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, false);
        }
        public static e.LinqLikeBuilder LeftOuterJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, false);
        }
        public static e.LinqLikeBuilder LeftOuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, true, false, tableName, null, true);
        }
        public static e.LinqLikeBuilder LeftOuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, true, false, tableName, alias, true);
        }
        #endregion
        #region RightJoin
        public static e.LinqLikeBuilder RightJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, false);
        }
        public static e.LinqLikeBuilder RightJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, false);
        }
        public static e.LinqLikeBuilder RightJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, null, tableName, null, true);
        }
        public static e.LinqLikeBuilder RightJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, null, tableName, alias, true);
        }
        #endregion
        #region RightInnerJoin
        public static e.LinqLikeBuilder RightInnerJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, false);
        }
        public static e.LinqLikeBuilder RightInnerJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, false);
        }
        public static e.LinqLikeBuilder RightInnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, true, tableName, null, true);
        }
        public static e.LinqLikeBuilder RightInnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, true, tableName, alias, true);
        }
        #endregion
        #region RightOuterJoin
        public static e.LinqLikeBuilder RightOuterJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, false);
        }
        public static e.LinqLikeBuilder RightOuterJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, false);
        }
        public static e.LinqLikeBuilder RightOuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, false, false, tableName, null, true);
        }
        public static e.LinqLikeBuilder RightOuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, false, false, tableName, alias, true);
        }
        #endregion
        #region InnerJoin
        public static e.LinqLikeBuilder InnerJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, false);
        }
        public static e.LinqLikeBuilder InnerJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, false);
        }
        public static e.LinqLikeBuilder InnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, true, tableName, null, true);
        }
        public static e.LinqLikeBuilder InnerJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, true, tableName, alias, true);
        }
        #endregion
        #region OuterJoin
        public static e.LinqLikeBuilder OuterJoin(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, false);
        }
        public static e.LinqLikeBuilder OuterJoin(this e.LinqLikeBuilder builder, string tableName, string alias)
        {
            return new e.JoinBuilder(builder, null, false, tableName, alias, false);
        }
        public static e.LinqLikeBuilder OuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName)
        {
            return new e.JoinBuilder(builder, null, false, tableName, null, true);
        }
        public static e.LinqLikeBuilder OuterJoinSubselect(this e.LinqLikeBuilder builder, string tableName, string alias)
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
        public static e.LinqLikeBuilder On(this e.LinqLikeBuilder builder, params string[] conditions)
        {
            if (builder is e.JoinBuilder joinBuilder)
            {
                return joinBuilder.On(conditions);
            }

            throw new NotSupportedException();
        }
    }
}
