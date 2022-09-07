using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.FilmId ).NotNull();
        RuleFor(o => o.FilmId).NotEmpty();
        
        RuleFor(o => o.CustomerId ).NotNull();
        RuleFor(o => o.CustomerId).NotEmpty();
    }
}