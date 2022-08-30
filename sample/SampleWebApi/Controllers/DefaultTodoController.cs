using SampleWebApi.Data;

namespace SampleWebApi.Controllers;

// Will use the "default" JSON settings
public class DefaultTodoController : TodoItemControllerBase
{
    public DefaultTodoController(TodoItemRepository repository) : base(repository)
    {
    }
}