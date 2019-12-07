namespace RawSqlHelper
{
    /// <summary>
    /// Separator for each entry
    /// </summary>
    public enum EntrySeparator
    {
        /// <summary>
        /// Only adding text one by one
        /// </summary>
        Append,

        /// <summary>
        /// Each entry is ensured to end with space. Then added one by one 
        /// </summary>
        AppendWithSpace,

        /// <summary>
        /// Each entry is added on new line
        /// </summary>
        AppendWithNewLine
    }
}
