namespace SunamoBts;

public partial class BTS
{
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name = "value"></param>
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    /// <summary>
    /// Parses a string value to a float, replacing comma with dot for decimal separation
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <returns>The parsed float value or float.MinValue if parsing fails</returns>
    public static float ParseFloat(string value)
    {
        var result = float.MinValue;
        value = value.Replace(',', '.');
        if (float.TryParse(value, out result))
            return result;
        return result;
    }

    /// <summary>
    ///     Returns false if parsing fails
    /// </summary>
    /// <param name = "value"></param>
    public static bool ParseBool(string value)
    {
        var result = false;
        if (bool.TryParse(value, out result))
            return result;
        return false;
    }

    /// <summary>
    ///     Returns the default value if parsing fails
    /// </summary>
    /// <param name = "value">The string value to parse</param>
    /// <param name = "defaultValue">The default value to return if parsing fails</param>
    /// <returns>Parsed boolean value or default value if parsing fails</returns>
    public static bool ParseBool(string value, bool defaultValue)
    {
        var result = false;
        if (bool.TryParse(value, out result))
            return result;
        return defaultValue;
    }

    /// <summary>
    /// Parses a string value to an int with optional strict parsing requirement
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="isRequiringAllNumbers">If true, returns int.MinValue when parsing fails; otherwise, returns 0</param>
    /// <returns>The parsed int value, int.MinValue if strict mode fails, or 0 if non-strict mode fails</returns>
    public static int ParseInt(string value, bool isRequiringAllNumbers)
    {
        int result;
        if (!int.TryParse(value, out result))
            if (isRequiringAllNumbers)
                return int.MinValue;
        return result;
    }

