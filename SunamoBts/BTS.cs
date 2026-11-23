namespace SunamoBts;

/// <summary>
/// Represents the BTS type.
/// </summary>
public partial class BTS
{
    /// <summary>
    /// Gets or sets the last int.
    /// </summary>
    public static int LastInt { get; set; } = -1;
    /// <summary>
    /// Gets or sets the last long.
    /// </summary>
    public static long LastLong { get; set; } = -1;
    /// <summary>
    /// Gets or sets the last float.
    /// </summary>
    public static float LastFloat { get; set; } = -1;
    /// <summary>
    /// Gets or sets the last double.
    /// </summary>
    public static double LastDouble { get; set; } = -1;
    /// <summary>
    /// Gets or sets the last byte.
    /// </summary>
    public static byte LastByte { get; set; } = 255;
    /// <summary>
    /// Gets or sets the last bool.
    /// </summary>
    public static bool LastBool { get; set; }
    /// <summary>
    /// Gets or sets the last date time.
    /// </summary>
    public static DateTime LastDateTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Replace.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isReplacingCommaForDot">The is replacing comma for dot.</param>
    /// <returns>The replace result.</returns>
    public static string Replace(ref string text, bool isReplacingCommaForDot)
    {
        if (isReplacingCommaForDot)
            text = text.Replace(",", ".");
        return text;
    }

    /// <summary>
    /// Is float.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isReplacingCommaForDot">The is replacing comma for dot.</param>
    /// <returns>The is float result.</returns>
    public static bool IsFloat(string text, bool isReplacingCommaForDot = false)
    {
        if (text is null)
            return false;
        Replace(ref text, isReplacingCommaForDot);
        var isParsed = float.TryParse(text.Replace(",", "."), out var parsedFloat);
        LastFloat = parsedFloat;
        return isParsed;
    }

    /// <summary>
    /// Is double.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isReplacingCommaForDot">The is replacing comma for dot.</param>
    /// <returns>The is double result.</returns>
    public static bool IsDouble(string text, bool isReplacingCommaForDot = false)
    {
        if (text is null)
            return false;
        Replace(ref text, isReplacingCommaForDot);
        var isParsed = double.TryParse(text.Replace(",", "."), out var parsedDouble);
        LastDouble = parsedDouble;
        return isParsed;
    }

    // Usage: Exceptions.IsInt.
    /// <summary>
    /// Is int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isReplacingCommaForDot">The is replacing comma for dot.</param>
    /// <returns>The is int result.</returns>
    public static bool IsInt(string text, bool isThrowingExceptionIfFloat = false, bool isReplacingCommaForDot = false)
    {
        if (text is null)
            return false;
        text = text.Replace(" ", "");
        Replace(ref text, isReplacingCommaForDot);
        var result = int.TryParse(text, out var parsedInt);
        LastInt = parsedInt;
        if (!result)
            if (IsFloat(text))
                if (isThrowingExceptionIfFloat)
                    throw new Exception($"{text} is float but is calling IsInt");
        return result;
    }

    /// <summary>
    /// Is long.
    /// </summary>
    /// <param name="".")">The ".").</param>
    /// <param name="parsedDouble">The parsed double.</param>
    /// <returns>The is long result.</returns>
    public static bool IsLong(string text, bool isThrowingExceptionIfDouble = false, bool isReplacingCommaForDot = false)
    {
        if (text is null)
            return false;
        text = text.Replace(" ", "");
        Replace(ref text, isReplacingCommaForDot);
        var result = long.TryParse(text, out var parsedLong);
        LastLong = parsedLong;
        if (!result)
            if (IsDouble(text))
                if (isThrowingExceptionIfDouble)
                    throw new Exception($"{text} is double but is calling IsLong");
        return result;
    }

    /// <summary>
    /// Initializes a new instance of the from hex class.
    /// </summary>
    /// <param name="IsFloat(text)">The is float text.</param>
    public static int FromHex(string hexText)
    {
        return int.Parse(hexText, NumberStyles.HexNumber);
    }

