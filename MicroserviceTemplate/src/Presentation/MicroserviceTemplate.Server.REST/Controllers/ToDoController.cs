using MediatR;
using MicroserviceTemplate.Application.ToDo.Commands.CreateToDo;
using MicroserviceTemplate.Application.ToDo.Queries.GetToDoList;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceTemplate.Server.REST.Controllers;

[Route("api/todo")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetToDoList()
    {
        var result = await _mediator.Send(new GetToDoListQuery("AddHereIdentityUser"));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateToDo(CreateToDoCommand command)
    {
        command.Username = "AddHereIdentityUser";
        await _mediator.Send(command);
        return Ok();
    }
}