namespace SunamoBts;

/// <summary>
/// Basic Type System utilities for parsing and converting between primitive types.
/// </summary>
public partial class BTS
{
    /// <summary>
    /// Last successfully parsed int value.
    /// </summary>
    public static int LastInt { get; set; } = -1;

    /// <summary>
    /// Last successfully parsed long value.
    /// </summary>
    public static long LastLong { get; set; } = -1;

    /// <summary>
    /// Last successfully parsed float value.
    /// </summary>
    public static float LastFloat { get; set; } = -1;

    /// <summary>
    /// Last successfully parsed double value.
    /// </summary>
    public static double LastDouble { get; set; } = -1;

    /// <summary>
    /// Last successfully parsed byte value.
    /// </summary>
    public static byte LastByte { get; set; } = 255;

    /// <summary>
    /// Last successfully parsed bool value.
    /// </summary>
    public static bool LastBool { get; set; }

    /// <summary>
    /// Last successfully parsed DateTime value.
    /// </summary>
    public static DateTime LastDateTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Replaces comma with dot in the string value if specified.
    /// </summary>
    /// <param name="text">The string value to modify.</param>
    /// <param name="isReplacingCommaForDot">Whether to replace comma with dot.</param>
    /// <returns>Modified string value.</returns>
    public static string Replace(ref string text, bool isReplacingCommaForDot)
    {
        if (isReplacingCommaForDot)
            text = text.Replace(",", ".");
        return text;
    }

    /// <summary>
    /// Checks if the string value can be parsed as a float number.
    /// </summary>
    /// <param name="text">The string value to check.</param>
    /// <param name="isReplacingCommaForDot">Whether to replace comma with dot before parsing.</param>
    /// <returns>True if value can be parsed as float, false otherwise.</returns>
    public static bool IsFloat(string text, bool isReplacingCommaForDot = false)
    {
        if (text == null)
            return false;
        Replace(ref text, isReplacingCommaForDot);
        var isParsed = float.TryParse(text.Replace(",", "."), out var parsedFloat);
        LastFloat = parsedFloat;
        return isParsed;
    }

    /// <summary>
    /// Checks if the string value can be parsed as a double number.
    /// </summary>
    /// <param name="text">The string value to check.</param>
    /// <param name="isReplacingCommaForDot">Whether to replace comma with dot before parsing.</param>
    /// <returns>True if value can be parsed as double, false otherwise.</returns>
    public static bool IsDouble(string text, bool isReplacingCommaForDot = false)
    {
        if (text == null)
            return false;
        Replace(ref text, isReplacingCommaForDot);
        var isParsed = double.TryParse(text.Replace(",", "."), out var parsedDouble);
        LastDouble = parsedDouble;
        return isParsed;
    }

    /// <summary>
    /// Checks if the string value can be parsed as an integer.
    /// Usage: Exceptions.IsInt.
    /// </summary>
    /// <param name="text">The string value to check.</param>
    /// <param name="isThrowingExceptionIfFloat">Whether to throw an exception if the value is a float number.</param>
    /// <param name="isReplacingCommaForDot">Whether to replace comma with dot before parsing.</param>
    /// <returns>True if value can be parsed as int, false otherwise.</returns>
    /// <exception cref="Exception">Thrown when value is float and isThrowingExceptionIfFloat is true.</exception>
    public static bool IsInt(string text, bool isThrowingExceptionIfFloat = false, bool isReplacingCommaForDot = false)
    {
        if (text == null)
            return false;
        text = text.Replace(" ", "");
        Replace(ref text, isReplacingCommaForDot);
        var result = int.TryParse(text, out var parsedInt);
        LastInt = parsedInt;
        if (!result)
            if (IsFloat(text))
                if (isThrowingExceptionIfFloat)
                    throw new Exception(text + " is float but is calling IsInt");
        return result;
    }

    /// <summary>
    /// Checks if the string value can be parsed as a long number.
    /// </summary>
    /// <param name="text">The string value to check.</param>
    /// <param name="isThrowingExceptionIfDouble">Whether to throw exception if value is a double number.</param>
    /// <param name="isReplacingCommaForDot">Whether to replace comma with dot before parsing.</param>
    /// <returns>True if value can be parsed as long, false otherwise.</returns>
    /// <exception cref="Exception">Thrown when value is double and isThrowingExceptionIfDouble is true.</exception>
    public static bool IsLong(string text, bool isThrowingExceptionIfDouble = false, bool isReplacingCommaForDot = false)
    {
        if (text == null)
            return false;
        text = text.Replace(" ", "");
        Replace(ref text, isReplacingCommaForDot);
        var result = long.TryParse(text, out var parsedLong);
        LastLong = parsedLong;
        if (!result)
            if (IsDouble(text))
                if (isThrowingExceptionIfDouble)
                    throw new Exception(text + " is double but is calling IsLong");
        return result;
    }

