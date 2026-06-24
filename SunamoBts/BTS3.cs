namespace SunamoBts;

public partial class BTS
{
    // Before use you can call RemoveNotNumber to avoid raising an exception.
    public static List<int> CastListShortToListInt(List<short> list)
    {
        return CastCollectionShortToInt(list);
    }

    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitCount = number.ToString().Length;
        if (digitCount == 1)
            return $"0{number}";
        if (digitCount == 2)
            return $"00{number}";
        return number;
    }

    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1)
            return $"0{number}";
        return number;
    }

    // Does not shorten the year, uses standard 4-digit format.
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

    public static string SameLengthAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return $"{day}.{month}.{year}";
    }

    public static string SameLengthAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return $"{hour}:{minutes}:{seconds}";
    }

    public static string UsaDateTimeToString(DateTime dateTime)
    {
        return $"{dateTime.Month}/{dateTime.Day}/{dateTime.Year} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
    }

    public static bool EqualDateWithoutTime(DateTime firstDateTime, DateTime secondDateTime)
    {
        if (firstDateTime.Day == secondDateTime.Day && firstDateTime.Month == secondDateTime.Month && firstDateTime.Year == secondDateTime.Year)
            return true;
        return false;
    }

    public static string[] GetNumberedListFromTo(int start, int max)
    {
        max++;
        var result = new List<string>();
        for (var i = start; i < max; i++)
            result.Add(i.ToString());
        return result.ToArray();
    }

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
