namespace SunamoBts;

public partial class BTS
{
    #region For easy copy from BTSShared64.cs
    public static T CastToByT<T>(string c, bool isChar)
    {
        if (isChar)
        {
            return (T)(dynamic)c.First();
        }
        else
        {
            return (T)(dynamic)c;
        }
    }

    //private static string Replace(ref string id, bool replace)
    //{
    //    return se.BTS.Replace(ref id, replace);
    //}

    //public static bool IsFloat(string id, bool replace = false)
    //{
    //    return se.BTS.IsFloat(id, replace);
    //}

    //public static bool IsInt(string id, bool excIfIsFloat = false, bool replace = false)
    //{
    //    return se.BTS.IsInt(id, excIfIsFloat, replace);
    //}
    #endregion
}