    /// <summary>
    /// Converts hexadecimal string to integer.
    /// </summary>
    /// <param name="hexText">Hexadecimal string value.</param>
    /// <returns>Converted integer value.</returns>
    public static int FromHex(string hexText)
    {
        return int.Parse(hexText, NumberStyles.HexNumber);
    }

    /// <summary>
    /// Creates a Stream from a string.
    /// </summary>
    /// <param name="text">The text to convert to stream.</param>
    /// <returns>MemoryStream containing the text.</returns>
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
    /// Reads all text from a Stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>String containing all text from the stream.</returns>
    public static string StringFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        return text;
    }

    /// <summary>
    /// Tries to parse the string value as a boolean.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>True if parsing succeeded, false otherwise.</returns>
    public static bool TryParseBool(string text)
    {
        var isParsed = bool.TryParse(text, out var parsedBool);
        LastBool = parsedBool;
        return isParsed;
    }

    /// <summary>
    /// Compares two objects by reference and by their string representation.
    /// Checks for null in secondObject before comparison.
    /// </summary>
    /// <param name="firstObject">The first object to compare.</param>
    /// <param name="secondObject">The second object to compare.</param>
    /// <returns>True if objects are equal by reference or string representation; otherwise, false.</returns>
    public static bool CompareAsObjectAndString(object firstObject, object secondObject)
    {
        var areEqual = false;
        if (firstObject != null)
        {
            if (secondObject == firstObject)
                areEqual = true;
            else if (secondObject.ToString() == firstObject.ToString())
                areEqual = true;
        }

        return areEqual;
    }

    /// <summary>
    /// Checks whether all elements in the array have the same value as the first parameter.
    /// </summary>
    /// <param name="value">The value to compare against.</param>
    /// <param name="values">Array of values to check.</param>
    /// <returns>True if all values match, false otherwise.</returns>
    public static bool IsAllEquals(bool value, params bool[] values)
    {
        for (var i = 0; i < values.Length; i++)
            if (value != values[i])
                return false;
        return true;
    }

    /// <summary>
    /// Checks if the value is within the specified range (inclusive).
    /// </summary>
    /// <param name="from">Range start value.</param>
    /// <param name="to">Range end value.</param>
    /// <param name="value">Value to check.</param>
    /// <returns>True if value is in range, false otherwise.</returns>
    public static bool IsInRange(int from, int to, int value)
    {
        return from <= value && to >= value;
    }

    /// <summary>
    /// Returns the value, optionally negated.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <param name="isNegated">Whether to negate the value.</param>
    /// <returns>Original or negated value.</returns>
    public static bool Is(bool value, bool isNegated)
    {
        if (isNegated)
            return !value;
        return value;
    }

    /// <summary>
    /// Returns only non-null key-value pairs from the arguments.
    /// Arguments are expected in alternating key-value order.
    /// </summary>
    /// <param name="args">Array of string arguments in key-value pairs.</param>
    /// <returns>List containing only non-null values.</returns>
    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var result = new List<string>();
        for (var i = 0; i < args.Length; i++)
        {
            var key = args[i];
            object value = args[++i];
            if (value != null)
            {
                result.Add(key);
                result.Add(value.ToString()!);
            }
        }

        return result;
    }

    /// <summary>
    /// Gets the maximum value for a given numeric type.
    /// </summary>
    /// <param name="type">The numeric type to get max value for.</param>
    /// <returns>Maximum value for the type.</returns>
    /// <exception cref="Exception">Thrown when type is not a numeric type.</exception>
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
    /// Removes trailing zero bytes from the list.
    /// </summary>
    /// <param name="list">The list of bytes to process.</param>
    /// <returns>List of bytes with trailing zeros removed.</returns>
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
    /// Parses string to nullable int, returns null if parsing fails.
    /// </summary>
    /// <param name="text">The string value to parse.</param>
    /// <returns>Parsed integer or null if parsing failed.</returns>
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
    /// Converts value to string using ToString method.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <returns>String representation of the value.</returns>
    public static string ToString<T>(T value) where T : notnull
    {
        return value.ToString()!;
    }
}
