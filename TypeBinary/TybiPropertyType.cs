using TypeBinary.Exceptions;

namespace TypeBinary;

public class TybiPropertyType
{
    private readonly string? setName = null;

    private TybiPropertyType(string name)
    {
        setName = name;
    }

    public TybiPropertyType(TybiType type)
    {
        Type = type;
    }

    public TybiType? Type { get; set; } = null;

    public string Name => setName ?? Type?.Name ?? string.Empty;

    public static TybiPropertyType Int16 { get; private set; } = new("Int16");
    public static TybiPropertyType Int32 { get; private set; } = new("Int32");
    public static TybiPropertyType Int64 { get; private set; } = new("Int64");
    public static TybiPropertyType UInt16 { get; private set; } = new("UInt16");
    public static TybiPropertyType UInt32 { get; private set; } = new("UInt32");
    public static TybiPropertyType UInt64 { get; private set; } = new("UInt64");
    public static TybiPropertyType Byte { get; private set; } = new("Byte");
    public static TybiPropertyType SByte { get; private set; } = new("SByte");

    public static TybiPropertyType String { get; private set; } = new("String");

    internal static TybiPropertyType GetKnownTypeFromName(TybiProject project, string name)
    {
        var result = name.ToLower() switch
        {
            "int16" => Int16,
            "int32" => Int32,
            "int64" => Int64,
            "uint16" => UInt16,
            "uint32" => UInt32,
            "uint64" => UInt64,
            "byte" => Byte,
            "sbyte" => SByte,
            "string" => String,
            _ => null
        };

        if (result != null)
            return result;

        var type = project.Types.FirstOrDefault(x => x.Name == name);
        if (type == null)
            throw new TybiTypeNotFoundException(name);

        result = new(type);
        return result;
    }
}
