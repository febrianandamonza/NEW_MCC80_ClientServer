using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts;

public class NewAccountValidator : AbstractValidator<NewAccountDto>
{
    public NewAccountValidator()
    {
        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password is required");
        RuleFor(e => e.Otp)
            .NotEmpty().WithMessage("Otp is required");
        RuleFor(e => e.ExpiredDate)
            .NotEmpty().WithMessage("Expired Date is required")
            .GreaterThanOrEqualTo(DateTime.Now.AddYears(10));
        
    }
}