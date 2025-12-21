namespace SunamoBts;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class BTS
{
    /// <summary>
    ///     return Func<string , T1> or null
    /// </summary>
    /// <typeparam name = "T1"></typeparam>
    /// <returns></returns>
    public static object MethodForParse<T1>()
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

    public static bool IsDateTime(string value)
    {
        if (value == null)
            return false;
        return DateTime.TryParse(value, out lastDateTime);
    }

    /// <summary>
    ///     POkud bude A1 nevyparsovatelné, vrátí int.MinValue
    ///     Replace spaces
    /// </summary>
    /// <param name = "entry"></param>
    public static int ParseInt(string entry)
    {
        var parsedValue = 0;
        if (int.TryParse(entry.Replace(" ", string.Empty), out parsedValue))
            return parsedValue;
        return int.MinValue;
    }

    public static bool IsBool(string value)
    {
        if (value == null)
            return false;
        return bool.TryParse(value, out lastBool);
    }

    public static byte ParseByte(string entry)
    {
        byte parsedValue = 0;
        if (byte.TryParse(entry, out parsedValue))
            return parsedValue;
        return byte.MinValue;
    }

    public static short ParseShort(string entry)
    {
        return ParseShort(entry, short.MinValue);
    }

    public static short ParseShort(string entry, short defaultValue)
    {
        short parsedValue = 0;
        if (short.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static int? ParseInt(string entry, int? defaultValue)
    {
        var parsedValue = 0;
        if (int.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static string BoolToStringEn(bool value, bool toLower = false)
    {
        string result = null;
        if (value)
            result = "Yes";
        else
            result = "No";
        if (toLower)
        {
            return result.ToLower();
        }

        return result;
    }

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
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMinValueForType");
        return null;
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool shouldInvert)
    {
        if (shouldInvert)
            return !value;
        return value;
    }

    public static T CastToByT<T>(string text, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)text.First();
        return (T)(dynamic)text;
    }

    //private static string Replace(ref string id, bool replace)
    //{
    //    return se.BTS.Replace(ref id, replace);
    //}
    //public static bool IsFloat(string id, bool replace = false)
    //{
    //    return se.BTS.IsFloat(id, replace);
    //}
    //public static bool IsInt(string id, bool excIfIsFloat = false, bool replace = false)
    //{
    //    return se.BTS.IsInt(id, excIfIsFloat, replace);
    //}
    /// <summary>
    ///     For parsing from serialized file use DTHelperEn
    /// </summary>
    /// <param name = "v"></param>
    /// <param name = "ciForParse"></param>
    /// <param name = "defaultValue"></param>
    public static DateTime TryParseDateTime(string value, CultureInfo cultureInfo, DateTime defaultValue)
    {
        var result = defaultValue;
        if (DateTime.TryParse(value, cultureInfo, DateTimeStyles.None, out result))
            return result;
        return defaultValue;
    }

    public static uint lastUint;
    public static bool TryParseUint(string entry)
    {
        // Pokud bude A1 null, výsledek bude false
        return uint.TryParse(entry, out lastUint);
    }

    public static bool TryParseDateTime(string entry)
    {
        if (DateTime.TryParse(entry, out lastDateTime))
            return true;
        return false;
    }

    public static byte TryParseByte(string entry, byte defaultValue)
    {
        var result = defaultValue;
        if (byte.TryParse(entry, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    ///     Vrací vyparsovanou hodnotu pokud se podaří vyparsovat, jinak A2
    /// </summary>
    /// <param name = "p"></param>
    /// <param name = "_default"></param>
    public static bool TryParseBool(string value, bool defaultValue)
    {
        var result = defaultValue;
        if (bool.TryParse(value, out result))
            return result;
        return defaultValue;
    }

    public static int TryParseIntCheckNull(string entry, int defaultValue)
    {
        var parsedValue = 0;
        if (entry == null)
            return parsedValue;
        if (int.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static int TryParseInt(string entry, int defaultValue)
    {
        return TryParseInt(entry, defaultValue, false);
    }

    public static int TryParseInt(string entry, int defaultValue, bool throwException)
    {
        var parsedValue = 0;
        if (int.TryParse(entry, out parsedValue))
            return parsedValue;
        if (throwException)
            ThrowEx.NotInt(entry, null);
        return defaultValue;
    }

    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }
}