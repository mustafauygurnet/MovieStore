using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class OperationClaimValidator : AbstractValidator<OperationClaim>
{
    public OperationClaimValidator()
    {
        RuleFor(o => o.OperationClaimName).NotNull();
        RuleFor(o => o.OperationClaimName).NotEmpty();
    }
}