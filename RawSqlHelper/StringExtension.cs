using System.Collections.Generic;

namespace RawSqlHelper
{
    /// <summary>
    /// Extensions which returns string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Joins values into string with separator
        /// </summary>
        /// <typeparam name="T">Type of enumerable item</typeparam>
        /// <param name="enumerable">collection</param>
        /// <param name="separator">Value separator</param>
        /// <returns></returns>
        public static string StringJoin<T>(this IEnumerable<T> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
        
        /// <summary>
        /// Wraps value with brackets
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static string Brackets<T>(this T value)
        {
            return $"({value})";
        }

        /// <summary>
        /// Wraps value with curly brackets
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static string CurlyBrackets<T>(this T value)
        {
            return $"{{{value}}}";
        }

        /// <summary>
        /// Wraps value with square brackets
        /// </summary>
        /// <typeparam name="T">Type of value</typeparam>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static string SquareBrackets<T>(this T value)
        {
            return $"[{value}]";
        }
    }
}
