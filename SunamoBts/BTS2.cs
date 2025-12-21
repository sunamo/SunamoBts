namespace SunamoBts;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class BTS
{
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name = "v"></param>
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    public static float ParseFloat(string value)
    {
        var result = float.MinValue;
        value = value.Replace(',', '.');
        if (float.TryParse(value, out result))
            return result;
        return result;
    }

    /// <summary>
    ///     Vrátí false v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name = "displayAnchors"></param>
    public static bool ParseBool(string value)
    {
        var result = false;
        if (bool.TryParse(value, out result))
            return result;
        return false;
    }

    /// <summary>
    ///     Vrátí A2 v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name = "displayAnchors"></param>
    public static bool ParseBool(string value, bool defaultValue)
    {
        var result = false;
        if (bool.TryParse(value, out result))
            return result;
        return defaultValue;
    }

    public static int ParseInt(string entry, bool mustBeAllNumbers)
    {
        int result;
        if (!int.TryParse(entry, out result))
            if (mustBeAllNumbers)
                return int.MinValue;
        return result;
    }

    public static double ParseDouble(string entry, double defaultValue)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        double parsedValue = 0;
        if (double.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static int ParseInt(string entry, int defaultValue)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        var parsedValue = 0;
        if (int.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static byte ParseByte(string entry, byte defaultValue)
    {
        byte parsedValue = 0;
        if (byte.TryParse(entry, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static bool IsByte(string value)
    {
        if (value == null)
            return false;
        return byte.TryParse(value, out lastByte);
    }

    public static bool IsByte(string value, out byte result)
    {
        if (value == null)
        {
            result = 0;
            return false;
        }

        //byte b2 = 0;
        var parseResult = byte.TryParse(value, out result);
        //b = b2;
        return parseResult;
    }

    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name = "v"></param>
    public static bool IntToBool(object value)
    {
        var text = value.ToString().Trim();
        if (text == string.Empty)
            return false;
        return Convert.ToBoolean(int.Parse(text));
    }

    private const string Yes = "Yes";
    private const string No = "No";
    private const string Ano = "Ano";
    private const string Ne = "Ne";
    private const string One = "1";
    private const string Zero = "0";
    /// <summary>
    ///     G bool repr. A1. Pro Yes true, JF.
    /// </summary>
    /// <param name = "s"></param>
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano)
            return true;
        return false;
    }

    /// <summary>
    ///     G str rep. pro A1 - Ano/Ne
    /// </summary>
    /// <param name = "v"></param>
    public static string BoolToString(bool value)
    {
        if (value)
            return Ano;
        return Ne;
    }

    public static string BoolToString(bool value, bool toLower = false)
    {
        string result = null;
        if (value)
            result = Yes;
        else
            result = No;
        if (toLower)
        {
            return result.ToLower();
        }

        return result;
    }

    public static List<byte> ConvertFromUtf8ToBytes(string text)
    {
        return Encoding.UTF8.GetBytes(text).ToList();
    }

    public static string ConvertFromBytesToUtf8(List<byte> bytes)
    {
        //NH.RemoveEndingZeroPadding(bajty);
        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    public static bool FalseOrNull(object value)
    {
        return value == null || value.ToString() == false.ToString();
    }

    public static List<string> CastArrayObjectToString(object[] args)
    {
        var result = new List<string>(args.Length);
        //CA.InitFillWith(vr, args.Length);
        for (var i = 0; i < args.Length; i++)
            result[i] = args[i].ToString();
        return result;
    }

    public static List<string> CastArrayIntToString(int[] numbers)
    {
        var result = new List<string>(numbers.Length);
        for (var i = 0; i < numbers.Length; i++)
            result[i] = numbers[i].ToString();
        return result;
    }

    public static List<int> CastToIntList<U>(IList<U> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    /// <summary>
    ///     Pokud se cokoliv nepodaří přetypovat, vyhodí výjimku
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name = "collection"></param>
    public static List<int> CastCollectionStringToInt(IList<string> collection)
    {
        return CAToNumber.ToNumber(int.Parse, collection);
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "list"></param>
    public static void RemoveNotNumber(IList list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!double.TryParse(list[i].ToString(), out var _))
                list.RemoveAt(i);
    }

    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name = "numbers"></param>
    public static List<int> CastCollectionShortToInt(List<short> numbers)
    {
        var result = new List<int>();
        for (var i = 0; i < numbers.Count; i++)
            result.Add(numbers[i]);
        return result;
    }

    public static List<short> CastCollectionIntToShort(List<int> numbers)
    {
        var result = new List<short>(numbers.Count);
        for (var i = 0; i < numbers.Count; i++)
            result.Add((short)numbers[i]);
        return result;
    }
}