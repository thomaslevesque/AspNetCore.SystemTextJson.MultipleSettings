using Microsoft.AspNetCore.Http;

namespace AspNetCore.SystemTextJson.MultipleSettings;

internal static class HttpContextExtensions
{
    public static string? GetJsonSettingsName(this HttpContext context)
    {
        return context.GetEndpoint()?.Metadata.GetMetadata<JsonSettingsNameAttribute>()?.Name;
    }
}