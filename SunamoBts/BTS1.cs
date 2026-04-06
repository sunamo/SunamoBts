namespace SunamoBts;

public partial class BTS
{
    /// <summary>
    /// Returns a Func delegate that can parse a string to the specified type T1, or null if the type is not supported.
    /// </summary>
    /// <typeparam name="T1">The target type for parsing.</typeparam>
    /// <returns>A Func delegate for parsing to type T1, or null if the type is not supported.</returns>
    public static object? MethodForParse<T1>()
    {
        var targetType = typeof(T1);
        if (targetType == Types.StringType)
            return new Func<string, string>(ToString);
        if (targetType == Types.BoolType)
            return new Func<string, bool>(bool.Parse);
        if (targetType == Types.FloatType)
            return new Func<string, float>(float.Parse);
        if (targetType == Types.DoubleType)
            return new Func<string, double>(double.Parse);
        if (targetType == typeof(int))
            return new Func<string, int>(int.Parse);
        if (targetType == Types.LongType)
            return new Func<string, long>(long.Parse);
        if (targetType == Types.ShortType)
            return new Func<string, short>(short.Parse);
        if (targetType == Types.DecimalType)
            return new Func<string, decimal>(decimal.Parse);
        if (targetType == Types.SByteType)
            return new Func<string, sbyte>(sbyte.Parse);
        if (targetType == Types.ByteType)
            return new Func<string, byte>(byte.Parse);
        if (targetType == Types.UShortType)
            return new Func<string, ushort>(ushort.Parse);
        if (targetType == Types.UIntType)
            return new Func<string, uint>(uint.Parse);
        if (targetType == Types.ULongType)
            return new Func<string, ulong>(ulong.Parse);
        if (targetType == Types.DateTimeType)
            return new Func<string, DateTime>(DateTime.Parse);
        if (targetType == Types.GuidType)
            return new Func<string, Guid>(Guid.Parse);
        if (targetType == Types.CharType)
            return new Func<string, char>(text => text[0]);
        return null;
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a DateTime.
    /// </summary>
    /// <param name="text">The string value to validate.</param>
    /// <returns>True if the value can be parsed as DateTime; otherwise, false.</returns>
    public static bool IsDateTime(string text)
    {
        if (text == null)
            return false;
        var isParsed = DateTime.TryParse(text, out var parsedDateTime);
        LastDateTime = parsedDateTime;
        return isParsed;
    }

