// variables names: ok
namespace SunamoBts._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
internal sealed partial class Exceptions
{
    #region Other
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceString = stackTrace.ToString();
        var lines = stackTraceString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var item = lines[i];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }
    internal static void TypeAndMethodName(string line, out string type, out string methodName)
    {
        var contentAfterAt = line.Split("at ")[1].Trim();
        var text = contentAfterAt.Split("(")[0];
        var parts= text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }
    internal static string CallingMethod(int depth= 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(depth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    readonly static StringBuilder sbAdditionalInfoInner = new();
    readonly static StringBuilder sbAdditionalInfo = new();
    #endregion

    #region OnlyReturnString
    internal static string? BadFormatOfElementInList(string before, object elementValue, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elementValue) +
        " in list " + listName;
    }
    #endregion
    internal static string? NotInt(string before, string what, int? depth)
    {
        return !depth.HasValue ? CheckBefore(before) + what + " is not with value " + depth+ " valid integer number" : null;
    }
}