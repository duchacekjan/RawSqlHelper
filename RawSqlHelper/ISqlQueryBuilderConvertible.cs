namespace RawSqlHelper
{
    /// <summary>
    /// Interface, that ensures that class in convertible to <see cref="SqlQueryBuilder"/>
    /// </summary>
    public interface ISqlQueryBuilderConvertible
    {
        /// <summary>
        /// Entire builded SQL query
        /// </summary>
        string SqlQuery { get; }

        /// <summary>
        /// Method returns <see cref="SqlQueryBuilder"/>
        /// </summary>
        /// <returns></returns>
        SqlQueryBuilder ToSqlQueryBuilder();
    }
}
