namespace RawSqlHelper
{
    /// <summary>
    /// Base for builders, which participates in building raw SQL query
    /// </summary>
    public abstract class AQueryPartBuilder
    {
        /// <summary>
        /// Resulted part SQL Query
        /// </summary>
        public abstract string Value { get; }

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
