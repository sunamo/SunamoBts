namespace SunamoBts._sunamo.SunamoExceptions;

/// <summary>
/// Provides methods to throw exceptions with detailed context about the execution location.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws an exception when an element in a list has a bad format.
    /// </summary>
    /// <param name="elementValue">The value of the badly formatted element.</param>
    /// <param name="listName">The name of the list containing the element.</param>
    /// <param name="nullToStringConverter">A function to convert possibly null values to their string representation.</param>
    /// <returns>True if an exception message was generated; otherwise, false.</returns>
    internal static bool BadFormatOfElementInList(
        object elementValue,
        string listName,
        Func<object, string> nullToStringConverter)
    {
        return ThrowIsNotNull(
            Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elementValue, listName, nullToStringConverter));
    }

    /// <summary>
    /// Throws an exception when a value is not a valid integer.
    /// </summary>
    /// <param name="what">The description of the value that failed parsing.</param>
    /// <param name="value">The nullable integer value to check.</param>
    /// <returns>True if an exception message was generated; otherwise, false.</returns>
    internal static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }

    /// <summary>
    /// Gets the full name of the currently executed code location including type and method name.
    /// </summary>
    /// <returns>A string in the format "TypeName.MethodName" representing the current execution location.</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of the executed code location from the specified type and method name.
    /// </summary>
    /// <param name="type">The type or type name of the code location.</param>
    /// <param name="methodName">The method name at the code location.</param>
    /// <param name="isFromThrowEx">Whether the call originates from a ThrowEx method, which affects stack depth calculation.</param>
    /// <returns>A string in the format "TypeName.MethodName".</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type typeInstance)
        {
            typeFullName = typeInstance.FullName ?? "Type cannot be get via type is Type typeInstance";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type actualType = type.GetType();
            typeFullName = actualType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception message is not null.
    /// </summary>
    /// <param name="exception">The exception message to evaluate.</param>
    /// <param name="isReallyThrowing">Whether to actually throw the exception or just return true.</param>
    /// <returns>True if the exception message was not null; otherwise, false.</returns>
    internal static bool ThrowIsNotNull(string? exception, bool isReallyThrowing = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (isReallyThrowing)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }
}
