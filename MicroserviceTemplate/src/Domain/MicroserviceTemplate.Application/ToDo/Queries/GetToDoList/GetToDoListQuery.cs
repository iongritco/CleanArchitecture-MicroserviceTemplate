using MediatR;
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Application.ToDo.Queries.GetToDoList
{
    public class GetToDoListQuery : IRequest<List<ToDoItem>>
    {
        public GetToDoListQuery(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
    }
}
