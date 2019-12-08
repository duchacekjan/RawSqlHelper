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
        protected abstract string Value { get; set; }

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
