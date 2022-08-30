using System.Diagnostics.CodeAnalysis;
using SampleWebApi.Model;

namespace SampleWebApi.Data;

public class TodoItemRepository
{
    private readonly Dictionary<Guid, TodoItem> _todoItems = new();

    public TodoItemRepository()
    {
        TryAdd(new TodoItem(Guid.Parse("e5f6ad2f-389a-48f8-a85d-23516f4e04fe"), "Do the dishes", TodoItemCategory.Chores));
        TryAdd(new TodoItem(Guid.Parse("c98ab2e7-2ac0-4c57-a653-a2e84b261a61"), "Buy some milk", TodoItemCategory.Groceries));
    }

    public IReadOnlyCollection<TodoItem> GetAll() => _todoItems.Values;

    public bool TryGetById(Guid id, [NotNullWhen(true)] out TodoItem? item) => _todoItems.TryGetValue(id, out item);

    public bool TryAdd(TodoItem item) => _todoItems.TryAdd(item.Id, item);

    public bool TryUpdate(Guid id, Func<TodoItem, TodoItem> update, [NotNullWhen(true)] out TodoItem? updatedItem)
    {
        if (_todoItems.TryGetValue(id, out var item))
        {
            updatedItem = _todoItems[id] = update(item);
            return true;
        }

        updatedItem = default;
        return false;
    }

    public bool TryRemove(Guid id, [NotNullWhen(true)] out TodoItem? deletedItem) => _todoItems.Remove(id, out deletedItem);
}