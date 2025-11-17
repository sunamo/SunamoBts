// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoBts;

public class BTS
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
        if (replaceCommaForDot) value= value.Replace(",", ".");

        return value;
    }

    public static bool IsFloat(string value, bool replaceCommaForDot = false)
    {
        if (value== null) return false;

        Replace(ref value, replaceCommaForDot);
        return float.TryParse(value.Replace(",", "."), out lastFloat);
    }

    public static bool IsDouble(string value, bool replaceCommaForDot = false)
    {
        if (value== null) return false;

        Replace(ref value, replaceCommaForDot);
        return double.TryParse(value.Replace(",", "."), out lastDouble);
    }


    /// <summary>
    ///     Usage: Exceptions.IsInt
    /// </summary>
    /// <param name="id"></param>
    /// <param name="excIfIsFloat"></param>
    /// <param name="replaceCommaForDot"></param>
    /// <returns></returns>
    public static bool IsInt(string value, bool excIfIsFloat = false, bool replaceCommaForDot = false)
    {
        if (value== null) return false;
        value= value.Replace(" ", "");
        Replace(ref value, replaceCommaForDot);


        var result= int.TryParse(value, out lastInt);
        if (!result)
            if (IsFloat(value))
                if (excIfIsFloat)
                    throw new Exception(value+ " is float but is calling IsInt");

        return result;
    }

    public static bool IsLong(string value, bool excIfIsDouble = false, bool replaceCommaForDot = false)
    {
        if (value== null) return false;
value= value.Replace(" ", ""); //SHReplace.ReplaceAll4(, "", " ");
        Replace(ref value, replaceCommaForDot);

        var result= long.TryParse(value, out lastLong);
        if (!result)
            if (IsDouble(value))
                if (excIfIsDouble)
                    throw new Exception(value+ " is float but is calling IsInt");

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

    #region Parse*

    public static bool TryParseBool(string value)
    {
        return bool.TryParse(value, out lastBool);
    }

    #endregion


    /// <summary>
    ///     Check for null in A2
    /// </summary>
    /// <param name="firstObject"></param>
    /// <param name="secondObject"></param>
    public static bool CompareAsObjectAndString(object firstObject, object secondObject)
    {
        var areEqual= false;
        if (firstObject!= null)
        {
            if (secondObject== firstObject)
areEqual= true;
            else if (secondObject.ToString() == firstObject.ToString()) areEqual= true;
        }

        return areEqual;
    }

    /// <summary>
    ///     G zda  prvky A2 - Ax jsou hodnoty A1.
    /// </summary>
    /// <param name="hodnota"></param>
    /// <param name="paramy"></param>
    public static bool IsAllEquals(bool value, params bool[] values)
    {
        for (var i = 0; i < values.Length; i++)
            if (value!= values[i])
                return false;
        return true;
    }


    /// <param name="od"></param>
    /// <param name="to"></param>
    /// <param name="value"></param>
    public static bool IsInRange(int from, int to, int value)
    {
        if (value== 100)
        {
        }

        // Here I had opposite signs, now it should be correct
        return from<= value&& to >= value;
    }


    public static bool Is(bool value, bool negate)
    {
        if (negate) return !value;
        return value;
    }

    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var result= new List<string>();
        for (var i = 0; i < args.Length; i++)
        {
            var text = args[i];
            object value= args[++i];
            if (value!= null)
            {
result.Add(text);
result.Add(value.ToString());
            }
        }

        return result;
    }

    #region Get*ValueForType

    public static object GetMaxValueForType(Type type)
    {
        if (type== typeof(byte))
            return byte.MaxValue;
        if (type== typeof(decimal))
            return decimal.MaxValue;
        if (type== typeof(double))
            return double.MaxValue;
        if (type== typeof(short))
            return short.MaxValue;
        if (type== typeof(int))
            return int.MaxValue;
        if (type== typeof(long))
            return long.MaxValue;
        if (type== typeof(float))
            return float.MaxValue;
        if (type== typeof(sbyte))
            return sbyte.MaxValue;
        if (type== typeof(ushort))
            return ushort.MaxValue;
        if (type== typeof(uint))
            return uint.MaxValue;
        if (type== typeof(ulong)) return ulong.MaxValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMaxValueForType");
        return 0;
    }

    #endregion


    public static List<byte> ClearEndingsBytes(List<byte> plainTextBytes)
    {
        var bytes = new List<byte>();
        var shouldAdd= false;
        for (var i = plainTextBytes.Count - 1; i >= 0; i--)
            if (!shouldAdd&& plainTextBytes[i] != 0)
            {
shouldAdd= true;
                var byteToAdd= plainTextBytes[i];
                bytes.Insert(0, byteToAdd);
            }
            else if (shouldAdd)
            {
                var byteToAdd= plainTextBytes[i];
                bytes.Insert(0, byteToAdd);
            }

        if (bytes.Count == 0)
        {
            for (var i = 0; i < plainTextBytes.Count; i++) plainTextBytes[i] = 0;
            return plainTextBytes;
        }

        return bytes;
    }

    public static int? ParseIntNull(string value)
    {
        if (int.TryParse(value, out lastInt)) return lastInt;

        return null;
    }

    public static string ToString<T>(T value)
    {
        return value.ToString();
    }

    /// <summary>
    ///     return Func<string, T1> or null
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <returns></returns>
    public static object MethodForParse<T1>()
    {
        var targetType = typeof(T1);

        #region Same seria as in DefaultValueForTypeT

        #region MyRegion

        if (targetType == Types.tString) return new Func<string, string>(ToString);
        if (targetType == Types.tBool) return new Func<string, bool>(bool.Parse);

        #endregion

        #region Signed numbers

        if (targetType == Types.tFloat) return new Func<string, float>(float.Parse);
        if (targetType == Types.tDouble) return new Func<string, double>(double.Parse);
        if (targetType == typeof(int)) return new Func<string, int>(int.Parse);
        if (targetType == Types.tLong) return new Func<string, long>(long.Parse);
        if (targetType == Types.tShort) return new Func<string, short>(short.Parse);
        if (targetType == Types.tDecimal) return new Func<string, decimal>(decimal.Parse);
        if (targetType == Types.tSbyte) return new Func<string, sbyte>(sbyte.Parse);

        #endregion

        #region Unsigned numbers

        if (targetType == Types.tByte) return new Func<string, byte>(byte.Parse);
        if (targetType == Types.tUshort) return new Func<string, ushort>(ushort.Parse);
        if (targetType == Types.tUint) return new Func<string, uint>(uint.Parse);
        if (targetType == Types.tUlong) return new Func<string, ulong>(ulong.Parse);

        #endregion

        if (targetType == Types.tDateTime) return new Func<string, DateTime>(DateTime.Parse);
        if (targetType == Types.tGuid) return new Func<string, Guid>(Guid.Parse);
        if (targetType == Types.tChar) return new Func<string, char>(text => text[0]);

        #endregion

        return null;
    }

    public static bool IsDateTime(string value)
    {
        if (value== null) return false;
        return DateTime.TryParse(value, out lastDateTime);
    }

    /// <summary>
    ///     POkud bude A1 nevyparsovatelné, vrátí int.MinValue
    ///     Replace spaces
    /// </summary>
    /// <param name="entry"></param>
    public static int ParseInt(string entry)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry.Replace(" ", string.Empty), out lastInt2)) return lastInt2;
        return int.MinValue;
    }

    public static bool IsBool(string value)
    {
        if (value== null) return false;
        return bool.TryParse(value, out lastBool);
    }

    public static byte ParseByte(string entry)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return byte.MinValue;
    }

    public static short ParseShort(string entry)
    {
        return ParseShort(entry, short.MinValue);
    }

    public static short ParseShort(string entry, short defaultValue)
    {
        short lastInt2 = 0;
        if (short.TryParse(entry, out lastInt2)) return lastInt2;
        return defaultValue;
    }

    public static int? ParseInt(string entry, int? defaultValue)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return defaultValue;
    }

    public static string BoolToStringEn(bool value, bool toLower = false)
    {
        string result= null;
        if (value)
result= "Yes";
        else
result= "No";

        if (toLower)
        {
            return result.ToLower();
        }
        return result;
    }

    public static object GetMinValueForType(Type type)
    {
        if (type== typeof(byte))
            return 1;
        if (type== typeof(short))
            return short.MinValue;
        if (type== typeof(int))
            return int.MinValue;
        if (type== typeof(long))
            return long.MinValue;
        if (type== typeof(sbyte))
            return sbyte.MinValue;
        if (type== typeof(ushort))
            return ushort.MinValue;
        if (type== typeof(uint))
            return uint.MinValue;
        if (type== typeof(ulong)) return ulong.MinValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMinValueForType");
        return null;
    }

    /// <summary>
    ///     If has value true, return true. Otherwise return false
    /// </summary>
    /// <param name="value"></param>
    public static bool GetValueOfNullable(bool? value)
    {
        if (value.HasValue) return value.Value;
        return false;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool shouldInvert)
    {
        if (shouldInvert) return !value;
        return value;
    }

    #region For easy copy from BTSShared64.cs

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

    #endregion

    #region TryParse*

    /// <summary>
    ///     For parsing from serialized file use DTHelperEn
    /// </summary>
    /// <param name="v"></param>
    /// <param name="ciForParse"></param>
    /// <param name="defaultValue"></param>
    public static DateTime TryParseDateTime(string value, CultureInfo cultureInfo, DateTime defaultValue)
    {
        var result= defaultValue;

        if (DateTime.TryParse(value, cultureInfo, DateTimeStyles.None, out result)) return result;
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
        if (DateTime.TryParse(entry, out lastDateTime)) return true;
        return false;
    }

    public static byte TryParseByte(string entry, byte defaultValue)
    {
        var result= defaultValue;
        if (byte.TryParse(entry, out result)) return result;
        return defaultValue;
    }


    /// <summary>
    ///     Vrací vyparsovanou hodnotu pokud se podaří vyparsovat, jinak A2
    /// </summary>
    /// <param name="p"></param>
    /// <param name="_default"></param>
    public static bool TryParseBool(string value, bool defaultValue)
    {
        var result= defaultValue;

        if (bool.TryParse(value, out result)) return result;
        return defaultValue;
    }

    public static int TryParseIntCheckNull(string entry, int defaultValue)
    {
        var lastInt = 0;
        if (entry == null) return lastInt;
        if (int.TryParse(entry, out lastInt)) return lastInt;
        return defaultValue;
    }

    public static int TryParseInt(string entry, int defaultValue)
    {
        return TryParseInt(entry, defaultValue, false);
    }

    public static int TryParseInt(string entry, int defaultValue, bool throwException)
    {
        var lastInt = 0;
        if (int.TryParse(entry, out lastInt)) return lastInt;

        if (throwException) ThrowEx.NotInt(entry, null);
        return defaultValue;
    }

    #endregion

    #region int <> bool

    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="v"></param>
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }

    #endregion

    #region Parse*

    public static float ParseFloat(string value)
    {
        var result= float.MinValue;
value= value.Replace(',', '.');
        if (float.TryParse(value, out result)) return result;
        return result;
    }

    /// <summary>
    ///     Vrátí false v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string value)
    {
        var result= false;
        if (bool.TryParse(value, out result)) return result;
        return false;
    }

    /// <summary>
    ///     Vrátí A2 v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string value, bool defaultValue)
    {
        var result= false;
        if (bool.TryParse(value, out result)) return result;
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

        double lastDouble2 = 0;
        if (double.TryParse(entry, out lastDouble2)) return lastDouble2;
        return defaultValue;
    }

    public static int ParseInt(string entry, int defaultValue)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];

        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return defaultValue;
    }


    public static byte ParseByte(string entry, byte defaultValue)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return defaultValue;
    }

    #endregion

    #region Is*

    public static bool IsByte(string value)
    {
        if (value== null) return false;
        return byte.TryParse(value, out lastByte);
    }


    public static bool IsByte(string value, out byte result)
    {
        if (value== null)
        {
            result= 0;
            return false;
        }

        //byte b2 = 0;
        var parseResult= byte.TryParse(value, out result);
        //b = b2;
        return parseResult;
    }

    #endregion

    #region *To*

    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="v"></param>
    public static bool IntToBool(object value)
    {
        var text = value.ToString().Trim();
        if (text == string.Empty) return false;
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
    /// <param name="s"></param>
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano) return true;
        return false;
    }

    /// <summary>
    ///     G str rep. pro A1 - Ano/Ne
    /// </summary>
    /// <param name="v"></param>
    public static string BoolToString(bool value)
    {
        if (value) return Ano;
        return Ne;
    }

    public static string BoolToString(bool value, bool toLower = false)
    {
        string result= null;
        if (value)
result= Yes;
        else
result= No;

        if (toLower)
        {
            return result.ToLower();
        }

        return result;
    }

    #endregion

    #region byte[] <> string

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
        return value== null || value.ToString() == false.ToString();
    }

    #endregion

    #region Casting between array - cant commented because it wasnt visible between

    public static List<string> CastArrayObjectToString(object[] args)
    {
        var result= new List<string>(args.Length);
        //CA.InitFillWith(vr, args.Length);
        for (var i = 0; i < args.Length; i++) result[i] = args[i].ToString();
        return result;
    }

    public static List<string> CastArrayIntToString(int[] numbers)
    {
        var result= new List<string>(numbers.Length);
        for (var i = 0; i < numbers.Length; i++) result[i] = numbers[i].ToString();
        return result;
    }

    #endregion

    #region Casting to List

    public static List<int> CastToIntList<U>(IList<U> list)
    {
        return CAToNumber.ToNumber(int.Parse, list);
    }


    /// <summary>
    ///     Pokud se cokoliv nepodaří přetypovat, vyhodí výjimku
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="collection"></param>
    public static List<int> CastCollectionStringToInt(IList<string> collection)
    {
        return CAToNumber.ToNumber(int.Parse, collection);
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="list"></param>
    public static void RemoveNotNumber(IList list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!double.TryParse(list[i].ToString(), out var _))
                list.RemoveAt(i);
    }

    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="numbers"></param>
    public static List<int> CastCollectionShortToInt(List<short> numbers)
    {
        var result= new List<int>();
        for (var i = 0; i < numbers.Count; i++) result.Add(numbers[i]);
        return result;
    }

    public static List<short> CastCollectionIntToShort(List<int> numbers)
    {
        var result= new List<short>(numbers.Count);
        for (var i = 0; i < numbers.Count; i++) result.Add((short)numbers[i]);
        return result;
    }

    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    public static List<int> CastListShortToListInt(List<short> numbers)
    {
        return CastCollectionShortToInt(numbers);
    }

    #endregion

    #region MakeUpTo*NumbersToZero

    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitCount = number.ToString().Length;
        if (digitCount == 1)
            return "0" + number;
        if (digitCount == 2) return "00" + number;
        return number;
    }

    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1) return "0" + number;
        return number;
    }

    #endregion


    #region Ostatní

    /// <summary>
    ///     Rok nezkracuje, počítá se standardním 4 místným
    ///     Produkuje formát standardní text metodou DateTime.ToString()
    /// </summary>
    /// <param name="dateTime"></param>
    public static string SameLenghtAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return day + "." + month + "." + year + " " + hour + ":" +
               minutes + ":" + seconds; // +":" + miliseconds;
    }

    public static string SameLenghtAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return
            day + "." + month + "." +
            year; // +"" + hour + ":" + minutes + ":" + seconds;// +":" + miliseconds;
    }


    public static string SameLenghtAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return hour + ":" + minutes + ":" + seconds; // +":" + miliseconds;
    }

    public static string UsaDateTimeToString(DateTime dateTime)
    {
        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour +
               ":" + dateTime.Minute + ":" + dateTime.Second; // +":" + miliseconds;
    }

    public static bool EqualDateWithoutTime(DateTime firstDateTime, DateTime secondDateTime)
    {
        if (firstDateTime.Day == secondDateTime.Day && firstDateTime.Month == secondDateTime.Month && firstDateTime.Year == secondDateTime.Year) return true;
        return false;
    }

    #endregion

    #region GetNumberedList*

    /// <param name="p"></param>
    /// <param name="max"></param>
    /// <param name="postfix"></param>
    public static string[] GetNumberedListFromTo(int from, int max)
    {
        max++;
        var result= new List<string>();
        for (var i = from; i < max; i++) result.Add(i.ToString());
        return result.ToArray();
    }

    public static List<string> GetNumberedListFromTo(int start, int max, string postfix = ". ")
    {
        max++;
        max += start;
        var result= new List<string>();
        for (var i = start; i < max; i++) result.Add(i + postfix);
        return result;
    }

    #endregion
}