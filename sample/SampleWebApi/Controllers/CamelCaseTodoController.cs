using AspNetCore.SystemTextJson.MultipleSettings;
using SampleWebApi.Data;

namespace SampleWebApi.Controllers;

// Will use the "camelCase" JSON settings
[JsonSettingsName("camelCase")]
public class CamelCaseTodoController : TodoItemControllerBase
{
    public CamelCaseTodoController(TodoItemRepository repository) : base(repository)
    {
    }
}