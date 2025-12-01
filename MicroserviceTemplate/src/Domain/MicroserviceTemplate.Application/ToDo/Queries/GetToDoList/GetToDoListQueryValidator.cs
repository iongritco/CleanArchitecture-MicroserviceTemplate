using FluentValidation;

namespace MicroserviceTemplate.Application.ToDo.Queries.GetToDoList;

public class GetToDoListQueryValidator : AbstractValidator<GetToDoListQuery>
{
    public GetToDoListQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
    }
}

