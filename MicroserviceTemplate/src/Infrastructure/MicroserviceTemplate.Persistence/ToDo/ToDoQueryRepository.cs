using MicroserviceTemplate.Application.Interfaces;
using MicroserviceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTemplate.Persistence.ToDo;

public class ToDoQueryRepository : IToDoQueryRepository
{
    private readonly ToDoDataContext _toDoDataContext;

    public ToDoQueryRepository(ToDoDataContext toDoDataContext)
    {
        _toDoDataContext = toDoDataContext;
        _toDoDataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<IEnumerable<ToDoItem>> GetToDoList(string username)
    {
        return await _toDoDataContext.ToDoItems.Where(x => x.Username.Equals(username)).ToListAsync();
    }
}
