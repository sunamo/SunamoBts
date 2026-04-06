namespace SunamoBts._sunamo.SunamoExceptions;

/// <summary>
/// Provides exception message formatting and stack trace analysis utilities.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// Checks and formats the before prefix for exception messages.
    /// </summary>
    /// <param name="before">The prefix text to prepend to the exception message.</param>
    /// <returns>Empty string if before is null or whitespace; otherwise, the before text followed by a colon and space.</returns>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Analyzes the current stack trace to determine the type, method name, and full trace of the exception origin.
    /// </summary>
    /// <param name="isFillingFirstTwo">Whether to extract the type and method name from the first non-ThrowEx frame.</param>
    /// <returns>A tuple containing the type name, method name, and formatted stack trace string.</returns>
    internal static Tuple<string, string, string> PlaceOfException(bool isFillingFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceString = stackTrace.ToString();
        var lines = stackTraceString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        string typeName = string.Empty;
        string methodName = string.Empty;
        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            if (isFillingFirstTwo)
                if (!line.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(line, out typeName, out methodName);
                    isFillingFirstTwo = false;
                }
            if (line.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(typeName, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Extracts the type name and method name from a stack trace line.
    /// </summary>
    /// <param name="line">The stack trace line to parse.</param>
    /// <param name="typeName">When this method returns, contains the extracted type name.</param>
    /// <param name="methodName">When this method returns, contains the extracted method name.</param>
    internal static void TypeAndMethodName(string line, out string typeName, out string methodName)
    {
        var contentAfterAt = line.Split("at ")[1].Trim();
        var text = contentAfterAt.Split("(")[0];
        var parts = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        typeName = string.Join(".", parts);
    }

    /// <summary>
    /// Gets the name of the calling method at the specified stack depth.
    /// </summary>
    /// <param name="depth">The stack frame depth to retrieve the method name from.</param>
    /// <returns>The name of the calling method, or an error message if it cannot be determined.</returns>
    internal static string CallingMethod(int depth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(depth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    /// <summary>
    /// Creates an error message for a badly formatted element found in a list.
    /// </summary>
    /// <param name="before">The prefix text for the error message.</param>
    /// <param name="elementValue">The value of the badly formatted element.</param>
    /// <param name="listName">The name of the list containing the element.</param>
    /// <param name="nullToStringConverter">A function to convert possibly null values to their string representation.</param>
    /// <returns>The formatted error message, or null if no error.</returns>
    internal static string? BadFormatOfElementInList(string before, object elementValue, string listName, Func<object, string> nullToStringConverter)
    {
        return CheckBefore(before) + " Bad format of element" + " " + nullToStringConverter(elementValue) +
        " in list " + listName;
    }

    /// <summary>
    /// Creates an error message when a value is not a valid integer.
    /// </summary>
    /// <param name="before">The prefix text for the error message.</param>
    /// <param name="what">The description of the value that failed parsing.</param>
    /// <param name="value">The nullable integer value to check.</param>
    /// <returns>The formatted error message if the value is null; otherwise, null.</returns>
    internal static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not a valid integer number" : null;
    }
}
