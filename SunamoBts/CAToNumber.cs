namespace SunamoBts;

// Collection Array To Number - utilities for converting collections and arrays to numeric types.
public class CAToNumber
{
    // Default value will be used when a parsed element is not a number to return a recognizable bad value.
    public static List<T> ToNumber<T>(Func<string, T, T> parseMethod, IList list, T defaultValue,
        bool isRequiringAllNumbers = true)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            var number = parseMethod.Invoke(item.ToString()!, defaultValue);
            if (isRequiringAllNumbers)
                if (EqualityComparer<T>.Default.Equals(number, defaultValue))
                {
                    ThrowEx.BadFormatOfElementInList(item, nameof(list), SH.NullToStringOrDefault);
                    return null!;
                }

            if (!EqualityComparer<T>.Default.Equals(number, defaultValue)) result.Add(number);
        }

        return result;
    }

    public static List<int>? ToIntWithLengthValidation(IList list, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength);
    }

    // If the list does not have the required length or an element cannot be parsed to T, returns null.
    public static List<T>? ToNumber<T>(Func<string, T, T> parseMethod, IList list, int requiredLength)
    {
        var listCount = list.Count;
        if (listCount != requiredLength) return null;

        var result = new List<T>();
        var defaultValue = default(T);
        foreach (var item in list)
        {
            var parsedValue = parseMethod.Invoke(item.ToString()!, defaultValue!);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
                result.Add(parsedValue);
            else
                return null;
        }

        return result;
    }

    // If you need to return null when something doesn't fit, use ToIntWithLengthValidation or ToIntWithLengthValidationAndOffset.
    public static List<int> ToIntTruncating(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].Replace(',', '.');
            list[i] = list[i].Substring(0, list[i].IndexOf('.') + 1);
        }

        return ToNumber(int.Parse, list);
    }

    public static List<int>? ToIntWithLengthValidationAndOffset(IList list, int requiredLength, int startFrom)
    {
        return ToNumber(BTS.TryParseInt, list, requiredLength, startFrom);
    }

    // For use with requireAllNumbers, must use other parse func than default .NET.
    public static List<T> ToNumber<T, U>(Func<string, T> parseMethod, IList<U> list)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (item?.ToString() == "NA") continue;

            if (double.TryParse(item?.ToString(), out _))
            {
                var number = parseMethod.Invoke(item!.ToString()!);
                result.Add(number);
            }
        }

        return result;
    }

    // If an element in the list cannot be parsed to T, returns null.
    public static List<T>? ToNumber<T>(Func<string, T, T> parseMethod, IList list, int requiredLength, T startFrom)
        where T : IComparable
    {
        var finalLength = list.Count - int.Parse(startFrom.ToString()!);
        if (finalLength < requiredLength) return null;
        var result = new List<T>(finalLength);

        var currentIndex = default(T);
        foreach (var item in list)
        {
            if (currentIndex?.CompareTo(startFrom) != 0) continue;

            var defaultValue = default(T);
            var parsedValue = parseMethod.Invoke(item.ToString()!, defaultValue!);
            if (!EqualityComparer<T>.Default.Equals(parsedValue, defaultValue))
                result.Add(parsedValue);
            else
                return null;
        }

        return result;
    }
}
