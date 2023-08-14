using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles;

public class NewAccountRoleValidator : AbstractValidator<NewAccountRoleDto>
{
    public NewAccountRoleValidator()
    {
        RuleFor(ar => ar.AccountGuid)
            .NotEmpty().WithMessage("Account Guid is required");
        RuleFor(ar => ar.RoleGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}