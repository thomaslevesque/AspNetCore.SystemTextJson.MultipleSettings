using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AspNetCore.SystemTextJson.MultipleSettings;

public class SpecificSystemTextJsonOutputFormatter : SystemTextJsonOutputFormatter
{
    public SpecificSystemTextJsonOutputFormatter(string settingsName, JsonSerializerOptions jsonSerializerOptions) : base(jsonSerializerOptions)
    {
        SettingsName = settingsName;
    }

    public string SettingsName { get; }

    public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        if (context.HttpContext.GetJsonSettingsName() != SettingsName)
            return false;

        return base.CanWriteResult(context);
    }
}