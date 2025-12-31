namespace SunamoBts;

public class CAToNumber
{
    /// <summary>
    ///     U will be use when parsed element wont be number to return never-excepted value and recognize bad value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parse"></param>
    /// <param name="enumerable"></param>
    /// <param name="isRequiringAllNumbers"></param>
    /// <returns></returns>
    public static List<T> ToNumber<T>(Func<string, T, T> parseMethod, IList list, T defaultValue,
        bool isRequiringAllNumbers = true)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            var number = parseMethod.Invoke(item.ToString(), defaultValue);
            if (isRequiringAllNumbers)
                if (EqualityComparer<T>.Default.Equals(number, defaultValue))
                {
                    ThrowEx.BadFormatOfElementInList(item, nameof(list), SH.NullToStringOrDefault);
                    return null;
                }

            if (!EqualityComparer<T>.Default.Equals(number, defaultValue)) result.Add(number);
        }

        return result;
    }


    public static List<int> ToInt1(IList list, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength);
    }

    /// <summary>
    ///     If A1 does not have length A2 or element in A1 will not be parsable to int, returns null
    /// </summary>
    /// <param name="altitudes"></param>
    /// <param name="requiredLength"></param>
    public static List<T> ToNumber<T>(Func<string, T, T> parseMethod, IList list, int requiredLength)
    {
        var listCount = list.Count;
        if (listCount != requiredLength) return null;

        var result = new List<T>();
        var defaultValue= default(T);
        foreach (var item in list)
        {
            var parsedValue= parseMethod.Invoke(item.ToString(), defaultValue);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
                result.Add(parsedValue);
            else
                return null;
        }

        return result;
    }

    /// <summary>
    ///     If you need to return null when something doesn't fit, use ToInt with parameters or ToIntMinRequiredLength
    ///     The last number is count of additional parameters after list of strings
    /// </summary>
    /// <param name="altitudes"></param>
    public static List<int> ToInt0(List<string> values)
    {
        //var ts = CA.ToListStringIEnumerable2(enumerable);

        for (var i = 0; i < values.Count; i++)
        {
values[i] = values[i].Replace(',', '.');
values[i] = values[i].Substring(0, values[i].IndexOf('.') + 1);
        }

        //CAChangeContent.ChangeContent0(null, ts, d => d.Replace(',', '.'));
        //CAChangeContent.ChangeContent0(null, ts, d => d.Substring(0, d.IndexOf('.') + 1));

        return ToNumber(int.Parse, values);
    }

    public static List<int> ToInt2(IList list, int requiredLength, int startFrom)
    {
        return ToNumber(BTS.TryParseInt, list, requiredLength, startFrom);
    }

    /// <summary>
    ///     For use with isRequiringAllNumbers, must use other parse func than default .net
    ///     A2 is without genericity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parse"></param>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static List<T> ToNumber<T, U>(Func<string, T> parseMethod, IList<U> list)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (item.ToString() == "NA") continue;

            if (double.TryParse(item.ToString(),
                    out var _) /*SH.IsNumber(item.ToString(), new Char[] { ',', '.', '-' })*/
               )
            {
                var number = parseMethod.Invoke(item.ToString());

                result.Add(number);
            }
        }

        return result;
    }

    /// <summary>
    ///     If element in A1 will not be parsable to int, returns null
    /// </summary>
    /// <param name="altitudes"></param>
    /// <param name="requiredLength"></param>
    public static List<T> ToNumber<T>(Func<string, T, T> parseMethod, IList list, int requiredLength, T startFrom)
        where T : IComparable
    {
        var finalLength = list.Count - int.Parse(startFrom.ToString());
        if (finalLength < requiredLength) return null;
        var result= new List<T>(finalLength);

        var currentIndex = default(T);
        foreach (var item in list)
        {
            if (currentIndex.CompareTo(startFrom) != 0) continue;

            var defaultValue= default(T);
            var parsedValue= parseMethod.Invoke(item.ToString(), defaultValue);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
result.Add(parsedValue);
            else
                return null;
        }

        return result;
    }
}