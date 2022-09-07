using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class DirectorValidator : AbstractValidator<Director>
{
    public DirectorValidator()
    {
        RuleFor(d => d.FirstName).NotNull();
        RuleFor(d => d.FirstName).NotEmpty();

        RuleFor(d => d.LastName).NotNull();
        RuleFor(d => d.LastName).NotEmpty();
    }
}