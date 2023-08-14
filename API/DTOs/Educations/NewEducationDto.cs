using API.DTOs.Accounts;
using API.Models;

namespace API.DTOs.Educations;

public class NewEducationDto
{
    public Guid Guid { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public float Gpa { get; set; }
    public Guid UniversityGuid { get; set; }

    public static implicit operator Education(NewEducationDto newEducationDto)
    {
        return new Education
        {
            Guid = newEducationDto.Guid,
            Major = newEducationDto.Major,
            Degree = newEducationDto.Degree,
            Gpa = newEducationDto.Gpa,
            UniversityGuid = newEducationDto.UniversityGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewEducationDto(Education education)
    {
        return new NewEducationDto
        {
            Guid = education.Guid,
            Major = education.Major,
            Degree = education.Degree,
            Gpa = education.Gpa,
            UniversityGuid = education.UniversityGuid
        };
    }
}