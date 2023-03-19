namespace TypeBinary;

public class TybiProperty
{
    public string Name { get; set; }

    public TybiPropertyType Type { get; set; }

    public TybiProperty(string name, TybiPropertyType type)
    {
        Name = name;
        Type = type;
    }
}
