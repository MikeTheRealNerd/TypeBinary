using Newtonsoft.Json.Linq;

namespace TypeBinary;

public class TybiType
{
    private TybiProject project;

    internal TybiType(TybiProject project, string name)
    {
        this.project = project;
        Name = name;
    }

    internal void ParseProperties(JObject json)
    {
        foreach (var property in json.Properties())
        {
            var type = TybiPropertyType.GetKnownTypeFromName(project, (string)property.Value);
            Properties.Add(new(property.Name, type));
        }
    }

    public List<TybiProperty> Properties { get; set; } = new();

    public string Name { get; set; }
}