    /// <summary>
    /// Stream from string.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isThrowingExceptionIfDouble">The is throwing exception if double.</param>
    /// <param name="isReplacingCommaForDot">The is replacing comma for dot.</param>
    /// <returns>The stream from string result.</returns>
    public static Stream StreamFromString(string text)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(text);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    /// <summary>
    /// Initializes a new instance of the string from stream class.
    /// </summary>
    /// <param name="IsDouble(text)">The is double text.</param>
    public static string StringFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Try parse bool.
    /// </summary>
    /// <param name="hexText">The hex text.</param>
    /// <returns>The try parse bool result.</returns>
    public static bool TryParseBool(string text)
    {
        var isParsed = bool.TryParse(text, out var parsedBool);
        LastBool = parsedBool;
        return isParsed;
    }

    /// <summary>
    /// Compare as object and string.
    /// </summary>
    /// <returns>The compare as object and string result.</returns>
    public static bool CompareAsObjectAndString(object firstObject, object secondObject)
    {
        var areEqual = false;
        if (firstObject is not null)
        {
            if (secondObject == firstObject)
                areEqual = true;
            else if (secondObject.ToString() == firstObject.ToString())
                areEqual = true;
        }

        return areEqual;
    }

    /// <summary>
    /// Is all equals.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is all equals result.</returns>
    public static bool IsAllEquals(bool value, params bool[] values)
    {
        for (var i = 0; i < values.Length; i++)
            if (value != values[i])
                return false;
        return true;
    }

    /// <summary>
    /// Is in range.
    /// </summary>
    /// <param name="null">The null.</param>
    /// <returns>The is in range result.</returns>
    public static bool IsInRange(int from, int to, int value)
    {
        return from <= value && to >= value;
    }

    /// <summary>
    /// Is.
    /// </summary>
    /// <param name="secondObject.ToString()">The second object to string.</param>
    /// <returns>The is result.</returns>
    public static bool Is(bool value, bool isNegated)
    {
        if (isNegated)
            return !value;
        return value;
    }

    /// <summary>
    /// Get only non null values.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="values">The values.</param>
    /// <returns>The get only non null values result.</returns>
    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var result = new List<string>();
        for (var i = 0; i < args.Length; i++)
        {
            var key = args[i];
            object value = args[++i];
            if (value is not null)
            {
                result.Add(key);
                result.Add(value.ToString()!);
            }
        }

        return result;
    }

    /// <summary>
    /// Get max value for type.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The get max value for type result.</returns>
    public static object GetMaxValueForType(Type type)
    {
        if (type == typeof(byte))
            return byte.MaxValue;
        if (type == typeof(decimal))
            return decimal.MaxValue;
        if (type == typeof(double))
            return double.MaxValue;
        if (type == typeof(short))
            return short.MaxValue;
        if (type == typeof(int))
            return int.MaxValue;
        if (type == typeof(long))
            return long.MaxValue;
        if (type == typeof(float))
            return float.MaxValue;
        if (type == typeof(sbyte))
            return sbyte.MaxValue;
        if (type == typeof(ushort))
            return ushort.MaxValue;
        if (type == typeof(uint))
            return uint.MaxValue;
        if (type == typeof(ulong))
            return ulong.MaxValue;
        throw new Exception("Invalid non-value type in method GetMaxValueForType");
    }

    /// <summary>
    /// Initializes a new instance of the clear endings bytes class.
    /// </summary>
    /// <param name="type">The type.</param>
    public static List<byte> ClearEndingsBytes(List<byte> list)
    {
        var bytes = new List<byte>();
        var shouldAdd = false;
        for (var i = list.Count - 1; i >= 0; i--)
            if (!shouldAdd && list[i] != 0)
            {
                shouldAdd = true;
                var byteToAdd = list[i];
                bytes.Insert(0, byteToAdd);
            }
            else if (shouldAdd)
            {
                var byteToAdd = list[i];
                bytes.Insert(0, byteToAdd);
            }

        if (bytes.Count == 0)
        {
            for (var i = 0; i < list.Count; i++)
                list[i] = 0;
            return list;
        }

        return bytes;
    }

    /// <summary>
    /// Parse int null.
    /// </summary>
    /// <param name="0">The 0.</param>
    /// <param name="byteToAdd">The byte to add.</param>
    /// <returns>The parse int null result.</returns>
    public static int? ParseIntNull(string text)
    {
        if (int.TryParse(text, out var parsedInt))
        {
            LastInt = parsedInt;
            return parsedInt;
        }
        return null;
    }

    /// <summary>
    /// Initializes a new instance of the to string t class.
    /// </summary>
    /// <param name="bytes.Count">The bytes count.</param>
    public static string ToString<T>(T value) where T : notnull
    {
        return value.ToString()!;
    }
}
