// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoBts;
public partial class BTS
{
    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    public static List<int> CastListShortToListInt(List<short> numbers)
    {
        return CastCollectionShortToInt(numbers);
    }

    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitCount = number.ToString().Length;
        if (digitCount == 1)
            return "0" + number;
        if (digitCount == 2)
            return "00" + number;
        return number;
    }

    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1)
            return "0" + number;
        return number;
    }

    /// <summary>
    ///     Rok nezkracuje, počítá se standardním 4 místným
    ///     Produkuje formát standardní text metodou DateTime.ToString()
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string SameLenghtAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return day + "." + month + "." + year + " " + hour + ":" + minutes + ":" + seconds; // +":" + miliseconds;
    }

    public static string SameLenghtAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return day + "." + month + "." + year; // +"" + hour + ":" + minutes + ":" + seconds;// +":" + miliseconds;
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
        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second; // +":" + miliseconds;
    }

    public static bool EqualDateWithoutTime(DateTime firstDateTime, DateTime secondDateTime)
    {
        if (firstDateTime.Day == secondDateTime.Day && firstDateTime.Month == secondDateTime.Month && firstDateTime.Year == secondDateTime.Year)
            return true;
        return false;
    }

    /// <param name = "p"></param>
    /// <param name = "max"></param>
    /// <param name = "postfix"></param>
    public static string[] GetNumberedListFromTo(int from, int max)
    {
        max++;
        var result = new List<string>();
        for (var i = from; i < max; i++)
            result.Add(i.ToString());
        return result.ToArray();
    }

    public static List<string> GetNumberedListFromTo(int start, int max, string postfix = ". ")
    {
        max++;
        max += start;
        var result = new List<string>();
        for (var i = start; i < max; i++)
            result.Add(i + postfix);
        return result;
    }
}