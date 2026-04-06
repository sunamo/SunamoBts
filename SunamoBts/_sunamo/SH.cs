namespace SunamoBts._sunamo;

/// <summary>
/// String helper utilities for internal use.
/// </summary>
internal class SH
{
    /// <summary>
    /// Converts a possibly null object to its string representation, prefixed with a space.
    /// Returns " (null)" if the value is null.
    /// </summary>
    /// <param name="value">The object to convert to string.</param>
    /// <returns>A string representation of the value prefixed with a space, or " (null)" if null.</returns>
    internal static string NullToStringOrDefault(object value)
    {
        return value == null ? " " + "(null)" : " " + value;
    }
}
