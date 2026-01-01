namespace SunamoBts;

public partial class BTS
{
    /// <summary>
    ///     return Func&lt;string , T1&gt; or null
    /// </summary>
    /// <typeparam name = "T1">The target type for parsing</typeparam>
    /// <returns>Func delegate for parsing to type T1, or null if type is not supported</returns>
    public static object? MethodForParse<T1>()
    {
        var targetType = typeof(T1);
#region Same seria as in DefaultValueForTypeT
#region MyRegion
        if (targetType == Types.TString)
            return new Func<string, string>(ToString);
        if (targetType == Types.TBool)
            return new Func<string, bool>(bool.Parse);
#endregion
#region Signed numbers
        if (targetType == Types.TFloat)
            return new Func<string, float>(float.Parse);
        if (targetType == Types.TDouble)
            return new Func<string, double>(double.Parse);
        if (targetType == typeof(int))
            return new Func<string, int>(int.Parse);
        if (targetType == Types.TLong)
            return new Func<string, long>(long.Parse);
        if (targetType == Types.TShort)
            return new Func<string, short>(short.Parse);
        if (targetType == Types.TDecimal)
            return new Func<string, decimal>(decimal.Parse);
        if (targetType == Types.TSbyte)
            return new Func<string, sbyte>(sbyte.Parse);
#endregion
#region Unsigned numbers
        if (targetType == Types.TByte)
            return new Func<string, byte>(byte.Parse);
        if (targetType == Types.TUshort)
            return new Func<string, ushort>(ushort.Parse);
        if (targetType == Types.TUint)
            return new Func<string, uint>(uint.Parse);
        if (targetType == Types.TUlong)
            return new Func<string, ulong>(ulong.Parse);
#endregion
        if (targetType == Types.TDateTime)
            return new Func<string, DateTime>(DateTime.Parse);
        if (targetType == Types.TGuid)
            return new Func<string, Guid>(Guid.Parse);
        if (targetType == Types.TChar)
            return new Func<string, char>(text => text[0]);
#endregion
        return null;
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a DateTime
    /// </summary>
    /// <param name="value">The string value to validate</param>
    /// <returns>True if the value can be parsed as DateTime; otherwise, false</returns>
    public static bool IsDateTime(string value)
    {
        if (value == null)
            return false;
        return DateTime.TryParse(value, out LastDateTime);
    }

