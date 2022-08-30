using AspNetCore.SystemTextJson.MultipleSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddJsonOptions(this IMvcBuilder builder, string settingsName, Action<JsonOptions> configure)
    {
        builder.Services.Configure(settingsName, configure);
        builder.Services.AddSingleton<IPostConfigureOptions<MvcOptions>>(sp =>
        {
            var optionsSnapshot = sp.GetRequiredService<IOptionsMonitor<JsonOptions>>();
            var options = optionsSnapshot.Get(settingsName);
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            return new PostConfigureMvcJsonOptions(settingsName, options, loggerFactory);
        });
        return builder;
    }
}