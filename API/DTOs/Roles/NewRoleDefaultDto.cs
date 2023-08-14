using API.Models;

namespace API.DTOs.Roles;

public class NewRoleDefaultDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }

    public static implicit operator Role(NewRoleDefaultDto newRoleDefaultDto)
    {
        return new Role
        {
             Guid = newRoleDefaultDto.Guid,
            Name = newRoleDefaultDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewRoleDefaultDto(Role role)
    {
        return new NewRoleDefaultDto()
        {
            Name = role.Name
        };
    }
}