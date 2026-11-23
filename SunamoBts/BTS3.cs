namespace SunamoBts;

public partial class BTS
{
    // Before use you can call RemoveNotNumber to avoid raising an exception.
    /// <summary>
    /// Cast list short to list int.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The cast list short to list int result.</returns>
    public static List<int> CastListShortToListInt(List<short> list)
    {
        return CastCollectionShortToInt(list);
    }

    /// <summary>
    /// Make up to 3 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 3 numbers to zero result.</returns>
    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitCount = number.ToString().Length;
        if (digitCount == 1)
            return $"0{number}";
        if (digitCount == 2)
            return $"00{number}";
        return number;
    }

    /// <summary>
    /// Make up to 2 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 2 numbers to zero result.</returns>
    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1)
            return $"0{number}";
        return number;
    }

    // Does not shorten the year, uses standard 4-digit format.
    /// <summary>
    /// Same length all date times.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The same length all date times result.</returns>
    public static string SameLengthAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return $"{day}.{month}.{year} {hour}:{minutes}:{seconds}";
    }

    /// <summary>
    /// Same length all dates.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The same length all dates result.</returns>
    public static string SameLengthAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return $"{day}.{month}.{year}";
    }

    /// <summary>
    /// Same length all times.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The same length all times result.</returns>
    public static string SameLengthAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return $"{hour}:{minutes}:{seconds}";
    }

    /// <summary>
    /// Usa date time to string.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <returns>The usa date time to string result.</returns>
    public static string UsaDateTimeToString(DateTime dateTime)
    {
        return $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
    }

    /// <summary>
    /// Equal date without time.
    /// </summary>
    /// <param name="firstDateTime">The first date time.</param>
    /// <param name="secondDateTime">The second date time.</param>
    /// <returns>The equal date without time result.</returns>
    public static bool EqualDateWithoutTime(DateTime firstDateTime, DateTime secondDateTime)
    {
        if (firstDateTime.Day == secondDateTime.Day && firstDateTime.Month == secondDateTime.Month && firstDateTime.Year == secondDateTime.Year)
            return true;
        return false;
    }

    /// <summary>
    /// Get numbered list from to.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="max">The max.</param>
    /// <returns>The get numbered list from to result.</returns>
    public static string[] GetNumberedListFromTo(int start, int max)
    {
        max++;
        var result = new List<string>();
        for (var i = start; i < max; i++)
            result.Add(i.ToString());
        return result.ToArray();
    }

    /// <summary>
    /// Get numbered list from to.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="max">The max.</param>
    /// <param name="postfix">The postfix.</param>
    /// <returns>The get numbered list from to result.</returns>
    public static List<string> GetNumberedListFromTo(int start, int max, string postfix = ". ")
    {
        max++;
        max += start;
        var result = new List<string>();
        for (var i = start; i < max; i++)
            result.Add($"{i}{postfix}");
        return result;
    }
}
