namespace TypeBinary.Exceptions;

public class TybiTypeReadException : Exception
{
    public string TypeName { get; private set; }

    public TybiTypeReadException(string typeName, string message) : base(message)
    {
        TypeName = typeName;
    }
}