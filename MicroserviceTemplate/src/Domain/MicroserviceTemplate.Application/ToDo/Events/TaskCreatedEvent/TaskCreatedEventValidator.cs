using FluentValidation;
using MicroserviceTemplate.Domain.Enums;

namespace MicroserviceTemplate.Application.ToDo.Events.TaskCreatedEvent;

public class TaskCreatedEventValidator : AbstractValidator<TaskCreatedEvent>
{
    public TaskCreatedEventValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Status).NotEqual(Status.None);
    }
}
