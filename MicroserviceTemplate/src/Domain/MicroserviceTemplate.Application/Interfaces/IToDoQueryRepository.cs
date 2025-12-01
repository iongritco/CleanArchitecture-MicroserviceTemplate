
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Application.Interfaces;

public interface IToDoQueryRepository
{
    Task<IEnumerable<ToDoItem>> GetToDoList(string username);
}
