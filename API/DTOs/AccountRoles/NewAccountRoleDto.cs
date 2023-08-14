using API.DTOs.Accounts;
using API.Models;

namespace API.DTOs.AccountRoles;

public class NewAccountRoleDto
{
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

    public static implicit operator AccountRole(NewAccountRoleDto newAccountRoleDto)
    {
        return new AccountRole
        {
            Guid = new Guid(),
            AccountGuid = newAccountRoleDto.AccountGuid,
            RoleGuid = newAccountRoleDto.RoleGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewAccountRoleDto(AccountRole accountRole)
    {
        return new NewAccountRoleDto
        {
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };
    }
}