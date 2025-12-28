namespace SunamoBts._sunamo;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal class SH
{
    internal static string NullToStringOrDefault(object value)
    {
        return value== null ? " " + "(null)" : " " + value;
    }
}