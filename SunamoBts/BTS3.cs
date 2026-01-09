// variables names: ok
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

    /// <summary>
    /// Pads a number with leading zeros to ensure at least 3 digits
    /// </summary>
    /// <param name="number">The number to pad</param>
    /// <returns>A string representation with leading zeros if the number has less than 3 digits</returns>
    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitCount = number.ToString().Length;
        if (digitCount == 1)
            return "0" + number;
        if (digitCount == 2)
            return "00" + number;
        return number;
    }

    /// <summary>
    /// Pads a number with a leading zero to ensure at least 2 digits
    /// </summary>
    /// <param name="number">The number to pad</param>
    /// <returns>A string representation with a leading zero if the number has only 1 digit</returns>
    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1)
            return "0" + number;
        return number;
    }

    /// <summary>
    ///     Does not shorten the year, uses standard 4-digit format
    ///     Produces format as standard text using DateTime.ToString() method
    /// </summary>
    /// <param name = "dateTime"></param>
    public static string SameLengthAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return day + "." + month + "." + year + " " + hour + ":" + minutes + ":" + seconds;
    }

    /// <summary>
    /// Formats a DateTime to a date string with consistent padding (dd.MM.yyyy format)
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <returns>A formatted date string in dd.MM.yyyy format</returns>
    public static string SameLengthAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return day + "." + month + "." + year;
    }

    /// <summary>
    /// Formats a DateTime to a time string with consistent padding (HH:mm:ss format)
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <returns>A formatted time string in HH:mm:ss format</returns>
    public static string SameLengthAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return hour + ":" + minutes + ":" + seconds;
    }

    /// <summary>
    /// Formats a DateTime to a US-style date-time string (M/d/yyyy H:m:s format)
    /// </summary>
    /// <param name="dateTime">The DateTime to format</param>
    /// <returns>A formatted date-time string in US format (M/d/yyyy H:m:s)</returns>
    public static string UsaDateTimeToString(DateTime dateTime)
    {
        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
    }

    /// <summary>
    /// Compares two DateTime values to check if they represent the same date, ignoring time components
    /// </summary>
    /// <param name="firstDateTime">The first DateTime to compare</param>
    /// <param name="secondDateTime">The second DateTime to compare</param>
    /// <returns>True if both dates have the same day, month, and year; otherwise, false</returns>
    public static bool EqualDateWithoutTime(DateTime firstDateTime, DateTime secondDateTime)
    {
        if (firstDateTime.Day == secondDateTime.Day && firstDateTime.Month == secondDateTime.Month && firstDateTime.Year == secondDateTime.Year)
            return true;
        return false;
    }

    /// <summary>
    /// Generates a numbered list of strings from a starting value to a maximum value (inclusive)
    /// </summary>
    /// <param name="from">The starting number</param>
    /// <param name="max">The maximum number (inclusive)</param>
    /// <returns>An array of strings representing numbers from the start to max value</returns>
    public static string[] GetNumberedListFromTo(int from, int max)
    {
        max++;
        var result = new List<string>();
        for (var i = from; i < max; i++)
            result.Add(i.ToString());
        return result.ToArray();
    }

    /// <summary>
    /// Generates a numbered list of strings with a custom postfix from a starting value to a maximum value
    /// </summary>
    /// <param name="start">The starting number</param>
    /// <param name="max">The count of numbers to generate</param>
    /// <param name="postfix">The postfix to append to each number (default is ". ")</param>
    /// <returns>A list of strings with numbers and the specified postfix</returns>
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