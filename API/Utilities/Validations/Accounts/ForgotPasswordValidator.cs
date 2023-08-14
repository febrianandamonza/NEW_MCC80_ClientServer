using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts;

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    public ForgotPasswordValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;

        RuleFor(e => e.Email)
            .NotEmpty()
            .WithMessage("Email is requires");
    }
}