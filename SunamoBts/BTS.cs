namespace SunamoBts;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class BTS
{
    //        #region  from BTSShared64.cs
    public static int lastInt = -1;
    public static long lastLong = -1;
    public static float lastFloat = -1;
    public static double lastDouble = -1;
    private static Type type = typeof(BTS);
    public static byte lastByte = 255;
    public static bool lastBool;
    public static DateTime lastDateTime = DateTime.MinValue;
    public static string Replace(ref string value, bool replaceCommaForDot)
    {
        if (replaceCommaForDot)
            value = value.Replace(",", ".");
        return value;
    }

    public static bool IsFloat(string value, bool replaceCommaForDot = false)
    {
        if (value == null)
            return false;
        Replace(ref value, replaceCommaForDot);
        return float.TryParse(value.Replace(",", "."), out lastFloat);
    }

    public static bool IsDouble(string value, bool replaceCommaForDot = false)
    {
        if (value == null)
            return false;
        Replace(ref value, replaceCommaForDot);
        return double.TryParse(value.Replace(",", "."), out lastDouble);
    }

    /// <summary>
    ///     Usage: Exceptions.IsInt
    /// </summary>
    /// <param name = "id"></param>
    /// <param name = "excIfIsFloat"></param>
    /// <param name = "replaceCommaForDot"></param>
    /// <returns></returns>
    public static bool IsInt(string value, bool excIfIsFloat = false, bool replaceCommaForDot = false)
    {
        if (value == null)
            return false;
        value = value.Replace(" ", "");
        Replace(ref value, replaceCommaForDot);
        var result = int.TryParse(value, out lastInt);
        if (!result)
            if (IsFloat(value))
                if (excIfIsFloat)
                    throw new Exception(value + " is float but is calling IsInt");
        return result;
    }

    public static bool IsLong(string value, bool excIfIsDouble = false, bool replaceCommaForDot = false)
    {
        if (value == null)
            return false;
        value = value.Replace(" ", ""); //SHReplace.ReplaceAll4(, "", " ");
        Replace(ref value, replaceCommaForDot);
        var result = long.TryParse(value, out lastLong);
        if (!result)
            if (IsDouble(value))
                if (excIfIsDouble)
                    throw new Exception(value + " is float but is calling IsInt");
        return result;
    }

    //        #endregion
    public static int FromHex(string hexValue)
    {
        return int.Parse(hexValue, NumberStyles.HexNumber);
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
        var text = reader.ReadToEnd();
        return text;
    }

    public static bool TryParseBool(string value)
    {
        return bool.TryParse(value, out lastBool);
    }

    /// <summary>
    ///     Check for null in A2
    /// </summary>
    /// <param name = "firstObject"></param>
    /// <param name = "secondObject"></param>
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
    ///     G zda  prvky A2 - Ax jsou hodnoty A1.
    /// </summary>
    /// <param name = "hodnota"></param>
    /// <param name = "paramy"></param>
    public static bool IsAllEquals(bool value, params bool[] values)
    {
        for (var i = 0; i < values.Length; i++)
            if (value != values[i])
                return false;
        return true;
    }

    /// <param name = "od"></param>
    /// <param name = "to"></param>
    /// <param name = "value"></param>
    public static bool IsInRange(int from, int to, int value)
    {
        if (value == 100)
        {
        }

        // Here I had opposite signs, now it should be correct
        return from <= value && to >= value;
    }

    public static bool Is(bool value, bool negate)
    {
        if (negate)
            return !value;
        return value;
    }

    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var result = new List<string>();
        for (var i = 0; i < args.Length; i++)
        {
            var text = args[i];
            object value = args[++i];
            if (value != null)
            {
                result.Add(text);
                result.Add(value.ToString());
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
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMaxValueForType");
        return 0;
    }

    public static List<byte> ClearEndingsBytes(List<byte> plainTextBytes)
    {
        var bytes = new List<byte>();
        var shouldAdd = false;
        for (var i = plainTextBytes.Count - 1; i >= 0; i--)
            if (!shouldAdd && plainTextBytes[i] != 0)
            {
                shouldAdd = true;
                var byteToAdd = plainTextBytes[i];
                bytes.Insert(0, byteToAdd);
            }
            else if (shouldAdd)
            {
                var byteToAdd = plainTextBytes[i];
                bytes.Insert(0, byteToAdd);
            }

        if (bytes.Count == 0)
        {
            for (var i = 0; i < plainTextBytes.Count; i++)
                plainTextBytes[i] = 0;
            return plainTextBytes;
        }

        return bytes;
    }

    public static int? ParseIntNull(string value)
    {
        if (int.TryParse(value, out lastInt))
            return lastInt;
        return null;
    }

    public static string ToString<T>(T value)
    {
        return value.ToString();
    }
}