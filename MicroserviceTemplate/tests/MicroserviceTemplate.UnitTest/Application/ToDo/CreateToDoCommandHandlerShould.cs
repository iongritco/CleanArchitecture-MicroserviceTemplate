using AutoFixture.Xunit2;

using MediatR;

using MicroserviceTemplate.Application.Interfaces;
using MicroserviceTemplate.Application.ToDo.Commands.CreateToDo;
using MicroserviceTemplate.Application.ToDo.Events.TaskCreatedEvent;
using MicroserviceTemplate.Domain.Entities;

using Moq;

using Xunit;

namespace MicroserviceTemplate.UnitTests.Application.ToDo;

public class CreateToDoCommandHandlerShould
{
    [Theory]
    [AutoMoqData]
    public async Task ReturnUnitValueWhenSuccessful(
        CreateToDoCommand command,
        [Frozen] Mock<IToDoCommandRepository> todoCommandRepositoryMock,
        [Frozen] Mock<IMediator> mediator,
        CreateToDoCommandHandler sut)
    {
        await sut.Handle(command, CancellationToken.None);

        todoCommandRepositoryMock.Verify(call => call.CreateToDo(
            It.Is<ToDoItem>(x => x.Id.Equals(command.Id) && x.Description.Equals(command.Description) && x.Username.Equals(command.Username))),
            Times.Once);
        mediator.Verify(call => call.Publish(It.IsAny<TaskCreatedEvent>(), CancellationToken.None), Times.Once);
    }
}
