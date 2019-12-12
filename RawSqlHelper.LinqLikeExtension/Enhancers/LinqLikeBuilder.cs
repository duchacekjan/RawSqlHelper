using LLE = RawSqlHelper.LinqLikeExtension.LinqLikeExtension;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    /// <summary>
    /// Builder for LinqLikeExtension. Enables creating <see cref="SqlQueryBuilder"/> from <see cref="Select"/> statement
    /// </summary>
    public class LinqLikeBuilder : SqlQueryBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="builder"></param>
        protected LinqLikeBuilder(SqlQueryBuilder builder)
            : base(builder)
        {
        }

        /// <summary>
        /// Adds 'SELECT' statement. If <paramref name="fields"/> is <see langword="null"/> or empty, then '*' value used
        /// </summary>
        /// <param name="fields">Fields to select.</param>
        /// <returns></returns>
        public static SqlQueryBuilder Select(params string[] fields)
        {
            var builder = new LinqLikeBuilder(Create());
            if (fields == null || fields.Length == 0)
            {
                fields = new string[] { };
            }

            var parameters = string.Join(LLE.CommaSeparator, fields);
            if (string.IsNullOrEmpty(parameters))
            {
                parameters = "*";
            }

            var select = $"{LLE.SelectKey} {parameters}";
            return builder.Add(select);
        }
    }
}