    /// <summary>
    /// Parses a string value to an integer, removing spaces before parsing.
    /// If the value cannot be parsed, returns int.MinValue.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>The parsed integer value, or int.MinValue if parsing fails.</returns>
    public static int ParseInt(string text)
    {
        var parsedValue = 0;
        if (int.TryParse(text.Replace(" ", string.Empty), out parsedValue))
            return parsedValue;
        return int.MinValue;
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a boolean.
    /// </summary>
    /// <param name="text">The string value to validate.</param>
    /// <returns>True if the value can be parsed as boolean; otherwise, false.</returns>
    public static bool IsBool(string text)
    {
        if (text == null)
            return false;
        var isParsed = bool.TryParse(text, out var parsedBool);
        LastBool = parsedBool;
        return isParsed;
    }

    /// <summary>
    /// Parses the specified string value to a byte. Returns byte.MinValue if parsing fails.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>The parsed byte value or byte.MinValue if parsing fails.</returns>
    public static byte ParseByte(string text)
    {
        byte parsedValue = 0;
        if (byte.TryParse(text, out parsedValue))
            return parsedValue;
        return byte.MinValue;
    }

    /// <summary>
    /// Parses the specified string value to a short. Returns short.MinValue if parsing fails.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>The parsed short value or short.MinValue if parsing fails.</returns>
    public static short ParseShort(string text)
    {
        return ParseShort(text, short.MinValue);
    }

    /// <summary>
    /// Parses the specified string value to a short with a default value.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>The parsed short value or the specified default value if parsing fails.</returns>
    public static short ParseShort(string text, short defaultValue)
    {
        short parsedValue = 0;
        if (short.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parses the specified string value to a nullable int with a default value.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default nullable value to return if parsing fails.</param>
    /// <returns>The parsed int value or the specified default value if parsing fails.</returns>
    public static int? ParseInt(string text, int? defaultValue)
    {
        var parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Converts a boolean value to its English string representation (Yes/No).
    /// Delegates to <see cref="BoolToString(bool, bool)"/>.
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <param name="isLowerCase">If true, returns lowercase representation; otherwise, returns capitalized representation.</param>
    /// <returns>String representation of the boolean value in English.</returns>
    public static string BoolToStringEn(bool value, bool isLowerCase = false)
    {
        return BoolToString(value, isLowerCase);
    }

    /// <summary>
    /// Gets the minimum value for the specified numeric type.
    /// </summary>
    /// <param name="type">The numeric type to get the minimum value for.</param>
    /// <returns>The minimum value for the specified type.</returns>
    /// <exception cref="Exception">Thrown when the type is not a supported numeric type.</exception>
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
    /// Returns the boolean value from a nullable boolean. If the value is null, returns false.
    /// </summary>
    /// <param name="value">The nullable boolean value to extract.</param>
    /// <returns>The boolean value if it has one; otherwise, false.</returns>
    public static bool GetValueOfNullable(bool? value)
    {
        if (value.HasValue)
            return value.Value;
        return false;
    }

    /// <summary>
    /// Inverts a boolean value conditionally based on the isInverting flag.
    /// </summary>
    /// <param name="value">The boolean value to potentially invert.</param>
    /// <param name="isInverting">If true, the value will be inverted; otherwise, returns the original value.</param>
    /// <returns>The inverted or original boolean value based on the isInverting flag.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool isInverting)
    {
        if (isInverting)
            return !value;
        return value;
    }

    /// <summary>
    /// Casts a string to the specified generic type T, optionally treating it as a character.
    /// </summary>
    /// <typeparam name="T">The target type to cast to.</typeparam>
    /// <param name="text">The string text to cast.</param>
    /// <param name="isChar">If true, casts the first character; otherwise, casts the entire string.</param>
    /// <returns>The casted value of type T.</returns>
    public static T CastToByT<T>(string text, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)text.First();
        return (T)(dynamic)text;
    }

    /// <summary>
    /// Parses a string value to a DateTime using the specified culture info.
    /// For parsing from serialized file use DTHelperEn.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="cultureInfo">The culture info to use for parsing.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>The parsed DateTime value or the specified default value if parsing fails.</returns>
    public static DateTime TryParseDateTime(string text, CultureInfo cultureInfo, DateTime defaultValue)
    {
        var result = defaultValue;
        if (DateTime.TryParse(text, cultureInfo, DateTimeStyles.None, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Stores the last successfully parsed uint value from TryParseUint.
    /// </summary>
    public static uint LastUint { get; set; }

    /// <summary>
    /// Attempts to parse a string value to a uint and stores the result in LastUint.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>True if parsing succeeded; otherwise, false.</returns>
    public static bool TryParseUint(string text)
    {
        var isParsed = uint.TryParse(text, out var parsedUint);
        LastUint = parsedUint;
        return isParsed;
    }

    /// <summary>
    /// Attempts to parse a string value to a DateTime and stores the result in LastDateTime.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>True if parsing succeeded; otherwise, false.</returns>
    public static bool TryParseDateTime(string text)
    {
        if (DateTime.TryParse(text, out var parsedDateTime))
        {
            LastDateTime = parsedDateTime;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Attempts to parse a string value to a byte with a default value.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>The parsed byte value or the specified default value if parsing fails.</returns>
    public static byte TryParseByte(string text, byte defaultValue)
    {
        var result = defaultValue;
        if (byte.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a string value to a boolean with a default value.
    /// Returns the parsed value if parsing succeeds, otherwise returns the default value.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>The parsed boolean value or the specified default value if parsing fails.</returns>
    public static bool TryParseBool(string text, bool defaultValue)
    {
        var result = defaultValue;
        if (bool.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a string value to an int with null checking, returns 0 if value is null.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>0 if value is null, the parsed int value if successful, or the default value if parsing fails.</returns>
    public static int TryParseIntCheckNull(string text, int defaultValue)
    {
        var parsedValue = 0;
        if (text == null)
            return parsedValue;
        if (int.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Attempts to parse a string value to an int with a default value.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <returns>The parsed int value or the specified default value if parsing fails.</returns>
    public static int TryParseInt(string text, int defaultValue)
    {
        return TryParseInt(text, defaultValue, false);
    }

    /// <summary>
    /// Attempts to parse a string value to an int with optional exception throwing.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <param name="defaultValue">The default value to return if parsing fails.</param>
    /// <param name="isThrowingException">If true, throws an exception when parsing fails; otherwise, returns the default value.</param>
    /// <returns>The parsed int value or the specified default value if parsing fails.</returns>
    public static int TryParseInt(string text, int defaultValue, bool isThrowingException)
    {
        var parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
            return parsedValue;
        if (isThrowingException)
            ThrowEx.NotInt(text, null);
        return defaultValue;
    }

    /// <summary>
    /// Converts a boolean value to an integer (1 for true, 0 for false).
    /// </summary>
    /// <param name="value">The boolean value to convert.</param>
    /// <returns>1 if true, 0 if false.</returns>
    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }
}
