// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoBts._sunamo;
internal class SH
{
    internal static string NullToStringOrDefault(object n)
    {

        return n == null ? " " + "(null)" : " " + n;
    }
}