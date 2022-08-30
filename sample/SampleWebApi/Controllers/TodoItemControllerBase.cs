using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Data;
using SampleWebApi.Model;

namespace SampleWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class TodoItemControllerBase : ControllerBase
{
    private readonly TodoItemRepository _repository;

    protected TodoItemControllerBase(TodoItemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<TodoItem>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<TodoItem> GetById(Guid id)
    {
        if (_repository.TryGetById(id, out var item))
            return Ok(item);
        return NotFound();
    }

    [HttpPost]
    public ActionResult<TodoItem> Create(CreateOrUpdateTodoItemRequest request)
    {
        var item = request.Create();
        if (_repository.TryAdd(item))
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
        // Shouldn't happen, since we create the id ourselves
        return Conflict();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<TodoItem> Update(Guid id, CreateOrUpdateTodoItemRequest request)
    {
        if (_repository.TryUpdate(id, request.Update, out var updatedItem))
            return Ok(updatedItem);
        return NotFound();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        if (_repository.TryRemove(id, out _))
            return NoContent();
        return NotFound();
    }
}