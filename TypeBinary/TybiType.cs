using Newtonsoft.Json.Linq;

namespace TypeBinary;

public class TybiType
{
    internal TybiType(JToken json)
    {
        
    }

    public string Name { get; set; }

    public static TybiType? Decode(string name, TomlValue toml)
    {
        var properties = Toml
    }
}