using MediatR;
using MicroserviceTemplate.Application.Interfaces;
using MicroserviceTemplate.Application.ToDo.Events.TaskCreatedEvent;
using MicroserviceTemplate.Domain.Entities;

namespace MicroserviceTemplate.Application.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        private readonly IToDoCommandRepository _commandRepository;
        private readonly IMediator _mediator;

        public CreateToDoCommandHandler(IToDoCommandRepository commandRepository, IMediator mediator)
        {
            _commandRepository = commandRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDoItem(request.Id, request.Description, request.Username);
            await _commandRepository.CreateToDo(toDo);
            await _mediator.Publish(new TaskCreatedEvent(toDo.Username, toDo.Description, toDo.Status), cancellationToken);

            return Unit.Value;
        }
    }
}
