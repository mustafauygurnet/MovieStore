using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.MovieId).NotNull();
        RuleFor(o => o.MovieId).NotEmpty();

        RuleFor(o => o.CustomerId).NotNull();
        RuleFor(o => o.CustomerId).NotEmpty();
    }
}