using System.Text;

namespace RawSqlHelper
{
    /// <summary>
    /// Builder of SQL query from string
    /// </summary>
    public class SqlQueryBuilder
    {
        private const string Space = " ";
        private readonly EntrySeparator m_entrySeparator;
        private readonly StringBuilder m_builder = new StringBuilder();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entrySeparator">Defined entry separator</param>
        private SqlQueryBuilder(EntrySeparator entrySeparator)
        {
            m_entrySeparator = entrySeparator;
        }

        /// <summary>
        /// Builded SQL query
        /// </summary>
        public string SqlQuery => m_builder.ToString();

        /// <summary>
        /// Creates new instance of <see cref="SqlStringBuilder"/>
        /// </summary>
        /// <param name="entrySeparator">Defined entry separator. Default value is AppendWithSpace</param>
        /// <returns></returns>
        public static SqlQueryBuilder Create(EntrySeparator entrySeparator = EntrySeparator.AppendWithSpace)
        {
            return new SqlQueryBuilder(entrySeparator);
        }

        /// <summary>
        /// Operator for merging two parts of query. EntrySeparator is set from first non null <see cref="SqlStringBuilder"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static SqlQueryBuilder operator +(SqlQueryBuilder a, SqlQueryBuilder b)
        {
            SqlQueryBuilder result = null;
            if (a != null)
            {
                result = Create(a.m_entrySeparator);
                result.Add(b);
            }

            if (b != null)
            {
                if (result == null)
                {
                    result = Create(b.m_entrySeparator);
                }
                result.Add(b);
            }

            return result;
        }

        /// <summary>
        /// Clears all entries
        /// </summary>
        /// <returns></returns>
        public SqlQueryBuilder Clear()
        {
            m_builder.Clear();
            return this;
        }

        /// <summary>
        /// Adds new entry of sql query
        /// </summary>
        /// <param name="row">Entry of sql query</param>
        /// <returns></returns>
        public SqlQueryBuilder Add(string row)
        {
            return AddWithParameters(row);
        }


        /// <summary>
        /// Adds content of builder
        /// </summary>
        /// <param name="builder">Builder</param>
        public SqlQueryBuilder Add(SqlQueryBuilder builder)
        {
            return Add(builder.SqlQuery);
        }

        /// <summary>
        /// Adds content of builder
        /// </summary>
        /// <param name="builder">Builder</param>
        public SqlQueryBuilder Add(AQueryPartBuilder builder)
        {
            return Add(builder.Value);
        }

        /// <summary>
        /// Adds new entry of sql query with parameters to replace
        /// </summary>
        /// <param name="row">Entry of sql query with parameters to replace</param>
        /// <param name="args">Replacements of parameters in sql query entry</param>
        /// <returns></returns>
        public SqlQueryBuilder AddWithParameters(string row, params object[] args)
        {
            if (!string.IsNullOrEmpty(row))
            {
                var value = string.Format(row, args)
                    .Trim();
                if (m_entrySeparator == EntrySeparator.AppendWithSpace)
                {
                    value += Space;
                }

                if (m_entrySeparator == EntrySeparator.AppendWithNewLine)
                {
                    m_builder.AppendLine(value);
                }
                else
                {
                    m_builder.Append(value);
                }
            }

            return this;
        }

        /// <summary>
        /// Override returns <see cref="SqlQuery"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SqlQuery;
        }
    }
}
