namespace SunamoBts;

public class CAToNumber
{
    /// <summary>
    ///     U will be use when parsed element wont be number to return never-excepted value and recognize bad value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parse"></param>
    /// <param name="enumerable"></param>
    /// <param name="mustBeAllNumbers"></param>
    /// <returns></returns>
    public static List<T> ToNumber<T>(Func<string, T, T> parse, IList enumerable, T defVal,
        bool mustBeAllNumbers = true)
    {
        var result = new List<T>();
        foreach (var item in enumerable)
        {
            var number = parse.Invoke(item.ToString(), defVal);
            if (mustBeAllNumbers)
                if (EqualityComparer<T>.Default.Equals(number, defVal))
                {
                    ThrowEx.BadFormatOfElementInList(item, nameof(enumerable), SH.NullToStringOrDefault);
                    return null;
                }

            if (!EqualityComparer<T>.Default.Equals(number, defVal)) result.Add(number);
        }

        return result;
    }


    public static List<int> ToInt1(IList enumerable, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, enumerable, requiredLength);
    }

    /// <summary>
    ///     Pokud A1 nebude mít délku A2 nebo prvek v A1 nebude vyparsovatelný na int, vrátí null
    /// </summary>
    /// <param name="altitudes"></param>
    /// <param name="requiredLength"></param>
    public static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList enumerable, int requiredLength)
    {
        var enumerableCount = enumerable.Count;
        if (enumerableCount != requiredLength) return null;

        var result = new List<T>();
        var y = default(T);
        foreach (var item in enumerable)
        {
            var yy = tryParse.Invoke(item.ToString(), y);
            if (!EqualityComparer<T>.Default.Equals(yy, y))
                result.Add(yy);
            else
                return null;
        }

        return result;
    }

    /// <summary>
    ///     Pokud potřebuješ vrátit null když něco nebude sedět, použij ToInt s parametry nebo ToIntMinRequiredLength
    ///     Poslední číslo je počet parametrů navíc po seznamu stringů
    /// </summary>
    /// <param name="altitudes"></param>
    public static List<int> ToInt0(List<string> ts)
    {
        //var ts = CA.ToListStringIEnumerable2(enumerable);

        for (var i = 0; i < ts.Count; i++)
        {
            ts[i] = ts[i].Replace(',', '.');
            ts[i] = ts[i].Substring(0, ts[i].IndexOf('.') + 1);
        }

        //CAChangeContent.ChangeContent0(null, ts, d => d.Replace(',', '.'));
        //CAChangeContent.ChangeContent0(null, ts, d => d.Substring(0, d.IndexOf('.') + 1));

        return ToNumber(int.Parse, ts);
    }

    public static List<int> ToInt2(IList altitudes, int requiredLength, int startFrom)
    {
        return ToNumber(BTS.TryParseInt, altitudes, requiredLength, startFrom);
    }

    /// <summary>
    ///     For use with mustBeAllNumbers, must use other parse func than default .net
    ///     A2 is without genericity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parse"></param>
    /// <param name="enumerable"></param>
    /// <param name="mustBeAllNumbers"></param>
    /// <returns></returns>
    public static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> enumerable)
    {
        var result = new List<T>();
        foreach (var item in enumerable)
        {
            if (item.ToString() == "NA") continue;

            if (double.TryParse(item.ToString(),
                    out var _) /*SH.IsNumber(item.ToString(), new Char[] { ',', '.', '-' })*/
               )
            {
                var number = parse.Invoke(item.ToString());

                result.Add(number);
            }
        }

        return result;
    }

    /// <summary>
    ///     Pokud prvek v A1 nebude vyparsovatelný na int, vrátí null
    /// </summary>
    /// <param name="altitudes"></param>
    /// <param name="requiredLength"></param>
    public static List<T> ToNumber<T>(Func<string, T, T> tryParse, IList altitudes, int requiredLength, T startFrom)
        where T : IComparable
    {
        var finalLength = altitudes.Count - int.Parse(startFrom.ToString());
        if (finalLength < requiredLength) return null;
        var vr = new List<T>(finalLength);

        var i = default(T);
        foreach (var item in altitudes)
        {
            if (i.CompareTo(startFrom) != 0) continue;

            var y = default(T);
            var yy = tryParse.Invoke(item.ToString(), y);
            if (!EqualityComparer<T>.Default.Equals(yy, y))
                vr.Add(yy);
            else
                return null;
        }

        return vr;
    }
}