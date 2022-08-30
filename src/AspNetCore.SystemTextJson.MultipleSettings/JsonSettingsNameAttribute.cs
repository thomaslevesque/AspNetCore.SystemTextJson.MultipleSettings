namespace AspNetCore.SystemTextJson.MultipleSettings;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly)]
public class JsonSettingsNameAttribute : Attribute
{
    public JsonSettingsNameAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}