namespace SunamoBts;

public partial class BTS
{
    public static int LastInt { get; set; } = -1;
    public static long LastLong { get; set; } = -1;
    public static float LastFloat { get; set; } = -1;
    public static double LastDouble { get; set; } = -1;
    public static byte LastByte { get; set; } = 255;
    public static bool LastBool { get; set; }
    public static DateTime LastDateTime { get; set; } = DateTime.MinValue;

    public static string Replace(ref string text, bool isReplacingCommaForDot)
    {
        if (isReplacingCommaForDot)
            text = text.Replace(",", ".");
        return text;
    }

    public static bool IsFloat(string text, bool isReplacingCommaForDot = false)
    {
        if (text is null)
            return false;
        Replace(ref text, isReplacingCommaForDot);
        var isParsed = float.TryParse(text.Replace(",", "."), out var parsedFloat);
        LastFloat = parsedFloat;
        return isParsed;
    }

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

    public static int FromHex(string hexText)
    {
        return int.Parse(hexText, NumberStyles.HexNumber);
    }

    public static Stream StreamFromString(string text)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(text);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public static string StringFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public static bool TryParseBool(string text)
    {
        var isParsed = bool.TryParse(text, out var parsedBool);
        LastBool = parsedBool;
        return isParsed;
    }

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

    public static bool IsAllEquals(bool value, params bool[] values)
    {
        for (var i = 0; i < values.Length; i++)
            if (value != values[i])
                return false;
        return true;
    }

    public static bool IsInRange(int from, int to, int value)
    {
        return from <= value && to >= value;
    }

    public static bool Is(bool value, bool isNegated)
    {
        if (isNegated)
            return !value;
        return value;
    }

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

    public static int? ParseIntNull(string text)
    {
        if (int.TryParse(text, out var parsedInt))
        {
            LastInt = parsedInt;
            return parsedInt;
        }
        return null;
    }

    public static string ToString<T>(T value) where T : notnull
    {
        return value.ToString()!;
    }
}
