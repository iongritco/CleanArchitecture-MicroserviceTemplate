using MicroserviceTemplate.Application.Interfaces;
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Persistence.ToDo;

public class ToDoCommandRepository : IToDoCommandRepository
{
    private readonly ToDoDataContext _toDoDataContext;

    public ToDoCommandRepository(ToDoDataContext toDoDataContext)
    {
        _toDoDataContext = toDoDataContext;
    }

    public async Task CreateToDo(ToDoItem toDo)
    {
        _toDoDataContext.Add(toDo);
        await _toDoDataContext.SaveChangesAsync();
    }
}