    /// <summary>
    /// Parses a string value to a double, removing spaces before parsing
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed double value or the specified default value if parsing fails</returns>
    public static double ParseDouble(string value, double defaultValue)
    {
        value = value.Replace(" ", string.Empty);
        double parsedValue = 0;
        if (double.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parses a string value to an int, removing spaces before parsing
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed int value or the specified default value if parsing fails</returns>
    public static int ParseInt(string value, int defaultValue)
    {
        value = value.Replace(" ", string.Empty);
        var parsedValue = 0;
        if (int.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Parses a string value to a byte with a default value
    /// </summary>
    /// <param name="value">The string value to parse</param>
    /// <param name="defaultValue">The default value to return if parsing fails</param>
    /// <returns>The parsed byte value or the specified default value if parsing fails</returns>
    public static byte ParseByte(string value, byte defaultValue)
    {
        byte parsedValue = 0;
        if (byte.TryParse(value, out parsedValue))
            return parsedValue;
        return defaultValue;
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a byte
    /// </summary>
    /// <param name="value">The string value to validate</param>
    /// <returns>True if the value can be parsed as byte; otherwise, false</returns>
    public static bool IsByte(string value)
    {
        if (value == null)
            return false;
        return byte.TryParse(value, out LastByte);
    }

    /// <summary>
    /// Determines whether the specified string value can be parsed as a byte and outputs the result
    /// </summary>
    /// <param name="value">The string value to validate</param>
    /// <param name="result">When this method returns, contains the parsed byte value if successful, or 0 if parsing failed</param>
    /// <returns>True if the value can be parsed as byte; otherwise, false</returns>
    public static bool IsByte(string value, out byte result)
    {
        if (value == null)
        {
            result = 0;
            return false;
        }

        var parseResult = byte.TryParse(value, out result);
        return parseResult;
    }

    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name = "value"></param>
    public static bool IntToBool(object value)
    {
        var text = value.ToString()!.Trim();
        if (text == string.Empty)
            return false;
        return Convert.ToBoolean(int.Parse(text));
    }

    /// <summary>
    /// Constant representing the English word "Yes"
    /// </summary>
    private const string Yes = "Yes";

    /// <summary>
    /// Constant representing the English word "No"
    /// </summary>
    private const string No = "No";

    /// <summary>
    /// Constant representing the Czech word "Ano" (Yes)
    /// </summary>
    private const string Ano = "Ano";

    /// <summary>
    /// Constant representing the Czech word "Ne" (No)
    /// </summary>
    private const string Ne = "Ne";

    /// <summary>
    /// Constant representing the string "1"
    /// </summary>
    private const string One = "1";

    /// <summary>
    /// Constant representing the string "0"
    /// </summary>
    private const string Zero = "0";
    /// <summary>
    ///     Returns bool representation of the text value. Returns true for Yes, true string, "1", or "Ano"
    /// </summary>
    /// <param name = "text"></param>
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano)
            return true;
        return false;
    }

    /// <summary>
    ///     Returns string representation for the bool value - Ano/Ne (Czech Yes/No)
    /// </summary>
    /// <param name = "value"></param>
    public static string BoolToString(bool value)
    {
        if (value)
            return Ano;
        return Ne;
    }

    /// <summary>
    /// Converts a boolean value to its English string representation (Yes/No)
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <param name="isLowerCase">If true, returns lowercase representation; otherwise, returns capitalized representation</param>
    /// <returns>String representation of the boolean value in English</returns>
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
    /// Converts a UTF-8 string to a list of bytes
    /// </summary>
    /// <param name="text">The string text to convert</param>
    /// <returns>A list of bytes representing the UTF-8 encoded string</returns>
    public static List<byte> ConvertFromUtf8ToBytes(string text)
    {
        return Encoding.UTF8.GetBytes(text).ToList();
    }

    /// <summary>
    /// Converts a list of bytes to a UTF-8 string
    /// </summary>
    /// <param name="bytes">The list of bytes to convert</param>
    /// <returns>A UTF-8 decoded string from the byte array</returns>
    public static string ConvertFromBytesToUtf8(List<byte> bytes)
    {
        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    /// <summary>
    /// Determines whether the specified object value is null or represents a false boolean value
    /// </summary>
    /// <param name="value">The object value to check</param>
    /// <returns>True if the value is null or equals the string representation of false; otherwise, false</returns>
    public static bool FalseOrNull(object value)
    {
        return value == null || value.ToString() == false.ToString();
    }

    /// <summary>
    /// Converts an array of objects to a list of strings
    /// </summary>
    /// <param name="args">The array of objects to convert</param>
    /// <returns>A list of strings representing the string representation of each object</returns>
    public static List<string> CastArrayObjectToString(object[] args)
    {
        var result = new List<string>(args.Length);
        for (var i = 0; i < args.Length; i++)
            result.Add(args[i].ToString()!);
        return result;
    }

    /// <summary>
    /// Converts an array of integers to a list of strings
    /// </summary>
    /// <param name="numbers">The array of integers to convert</param>
    /// <returns>A list of strings representing the string representation of each integer</returns>
    public static List<string> CastArrayIntToString(int[] numbers)
    {
        var result = new List<string>(numbers.Length);
        for (var i = 0; i < numbers.Length; i++)
            result[i] = numbers[i].ToString();
        return result;
    }

    /// <summary>
    /// Casts a generic list to a list of integers
    /// </summary>
    /// <typeparam name="U">The type of elements in the source list</typeparam>
    /// <param name="list">The list to convert</param>
    /// <returns>A list of integers parsed from the source list</returns>
    public static List<int> CastToIntList<U>(IList<U> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }

    /// <summary>
    ///     Throws an exception if any value cannot be cast to int
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
            if (!double.TryParse(list[i]?.ToString(), out var _))
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

    /// <summary>
    /// Converts a list of integers to a list of shorts
    /// </summary>
    /// <param name="numbers">The list of integers to convert</param>
    /// <returns>A list of shorts converted from the integer list</returns>
    public static List<short> CastCollectionIntToShort(List<int> numbers)
    {
        var result = new List<short>(numbers.Count);
        for (var i = 0; i < numbers.Count; i++)
            result.Add((short)numbers[i]);
        return result;
    }
}