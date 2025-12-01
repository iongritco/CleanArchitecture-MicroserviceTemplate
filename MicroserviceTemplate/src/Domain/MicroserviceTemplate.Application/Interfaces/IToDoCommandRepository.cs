
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Application.Interfaces;

public interface IToDoCommandRepository
{
    Task CreateToDo(ToDoItem toDo);
}
