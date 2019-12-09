namespace RawSqlHelper
{
    /// <summary>
    /// Base for builders, which participates in building raw SQL query
    /// </summary>
    public abstract class AQueryPartBuilder : ISqlQueryBuilderConvertible
    {
        private readonly SqlQueryBuilder m_builder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="builder"></param>
        protected AQueryPartBuilder(SqlQueryBuilder builder)
        {
            m_builder = builder ?? throw new System.ArgumentNullException(nameof(builder)); ;
        }

        /// <summary>
        /// Resulted part SQL Query
        /// </summary>
        public abstract string Value { get; }

        /// <summary>
        /// Entire builded SQL query
        /// </summary>
        public string SqlQuery => ToSqlQueryBuilder().SqlQuery;

        /// <summary>
        /// Method returns <see cref="SqlQueryBuilder"/>
        /// </summary>
        /// <returns></returns>
        public SqlQueryBuilder ToSqlQueryBuilder()
        {
            return m_builder.Add(Value);
        }

        /// <summary>
        /// Returns value prefixed with specified Keyword
        /// </summary>
        /// <param name="keyword">Keyword for prefix</param>
        /// <returns></returns>
        public string WithKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new System.ArgumentNullException(nameof(keyword));
            }

            return $"{keyword} {Value}";
        }

        /// <summary>
        /// Returns <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
