using API.Models;

namespace API.DTOs.Universities;

public class NewUniversityDto
{
    public string Code { get; set; }
    public string Name { get; set; }

    public static implicit operator University(NewUniversityDto newUniversityDto)
    {
        return new University
        {
            Guid = new Guid(),
            Code = newUniversityDto.Code,
            Name = newUniversityDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewUniversityDto(University university)
    {
        return new NewUniversityDto
        {
            Code = university.Code,
            Name = university.Name
        };
    }
}