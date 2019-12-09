using System;
namespace RawSqlHelper
{
    /// <summary>
    /// Exception when missing required part of sql query
    /// </summary>
    public class RequiredPartNotDefinedException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paramName"></param>
        public RequiredPartNotDefinedException(string paramName)
            : this(paramName, null, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public RequiredPartNotDefinedException(string paramName, string message)
            : this(paramName, message, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="innerException"></param>
        public RequiredPartNotDefinedException(string paramName, Exception innerException)
            : this(paramName, null, innerException)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public RequiredPartNotDefinedException(string paramName, string message, Exception innerException)
            : base(CreateMessage(paramName, message), innerException)
        {

        }

        /// <summary>
        /// Creates exception message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string CreateMessage(string paramName, string message)
        {
            var baseMessage = $"Required parameter '{paramName}' is not defined.";
            if (!string.IsNullOrEmpty(message))
            {
                baseMessage += $"{Environment.NewLine}{message}";
            }
            return baseMessage;
        }
    }
}
