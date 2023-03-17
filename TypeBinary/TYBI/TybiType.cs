using Tomlet.Models;

namespace TypeBinary.TYBI;

public class TybiType
{
    private 

    internal TybiType()
    {

    }

    public string Name { get; set; }

    public static TybiType? Decode(string name, TomlValue toml)
    {
        var properties = Toml
    }
}