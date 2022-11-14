using MediatR;
using MicroserviceTemplate.Domain.Enums;

namespace MicroserviceTemplate.Application.ToDo.Events.TaskCreatedEvent
{
    public class TaskCreatedEvent : INotification
    {
        public string Email { get; }

        public string Description { get; }

        public Status Status { get; }

        public TaskCreatedEvent(string email, string description, Status status)
        {
            Email = email;
            Description = description;
            Status = status;
        }
    }
}
