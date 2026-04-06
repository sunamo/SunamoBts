namespace SunamoBts._sunamo;

/// <summary>
/// Cached type references for common .NET types used in type comparisons and parsing operations.
/// </summary>
internal class Types
{
    internal static readonly Type ObjectType = typeof(object);
    internal static readonly Type StringBuilderType = typeof(StringBuilder);
    internal static readonly Type IEnumerableType = typeof(IEnumerable);
    internal static readonly Type StringType = typeof(string);
    internal static readonly Type FloatType = typeof(float);
    internal static readonly Type DoubleType = typeof(double);
    internal static readonly Type IntType = typeof(int);
    internal static readonly Type LongType = typeof(long);
    internal static readonly Type ShortType = typeof(short);
    internal static readonly Type DecimalType = typeof(decimal);
    internal static readonly Type SByteType = typeof(sbyte);
    internal static readonly Type ByteType = typeof(byte);
    internal static readonly Type UShortType = typeof(ushort);
    internal static readonly Type UIntType = typeof(uint);
    internal static readonly Type ULongType = typeof(ulong);
    internal static readonly Type DateTimeType = typeof(DateTime);
    internal static readonly Type BinaryType = typeof(byte[]);
    internal static readonly Type CharType = typeof(char);
    internal static readonly List<Type> AllBasicTypes = new()
    {
        ObjectType, StringType, StringBuilderType, IntType, DateTimeType,
        DoubleType, FloatType, CharType, BinaryType, ByteType, ShortType, BinaryType, LongType, DecimalType, SByteType, UShortType, UIntType, ULongType
    };
    internal static readonly Type ListType = typeof(IList);
    internal static readonly Type BoolType = typeof(bool);
    internal static readonly Type GuidType = typeof(Guid);
}
