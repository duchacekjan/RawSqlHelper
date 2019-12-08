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
        /// Returns <see cref="Value"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
