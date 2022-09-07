using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(m => m.MovieName).NotNull();
        RuleFor(m => m.MovieName).NotEmpty();

        RuleFor(m => m.MovieYear).NotNull();
        RuleFor(m => m.MovieYear).NotEmpty();
        RuleFor(m => m.MovieYear).GreaterThan(1870);
        RuleFor(m => m.MovieYear).LessThan(DateTime.Now.Year);
        RuleFor(m => m.Price).LessThan(0);
    }
}