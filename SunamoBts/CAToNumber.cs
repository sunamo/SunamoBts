namespace SunamoBts;

/// <summary>
/// Collection Array To Number - utilities for converting collections and arrays to numeric types.
/// </summary>
public class CAToNumber
{
    /// <summary>
    /// Converts an IList to a list of T numbers using a parse method with a default value.
    /// Default value will be used when a parsed element is not a number to return a recognizable bad value.
    /// </summary>
    /// <typeparam name="T">The target numeric type.</typeparam>
    /// <param name="parseMethod">The function to parse each element to type T.</param>
    /// <param name="list">The list of elements to parse.</param>
    /// <param name="defaultValue">The default value to use when parsing fails.</param>
    /// <param name="isRequiringAllNumbers">If true, returns null when any element cannot be parsed.</param>
    /// <returns>A list of parsed numbers, or null if a required element cannot be parsed.</returns>
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

    /// <summary>
    /// Converts an IList to a list of integers with a required length validation.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <param name="requiredLength">The required length of the list.</param>
    /// <returns>A list of integers if successful and length matches; otherwise, null.</returns>
    public static List<int>? ToIntWithLengthValidation(IList list, int requiredLength)
    {
        return ToNumber<int>(BTS.TryParseInt, list, requiredLength);
    }

    /// <summary>
    /// Converts an IList to a list of T numbers with required length validation.
    /// If the list does not have the required length or an element cannot be parsed to T, returns null.
    /// </summary>
    /// <typeparam name="T">The target numeric type.</typeparam>
    /// <param name="parseMethod">The function to parse each element to type T.</param>
    /// <param name="list">The list of elements to parse.</param>
    /// <param name="requiredLength">The required length of the result list.</param>
    /// <returns>A list of parsed numbers if successful and length matches; otherwise, null.</returns>
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

    /// <summary>
    /// Converts a list of strings to a list of integers, truncating decimal parts.
    /// If you need to return null when something doesn't fit, use <see cref="ToIntWithLengthValidation"/> or <see cref="ToIntWithLengthValidationAndOffset"/>.
    /// </summary>
    /// <param name="list">The list of string values to convert.</param>
    /// <returns>A list of integers parsed from the string values.</returns>
    public static List<int> ToIntTruncating(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            list[i] = list[i].Replace(',', '.');
            list[i] = list[i].Substring(0, list[i].IndexOf('.') + 1);
        }

        return ToNumber(int.Parse, list);
    }

    /// <summary>
    /// Converts an IList to a list of integers with required length validation and starting offset.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <param name="requiredLength">The required length of the result list.</param>
    /// <param name="startFrom">The starting index offset to begin parsing from.</param>
    /// <returns>A list of integers if successful and length matches; otherwise, null.</returns>
    public static List<int>? ToIntWithLengthValidationAndOffset(IList list, int requiredLength, int startFrom)
    {
        return ToNumber(BTS.TryParseInt, list, requiredLength, startFrom);
    }

    /// <summary>
    /// Converts a generic IList to a list of T numbers using a simple parse function.
    /// For use with requireAllNumbers, must use other parse func than default .NET.
    /// </summary>
    /// <typeparam name="T">The target numeric type.</typeparam>
    /// <typeparam name="U">The type of elements in the source list.</typeparam>
    /// <param name="parseMethod">The function to parse each element to type T.</param>
    /// <param name="list">The list of elements to parse.</param>
    /// <returns>A list of parsed numbers, skipping elements that are "NA" or cannot be parsed.</returns>
    public static List<T> ToNumber<T, U>(Func<string, T> parseMethod, IList<U> list)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (item?.ToString() == "NA") continue;

            if (double.TryParse(item?.ToString(), out var _))
            {
                var number = parseMethod.Invoke(item!.ToString()!);
                result.Add(number);
            }
        }

        return result;
    }

    /// <summary>
    /// Converts an IList to a list of T numbers with required length validation and a starting offset.
    /// If an element in the list cannot be parsed to T, returns null.
    /// </summary>
    /// <typeparam name="T">The target numeric type that implements IComparable.</typeparam>
    /// <param name="parseMethod">The function to parse each element to type T.</param>
    /// <param name="list">The list of elements to parse.</param>
    /// <param name="requiredLength">The required minimum length of the result list.</param>
    /// <param name="startFrom">The starting offset to begin parsing from.</param>
    /// <returns>A list of parsed numbers if successful; otherwise, null.</returns>
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
