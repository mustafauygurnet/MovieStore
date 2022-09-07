using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class GenreValidator : AbstractValidator<Genre>
{
    public GenreValidator()
    {
        RuleFor(g => g.GenreName).NotNull();
        RuleFor(g => g.GenreName).NotEmpty();
        
        RuleFor(g => g.GenreName).NotNull();
        RuleFor(g => g.GenreName).NotEmpty();
    }
}