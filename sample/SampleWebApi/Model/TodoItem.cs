namespace SampleWebApi.Model;

public record TodoItem(Guid Id, string Text, TodoItemCategory Category, bool IsDone = false);

public enum TodoItemCategory
{
    Chores,
    Paperwork,
    Groceries,
    Other
}