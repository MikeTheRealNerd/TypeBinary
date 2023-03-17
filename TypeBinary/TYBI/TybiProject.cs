using Tomlet;
using Tomlet.Models;

namespace TypeBinary.TYBI;

public class TybiProject
{
    private TomlDocument toml;

    public TybiProject(TomlDocument document)
    {
        toml = document;
    }

    public TybiProject() : this(TomlDocument.CreateEmpty())
    {

    }

    public static TybiProject OpenProject(string path)
    {
        var doc = TomlParser.ParseFile(path);
        return new TybiProject(doc);
    }
}