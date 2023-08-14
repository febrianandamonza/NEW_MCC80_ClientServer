using API.Models;

namespace API.DTOs.Roles;

public class NewRoleDto
{
    public string Name { get; set; }

    public static implicit operator Role(NewRoleDto newRoleDto)
    {
        return new Role
        {
            Guid = new Guid(),
            Name = newRoleDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewRoleDto(Role role)
    {
        return new NewRoleDto
        {
            Name = role.Name
        };
    }
}