using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName).NotNull();
        RuleFor(u => u.FirstName).NotEmpty();

        RuleFor(u => u.LastName).NotNull();
        RuleFor(u => u.LastName).NotEmpty();

        RuleFor(u => u.Email).NotNull();
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
    }
}