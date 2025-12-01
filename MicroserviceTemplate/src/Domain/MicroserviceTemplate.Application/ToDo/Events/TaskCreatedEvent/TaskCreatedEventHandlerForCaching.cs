using MediatR;
using Microsoft.Extensions.Logging;

namespace MicroserviceTemplate.Application.ToDo.Events.TaskCreatedEvent;

public class TaskCreatedEventHandlerForCaching : INotificationHandler<TaskCreatedEvent>
{
    private readonly ILogger<TaskCreatedEventHandlerForCaching> _logger;

    public TaskCreatedEventHandlerForCaching(ILogger<TaskCreatedEventHandlerForCaching> logger)
    {
        _logger = logger;
    }

    public async Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(50, cancellationToken);
        _logger.LogInformation($"Adding task to cache the following details: description-{notification.Description}, user-{notification.Email}, status-{notification.Status}.");
    }
}
