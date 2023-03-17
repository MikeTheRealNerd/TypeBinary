using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace TypeBinary.TYBI;

public class TybiProject
{
    private List<TybiType> types = new();

    public ReadOnlyCollection<TybiType> Types => types.AsReadOnly();

    public TybiProject(JToken json)
    {
        foreach (var type in json)
        {
            
        }
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