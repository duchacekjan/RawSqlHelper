namespace RawSqlHelper.LinqLikeExtension
{
    public static partial class LinqLikeExtension
    {
        public const string WhereKey = "WHERE";
        public const string CommaSeparator = ", ";

        /// <summary>
        /// Adds 'WHERE' statement with <paramref name="condition"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="condition">Condition added to 'WHERE' clause</param>
        /// <returns></returns>
        public static SqlQueryBuilder Where(this SqlQueryBuilder builder, string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                throw new System.ArgumentNullException(condition);
            }

            var where = $"{WhereKey} {condition}";
            return builder.Add(where);
        }
    }
}
