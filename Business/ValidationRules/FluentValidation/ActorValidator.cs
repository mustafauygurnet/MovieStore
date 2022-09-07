using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ActorValidator : AbstractValidator<Actor>
{
    public ActorValidator()
    {
        RuleFor(a => a.FirstName).NotNull();
        RuleFor(a => a.FirstName).NotEmpty();

        RuleFor(a => a.LastName).NotNull();
        RuleFor(a => a.LastName).NotEmpty();
    }
}