﻿using System.Text;

namespace RawSqlHelper
{
    /// <summary>
    /// Builder of SQL query from string
    /// </summary>
    public class SqlQueryBuilder
    {
        protected const string Space = " ";
        protected bool? IsPartRead;
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

        protected SqlQueryBuilder(SqlQueryBuilder builder)
            : this(builder.m_entrySeparator)
        {
            Add(builder);
            IsPartRead = false;
        }

        /// <summary>
        /// Builded SQL query
        /// </summary>
        public string SqlQuery => GetSqlQuery();

        /// <summary>
        /// Creates new instance of <see cref="SqlQueryBuilder"/>
        /// </summary>
        /// <param name="entrySeparator">Defined entry separator. Default value is AppendWithSpace</param>
        /// <returns></returns>
        public static SqlQueryBuilder Create(EntrySeparator entrySeparator = EntrySeparator.AppendWithSpace)
        {
            return new SqlQueryBuilder(entrySeparator);
        }

        /// <summary>
        /// Operator for merging two parts of query. EntrySeparator is set from first non null <see cref="SqlQueryBuilder"/>
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
        /// Adds new entry of sql query with parameters to replace
        /// </summary>
        /// <param name="row">Entry of sql query with parameters to replace</param>
        /// <param name="args">Replacements of parameters in sql query entry</param>
        /// <returns></returns>
        public SqlQueryBuilder AddWithParameters(string row, params object[] args)
        {
            AppendPartOfQuery();
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

        /// <summary>
        /// Constructs part of query
        /// </summary>
        /// <returns></returns>
        protected virtual string GetPartQuery()
        {
            return null;
        }

        /// <summary>
        /// Builds resulted SQL query
        /// </summary>
        /// <returns></returns>
        private string GetSqlQuery()
        {
            AppendPartOfQuery();
            return m_builder.ToString();
        }

        /// <summary>
        /// Adds part of query
        /// </summary>
        private void AppendPartOfQuery()
        {
            if (IsPartRead == false)
            {
                var part = GetPartQuery();
                if (!string.IsNullOrEmpty(part))
                {
                    IsPartRead = true;
                    Add(part);
                }
            }
        }
    }
}
