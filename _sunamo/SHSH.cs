namespace SunamoBts._sunamo;

public class SHSH
{
    public static Func<string, string> FromSpace160To32;
    public static Func<string, char[], bool> IsNumber;
    public static Func<int, int, string> MakeUpToXChars;
    public static Func<string, char> GetFirstChar;
    public static Func<string, char, string> RemoveAfterFirstChar;
}