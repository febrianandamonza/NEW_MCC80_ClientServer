using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles;

public class AccountRoleValidation : AbstractValidator<AccountRoleDto>
{
    public AccountRoleValidation()
    {
        RuleFor(ar => ar.AccountGuid)
            .NotEmpty().WithMessage("Account Guid is required");
        RuleFor(ar => ar.RoleGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}