namespace SunamoBts;

public partial class BTS
{
    /// <summary>
    /// Int to bool.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The int to bool result.</returns>
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    /// <summary>
    /// Parse float.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse float result.</returns>
    public static float ParseFloat(string text)
    {
        var result = float.MinValue;
        text = text.Replace(',', '.');
        if (float.TryParse(text, out result))
            return result;
        return result;
    }

    /// <summary>
    /// Parse bool.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The parse bool result.</returns>
    public static bool ParseBool(string text)
    {
        var result = false;
        if (bool.TryParse(text, out result))
            return result;
        return false;
    }

    /// <summary>
    /// Parse bool.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse bool result.</returns>
    public static bool ParseBool(string text, bool defaultValue)
    {
        var result = false;
        if (bool.TryParse(text, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="isRequiringAllNumbers">The is requiring all numbers.</param>
    /// <returns>The parse int result.</returns>
    public static int ParseInt(string text, bool isRequiringAllNumbers)
    {
        int result;
        if (!int.TryParse(text, out result))
            if (isRequiringAllNumbers)
                return int.MinValue;
        return result;
    }

    /// <summary>
    /// Parse double.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse double result.</returns>
    public static double ParseDouble(string text, double defaultValue)
    {
        text = text.Replace(" ", string.Empty);
        double parsedValue = 0;
        if (double.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parse int.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse int result.</returns>
    public static int ParseInt(string text, int defaultValue)
    {
        text = text.Replace(" ", string.Empty);
        var parsedValue = 0;
        if (int.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parse byte.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The parse byte result.</returns>
    public static byte ParseByte(string text, byte defaultValue)
    {
        byte parsedValue = 0;
        if (byte.TryParse(text, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Is byte.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is byte result.</returns>
    public static bool IsByte(string text)
    {
        if (text is null)
            return false;
        var isParsed = byte.TryParse(text, out var parsedByte);
        LastByte = parsedByte;
        return isParsed;
    }

    /// <summary>
    /// Is byte.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="result">The result.</param>
    /// <returns>The is byte result.</returns>
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

    /// <summary>
    /// Int to bool.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The int to bool result.</returns>
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
    /// <summary>
    /// String to bool.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The string to bool result.</returns>
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano)
            return true;
        return false;
    }

    // Returns Czech string representation (Ano/Ne).
    /// <summary>
    /// Bool to string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The bool to string result.</returns>
    public static string BoolToString(bool value)
    {
        if (value)
            return Ano;
        return Ne;
    }

    /// <summary>
    /// Bool to string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="isLowerCase">The is lower case.</param>
    /// <returns>The bool to string result.</returns>
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

    /// <summary>
    /// Convert from utf 8 to bytes.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The convert from utf 8 to bytes result.</returns>
    public static List<byte> ConvertFromUtf8ToBytes(string text)
    {
        return Encoding.UTF8.GetBytes(text).ToList();
    }

    /// <summary>
    /// Convert from bytes to utf 8.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The convert from bytes to utf 8 result.</returns>
    public static string ConvertFromBytesToUtf8(List<byte> list)
    {
        return Encoding.UTF8.GetString(list.ToArray());
    }

    /// <summary>
    /// False or null.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The false or null result.</returns>
    public static bool FalseOrNull(object value)
    {
        return value is null || value.ToString() == false.ToString();
    }

    /// <summary>
    /// Cast array object to string.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The cast array object to string result.</returns>
    public static List<string> CastArrayObjectToString(object[] array)
    {
        var result = new List<string>(array.Length);
        for (var i = 0; i < array.Length; i++)
            result.Add(array[i].ToString()!);
        return result;
    }

    /// <summary>
    /// Cast array int to string.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The cast array int to string result.</returns>
    public static List<string> CastArrayIntToString(int[] array)
    {
        var result = new List<string>(array.Length);
        for (var i = 0; i < array.Length; i++)
            result.Add(array[i].ToString());
        return result;
    }

    /// <summary>
    /// Cast to int list u.
    /// </summary>
    /// <typeparam name="U">The type U.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The cast to int list u result.</returns>
    public static List<int> CastToIntList<U>(IList<U> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    // Throws an exception if any value cannot be cast to int.
    // Before use you can call RemoveNotNumber to avoid raising an exception.
    /// <summary>
    /// Cast collection string to int.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The cast collection string to int result.</returns>
    public static List<int> CastCollectionStringToInt(IList<string> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    // Modifies the list directly.
    /// <summary>
    /// Remove not number.
    /// </summary>
    /// <param name="list">The list.</param>
    public static void RemoveNotNumber(IList list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!double.TryParse(list[i]?.ToString(), out _))
                list.RemoveAt(i);
    }

    // Before use you can call RemoveNotNumber to avoid raising an exception.
    /// <summary>
    /// Cast collection short to int.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The cast collection short to int result.</returns>
    public static List<int> CastCollectionShortToInt(List<short> list)
    {
        var result = new List<int>();
        for (var i = 0; i < list.Count; i++)
            result.Add(list[i]);
        return result;
    }

    /// <summary>
    /// Cast collection int to short.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The cast collection int to short result.</returns>
    public static List<short> CastCollectionIntToShort(List<int> list)
    {
        var result = new List<short>(list.Count);
        for (var i = 0; i < list.Count; i++)
            result.Add((short)list[i]);
        return result;
    }
}
