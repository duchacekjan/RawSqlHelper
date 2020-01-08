using LLE = RawSqlHelper.LinqLikeExtension.LinqLikeExtension;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    /// <summary>
    /// Builder for LinqLikeExtension. Enables creating <see cref="SqlQueryBuilder"/> from <see cref="Select"/> statement
    /// </summary>
    public class LinqLikeBuilder : SqlQueryBuilder
    {
        public const string SelectKey = "SELECT";
        public const string FromKey = "FROM";

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
        public static LinqLikeBuilder Select(params string[] fields)
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

            var select = $"{SelectKey} {parameters}";
            builder.Add(select);
            return builder;
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="tableName">Table name for 'FROM' clause</param>
        /// <returns></returns>
        public LinqLikeBuilder From(string tableName)
        {
            return From(tableName, null);
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="tableName">Table name for 'FROM' clause</param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public LinqLikeBuilder From(string tableName, string alias)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new System.ArgumentNullException(nameof(tableName));
            }

            var from = $"{FromKey} {tableName} {alias}".Trim();
            return (LinqLikeBuilder)Add(from);
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="subselect">Table name for 'FROM' clause</param>
        /// <param name="wrapInBrackets">Subselect will be wrapped in brackets</param>
        /// <returns></returns>
        public LinqLikeBuilder FromSubselect(string subselect, bool wrapInBrackets = true)
        {
            if (string.IsNullOrEmpty(subselect))
            {
                throw new System.ArgumentNullException(nameof(subselect));
            }

            return FromSubselect(subselect.Brackets(), null, wrapInBrackets);
        }

        /// <summary>
        /// Adds 'FROM' statement.
        /// </summary>
        /// <param name="subselect">Subselect for 'FROM' clause</param>
        /// <param name="alias">Subselect alias</param>
        /// <param name="wrapInBrackets">Subselect will be wrapped in brackets</param>
        /// <returns></returns>
        public LinqLikeBuilder FromSubselect(string subselect, string alias, bool wrapInBrackets = true)
        {
            if (string.IsNullOrEmpty(subselect))
            {
                throw new System.ArgumentNullException(nameof(subselect));
            }

            var part = subselect;
            if (wrapInBrackets)
            {
                part = subselect.Brackets();
            }

            return From(part, alias);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
