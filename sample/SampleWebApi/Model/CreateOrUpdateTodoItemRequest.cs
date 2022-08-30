namespace SampleWebApi.Model;

public record CreateOrUpdateTodoItemRequest(string Text, TodoItemCategory Category, bool IsDone)
{
    public TodoItem Create() => new(Guid.NewGuid(), Text, Category, IsDone);
    public TodoItem Update(TodoItem item) => item with {Text = Text, Category = Category, IsDone = IsDone};
}