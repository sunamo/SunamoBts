namespace SunamoBts;

public partial class BTS
{
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    public static float ParseFloat(string text)
    {
        var result = float.MinValue;
        text = text.Replace(',', '.');
        if (float.TryParse(text, out result))
            return result;
        return result;
    }

    public static bool ParseBool(string text)
    {
        var result = false;
        if (bool.TryParse(text, out result))
            return result;
        return false;
    }

    public static bool ParseBool(string text, bool defaultValue)
    {
        var result = false;
        if (bool.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    public static int ParseInt(string text, bool isRequiringAllNumbers)
    {
        int result;
        if (!int.TryParse(text, out result))
            if (isRequiringAllNumbers)
                return int.MinValue;
        return result;
    }

    public static double ParseDouble(string text, double defaultValue)
    {
        text = text.Replace(" ", string.Empty);
        double parsedValue = 0;
        if (double.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static int ParseInt(string text, int defaultValue)
    {
        text = text.Replace(" ", string.Empty);
        var parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static byte ParseByte(string text, byte defaultValue)
    {
        byte parsedValue = 0;
        if (byte.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    public static bool IsByte(string text)
    {
        if (text is null)
            return false;
        var isParsed = byte.TryParse(text, out var parsedByte);
        LastByte = parsedByte;
        return isParsed;
    }

    public static bool IsByte(string text, out byte result)
    {
        if (text is null)
        {
            result = 0;
            return false;
        }

        var parseResult = byte.TryParse(text, out result);
        return parseResult;
    }

    public static bool IntToBool(object value)
    {
        var text = value.ToString()!.Trim();
        if (text == string.Empty)
            return false;
        return Convert.ToBoolean(int.Parse(text));
    }

    private const string Yes = "Yes";
    private const string No = "No";
    private const string Ano = "Ano";
    private const string Ne = "Ne";
    private const string One = "1";

    // Returns true for "Yes", "True", "1", or "Ano" (Czech Yes).
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano)
            return true;
        return false;
    }

    // Returns Czech string representation (Ano/Ne).
    public static string BoolToString(bool value)
    {
        if (value)
            return Ano;
        return Ne;
    }

    public static string BoolToString(bool value, bool isLowerCase = false)
    {
        string result;
        if (value)
            result = Yes;
        else
            result = No;
        if (isLowerCase)
        {
            return result.ToLower();
        }

        return result;
    }

    public static List<byte> ConvertFromUtf8ToBytes(string text)
    {
        return Encoding.UTF8.GetBytes(text).ToList();
    }

    public static string ConvertFromBytesToUtf8(List<byte> list)
    {
        return Encoding.UTF8.GetString(list.ToArray());
    }

    public static bool FalseOrNull(object value)
    {
        return value is null || value.ToString() == false.ToString();
    }

    public static List<string> CastArrayObjectToString(object[] array)
    {
        var result = new List<string>(array.Length);
        for (var i = 0; i < array.Length; i++)
            result.Add(array[i].ToString()!);
        return result;
    }

    public static List<string> CastArrayIntToString(int[] array)
    {
        var result = new List<string>(array.Length);
        for (var i = 0; i < array.Length; i++)
            result.Add(array[i].ToString());
        return result;
    }

    public static List<int> CastToIntList<U>(IList<U> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    // Throws an exception if any value cannot be cast to int.
    // Before use you can call RemoveNotNumber to avoid raising an exception.
    public static List<int> CastCollectionStringToInt(IList<string> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    // Modifies the list directly.
    public static void RemoveNotNumber(IList list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!double.TryParse(list[i]?.ToString(), out _))
                list.RemoveAt(i);
    }

    // Before use you can call RemoveNotNumber to avoid raising an exception.
    public static List<int> CastCollectionShortToInt(List<short> list)
    {
        var result = new List<int>();
        for (var i = 0; i < list.Count; i++)
            result.Add(list[i]);
        return result;
    }

    public static List<short> CastCollectionIntToShort(List<int> list)
    {
        var result = new List<short>(list.Count);
        for (var i = 0; i < list.Count; i++)
            result.Add((short)list[i]);
        return result;
    }
}