    /// <summary>
    ///     If the value cannot be parsed, returns int.MinValue
    ///     Replace spaces
    /// </summary>
    /// <param name = "value"></param>
    public static int ParseInt(string value)
    {
        var parsedValue = 0;
        if (int.TryParse(value.Replace(" ", string.Empty), out parsedValue))
            return parsedValue;
        return int.MinValue;
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a boolean
    /// </summary>
    /// <param name="value">The string value to validate</param>
    /// <returns>True if the value can be parsed as boolean; otherwise, false</returns>
    public static bool IsBool(string value)
    {
        if (value == null)
            return false;
        return bool.TryParse(value, out LastBool);
    }

    /// <summary>
    /// Parses the specified string value to a byte. Returns byte.MinValue if parsing fails
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <returns>The parsed byte value or byte.MinValue if parsing fails</returns>
    public static byte ParseByte(string value)
    {
        byte parsedValue = 0;
        if (byte.TryParse(value, out parsedValue))
            return parsedValue;
        return byte.MinValue;
    }

    /// <summary>
    /// Parses the specified string value to a short. Returns short.MinValue if parsing fails
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <returns>The parsed short value or short.MinValue if parsing fails</returns>
    public static short ParseShort(string value)
    {
        return ParseShort(value, short.MinValue);
    }

    /// <summary>
    /// Parses the specified string value to a short with a default value
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed short value or the specified default value if parsing fails</returns>
    public static short ParseShort(string value, short defaultValue)
    {
        short parsedValue = 0;
        if (short.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parses the specified string value to a nullable int with a default value
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default nullable value to return if parsing fails</param>
    /// <returns>The parsed int value or the specified default value if parsing fails</returns>
    public static int? ParseInt(string value, int? defaultValue)
    {
        var parsedValue = 0;
        if (int.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Converts a boolean value to its English string representation (Yes/No)
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <param name="isLowerCase">If true, returns lowercase representation; otherwise, returns capitalized representation</param>
    /// <returns>String representation of the boolean value in English</returns>
    public static string BoolToStringEn(bool value, bool isLowerCase = false)
    {
        string result;
        if (value)
            result = "Yes";
        else
            result = "No";
        if (isLowerCase)
        {
            return result.ToLower();
        }

        return result;
    }

    /// <summary>
    /// Gets the minimum value for the specified numeric type
    /// </summary>
    /// <param name="type">The numeric type to get the minimum value for</param>
    /// <returns>The minimum value for the specified type</returns>
    /// <exception cref="Exception">Thrown when the type is not a supported numeric type</exception>
    public static object GetMinValueForType(Type type)
    {
        if (type == typeof(byte))
            return 1;
        if (type == typeof(short))
            return short.MinValue;
        if (type == typeof(int))
            return int.MinValue;
        if (type == typeof(long))
            return long.MinValue;
        if (type == typeof(sbyte))
            return sbyte.MinValue;
        if (type == typeof(ushort))
            return ushort.MinValue;
        if (type == typeof(uint))
            return uint.MinValue;
        if (type == typeof(ulong))
            return ulong.MinValue;
        throw new Exception("Invalid non-value type in method GetMinValueForType");
    }

    /// <summary>
    ///     If has value true, return true. Otherwise return false
    /// </summary>
    /// <param name = "value"></param>
    public static bool GetValueOfNullable(bool? value)
    {
        if (value.HasValue)
            return value.Value;
        return false;
    }

    /// <summary>
    /// Inverts a boolean value conditionally based on the isInverting flag
    /// </summary>
    /// <param name="value">The boolean value to potentially invert</param>
    /// <param name="isInverting">If true, the value will be inverted; otherwise, returns the original value</param>
    /// <returns>The inverted or original boolean value based on the isInverting flag</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool isInverting)
    {
        if (isInverting)
            return !value;
        return value;
    }

    /// <summary>
    /// Casts a string to the specified generic type T, optionally treating it as a character
    /// </summary>
    /// <typeparam name="T">The target type to cast to</typeparam>
    /// <param name="text">The string text to cast</param>
    /// <param name="isChar">If true, casts the first character; otherwise, casts the entire string</param>
    /// <returns>The casted value of type T</returns>
    public static T CastToByT<T>(string text, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)text.First();
        return (T)(dynamic)text;
    }

    /// <summary>
    ///     For parsing from serialized file use DTHelperEn
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "cultureInfo"></param>
    /// <param name = "defaultValue"></param>
    public static DateTime TryParseDateTime(string value, CultureInfo cultureInfo, DateTime defaultValue)
    {
        var result = defaultValue;
        if (DateTime.TryParse(value, cultureInfo, DateTimeStyles.None, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Stores the last successfully parsed uint value from TryParseUint
    /// </summary>
    public static uint LastUint;

    /// <summary>
    /// Attempts to parse a string value to a uint and stores the result in LastUint
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <returns>True if parsing succeeded; otherwise, false</returns>
    public static bool TryParseUint(string value)
    {
        return uint.TryParse(value, out LastUint);
    }

    /// <summary>
    /// Attempts to parse a string value to a DateTime and stores the result in LastDateTime
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <returns>True if parsing succeeded; otherwise, false</returns>
    public static bool TryParseDateTime(string value)
    {
        if (DateTime.TryParse(value, out LastDateTime))
            return true;
        return false;
    }

    /// <summary>
    /// Attempts to parse a string value to a byte with a default value
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed byte value or the specified default value if parsing fails</returns>
    public static byte TryParseByte(string value, byte defaultValue)
    {
        var result = defaultValue;
        if (byte.TryParse(value, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    ///     Returns parsed value if parsing succeeds, otherwise returns the default value
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "defaultValue"></param>
    public static bool TryParseBool(string value, bool defaultValue)
    {
        var result = defaultValue;
        if (bool.TryParse(value, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a string value to an int with null checking, returns 0 if value is null
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>0 if value is null, the parsed int value if successful, or the default value if parsing fails</returns>
    public static int TryParseIntCheckNull(string value, int defaultValue)
    {
        var parsedValue = 0;
        if (value == null)
            return parsedValue;
        if (int.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a string value to an int with a default value
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed int value or the specified default value if parsing fails</returns>
    public static int TryParseInt(string value, int defaultValue)
    {
        return TryParseInt(value, defaultValue, false);
    }

    /// <summary>
    /// Attempts to parse a string value to an int with optional exception throwing
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <param name="isThrowingException">If true, throws an exception when parsing fails; otherwise, returns the default value</param>
    /// <returns>The parsed int value or the specified default value if parsing fails</returns>
    public static int TryParseInt(string value, int defaultValue, bool isThrowingException)
    {
        var parsedValue = 0;
        if (int.TryParse(value, out parsedValue))
            return parsedValue;
        if (isThrowingException)
            ThrowEx.NotInt(value, null);
        return defaultValue;
    }

    /// <summary>
    /// Converts a boolean value to an integer (1 for true, 0 for false)
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <returns>1 if true, 0 if false</returns>
    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }
}