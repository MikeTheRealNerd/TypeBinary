using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace TypeBinary;

public class TybiProject
{
    private List<TybiType> types = new();

    public ReadOnlyCollection<TybiType> Types => types.AsReadOnly();

    private TybiProject(JObject json)
    {
        foreach (var type in json.Properties())
        {
            if (type.Value is not JObject typeObj)
                continue;

            types.Add(new(this, type.Name));
        }

        var properties = json.Properties().GetEnumerator();
        for (var a = 0; a < types.Count; a++)
        {
            properties.MoveNext();
            types[a].ParseProperties((JObject)properties.Current.Value);
        }
    }

    public TybiProject() : this(new JObject())
    {

    }

    public static TybiProject OpenProject(string path)
    {
        var doc = JObject.Parse(path);
        return new TybiProject(doc);
    }

    public JObject ExportJson()
    {
        var obj = new JObject();

        foreach (var type in Types)
        {
            var typeObj = new JObject();

            foreach (var property in type.Properties)
            {
                typeObj.Add(property.Name, property.Type.Name);
            }

            obj.Add(type.Name, typeObj);
        }

        return obj;
    }

    public void Save(string path)
    {
        File.WriteAllText(path, ExportJson().ToString());
    }
}