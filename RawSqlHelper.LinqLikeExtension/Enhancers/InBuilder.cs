using System;
using System.Collections.Generic;
using System.Linq;

namespace RawSqlHelper.LinqLikeExtension.Enhancers
{
    public class InBuilder : AQueryPartBuilder
    {
        private const string InKey = "IN";
        private readonly List<string> m_fields;
        private IList<IList<string>> m_values;

        internal InBuilder(SqlQueryBuilder builder, string fieldName, params string[] fields)
            : this(builder, GetFields(fieldName, fields))
        {
        }

        internal InBuilder(SqlQueryBuilder builder, IEnumerable<string> fields)
            : base(builder)
        {
            m_fields = fields.ToList();
        }

        public override string Value => GetValue();

        public InBuilder InValues(params object[] values)
        {
            return InValues(new IEnumerable<object>[] { values });
        }

        public InBuilder InValues(params IEnumerable<object>[] values)
        {
            m_values = new List<IList<string>>();
            try
            {
                foreach (var data in values.Select(items => items.ToList()))
                {
                    if (data.Count == m_fields.Count)
                    {
                        m_values.Add(data.Cast<string>().ToList());
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(values));
                    }
                }
            }
            catch
            {
                m_values.Clear();
            }
            return this;
        }

        private static IEnumerable<string> GetFields(string fieldName, params string[] fields)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            var result = new List<string>
            {
                fieldName
            };

            if (fields != null)
            {
                result.AddRange(fields);
            }

            return result;
        }

        private string GetValue()
        {
            var fields = m_fields.ToList();
            var field = fields.StringJoin(LinqLikeExtension.CommaSeparator);
            if (fields.Count > 1)
            {
                field = field.Brackets();
            }

            var values = m_values
                .Select(s => s.StringJoin(LinqLikeExtension.CommaSeparator).Brackets())
                .StringJoin(LinqLikeExtension.CommaSeparator)
                .Brackets();

            return $"{field} {InKey} {values}".Brackets();
        }
    }
}
