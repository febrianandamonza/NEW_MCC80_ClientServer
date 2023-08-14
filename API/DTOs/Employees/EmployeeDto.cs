using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Employees;

public class EmployeeDto
{
    public Guid Guid { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderLevel Gender { get; set; }
    public DateTime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public static implicit operator Employee(EmployeeDto employeeDto)
    {
        return new Employee
        {
            Nik = employeeDto.Nik,
            Guid = employeeDto.Guid,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            BirthDate = employeeDto.BirthDate,
            Gender = employeeDto.Gender,
            HiringDate = employeeDto.HiringDate,
            Email = employeeDto.Email,
            PhoneNumber = employeeDto.PhoneNumber,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator EmployeeDto(Employee employee)
    {
        return new EmployeeDto
        {
            Nik = employee.Nik,
            Guid = employee.Guid,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };
    }
}