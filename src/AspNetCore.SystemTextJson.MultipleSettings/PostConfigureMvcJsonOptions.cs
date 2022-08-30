using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.SystemTextJson.MultipleSettings;

public class PostConfigureMvcJsonOptions : IPostConfigureOptions<MvcOptions>
{
    private readonly string _jsonSettingsName;
    private readonly JsonOptions _jsonOptions;
    private readonly ILoggerFactory _loggerFactory;

    public PostConfigureMvcJsonOptions(
        string jsonSettingsName,
        JsonOptions jsonOptions,
        ILoggerFactory loggerFactory)
    {
        _jsonSettingsName = jsonSettingsName;
        _jsonOptions = jsonOptions;
        _loggerFactory = loggerFactory;
    }

    public void PostConfigure(string name, MvcOptions options)
    {
        var logger = _loggerFactory.CreateLogger<SpecificSystemTextJsonInputFormatter>();
        options.InputFormatters.Insert(0, new SpecificSystemTextJsonInputFormatter(_jsonSettingsName, _jsonOptions, logger));
        options.OutputFormatters.Insert(0, new SpecificSystemTextJsonOutputFormatter(_jsonSettingsName, _jsonOptions.JsonSerializerOptions));
    }
}