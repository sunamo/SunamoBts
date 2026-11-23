namespace SunamoBts;

public partial class BTS
{
    /// <summary>
    /// Method for parse t 1.
    /// </summary>
    /// <typeparam name="T1">The type T1.</typeparam>
    /// <returns>The method for parse t 1 result.</returns>
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
    /// Is date time.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is date time result.</returns>
    public static bool IsDateTime(string text)
    {
        if (text is null)
            return false;
        var isParsed = DateTime.TryParse(text, out var parsedDateTime);
        LastDateTime = parsedDateTime;
        return isParsed;
    }

    /// <summary>
    /// Parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse int result.</returns>
    public static int ParseInt(string text)
    {
        if (int.TryParse(text.Replace(" ", string.Empty), out var parsedValue))
            return parsedValue;
        return int.MinValue;
    }

    /// <summary>
    /// Is bool.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is bool result.</returns>
    public static bool IsBool(string text)
    {
        if (text is null)
            return false;
        var isParsed = bool.TryParse(text, out var parsedBool);
        LastBool = parsedBool;
        return isParsed;
    }

    /// <summary>
    /// Parse byte.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse byte result.</returns>
    public static byte ParseByte(string text)
    {
        if (byte.TryParse(text, out var parsedValue))
            return parsedValue;
        return byte.MinValue;
    }

    /// <summary>
    /// Parse short.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse short result.</returns>
    public static short ParseShort(string text)
    {
        return ParseShort(text, short.MinValue);
    }

    /// <summary>
    /// Parse short.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse short result.</returns>
    public static short ParseShort(string text, short defaultValue)
    {
        if (short.TryParse(text, out var parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse int result.</returns>
    public static int? ParseInt(string text, int? defaultValue)
    {
        if (int.TryParse(text, out var parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Bool to string en.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="isLowerCase">The is lower case.</param>
    /// <returns>The bool to string en result.</returns>
    public static string BoolToStringEn(bool value, bool isLowerCase = false)
    {
        return BoolToString(value, isLowerCase);
    }

    /// <summary>
    /// Get min value for type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The get min value for type result.</returns>
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
    /// Get value of nullable.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The get value of nullable result.</returns>
    public static bool GetValueOfNullable(bool? value)
    {
        if (value.HasValue)
            return value.Value;
        return false;
    }

    /// <summary>
    /// Invert.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="isInverting">The is inverting.</param>
    /// <returns>The invert result.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool isInverting)
    {
        if (isInverting)
            return !value;
        return value;
    }

    /// <summary>
    /// Cast to by t t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="text">The text.</param>
    /// <param name="isChar">The is char.</param>
    /// <returns>The cast to by t t result.</returns>
    public static T CastToByT<T>(string text, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)text.First();
        return (T)(dynamic)text;
    }

    // For parsing from serialized file use DTHelperEn.
    /// <summary>
    /// Try parse date time.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="cultureInfo">The culture info.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The try parse date time result.</returns>
    public static DateTime TryParseDateTime(string text, CultureInfo cultureInfo, DateTime defaultValue)
    {
        var result = defaultValue;
        if (DateTime.TryParse(text, cultureInfo, DateTimeStyles.None, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Gets or sets the last uint.
    /// </summary>
    public static uint LastUint { get; set; }

    /// <summary>
    /// Try parse uint.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The try parse uint result.</returns>
    public static bool TryParseUint(string text)
    {
        var isParsed = uint.TryParse(text, out var parsedUint);
        LastUint = parsedUint;
        return isParsed;
    }

    /// <summary>
    /// Try parse date time.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The try parse date time result.</returns>
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
    /// Try parse byte.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The try parse byte result.</returns>
    public static byte TryParseByte(string text, byte defaultValue)
    {
        var result = defaultValue;
        if (byte.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Try parse bool.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The try parse bool result.</returns>
    public static bool TryParseBool(string text, bool defaultValue)
    {
        var result = defaultValue;
        if (bool.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Try parse int check null.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The try parse int check null result.</returns>
    public static int TryParseIntCheckNull(string text, int defaultValue)
    {
        if (text is null)
            return 0;
        if (int.TryParse(text, out var parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Try parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The try parse int result.</returns>
    public static int TryParseInt(string text, int defaultValue)
    {
        return TryParseInt(text, defaultValue, false);
    }

    /// <summary>
    /// Try parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <param name="false">The false.</param>
    /// <returns>The try parse int result.</returns>
    public static int TryParseInt(string text, int defaultValue, bool isThrowingException)
    {
        if (int.TryParse(text, out var parsedValue))
            return parsedValue;
        if (isThrowingException)
            ThrowEx.NotInt(text, null);
        return defaultValue;
    }

    /// <summary>
    /// Bool to int.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The bool to int result.</returns>
    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }
}
