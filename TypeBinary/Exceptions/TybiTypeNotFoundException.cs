namespace TypeBinary.Exceptions;

public class TybiTypeNotFoundException : Exception
{
    public string TypeName { get; private set; }

    public TybiTypeNotFoundException(string typeName) : base($"Could not find a type matching the name '{typeName}'")
    {
        TypeName = typeName;
    }
}
