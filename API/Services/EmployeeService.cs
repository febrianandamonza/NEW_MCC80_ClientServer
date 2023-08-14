using API.Contracts;
using API.DTOs.Employees;
using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;

namespace API.Services;

public class EmployeeService : GenerateHandler
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IUniversityRepository _universityRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository)
    {
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
    }

    public IEnumerable<EmployeeUniversitas> GetCountEmployeeUniversitas()
    {
        var result = from university in _universityRepository.GetAll()
            join education in _educationRepository.GetAll() on university.Guid equals education.UniversityGuid into g
            select new EmployeeUniversitas
            {
                Name = university.Name,
                Result = g.Count()
            };
        return result;
    }
    public EmployeeGender? GetGender()
    {
        var employees = _employeeRepository.GetAll();
        if (employees is null)
        {
            return null;
        }
        var dataWanita = employees.Count(e => e.Gender == GenderLevel.Female);
        var dataPria = employees.Count(e => e.Gender == GenderLevel.Male);
        var result = new EmployeeGender
        {
            ResultPria = dataPria,
            ResultWanita = dataWanita
        };

        return result;
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any())
        {
            return Enumerable.Empty<EmployeeDto>();
        }

        var employeeDtos = new List<EmployeeDto>();
        foreach (var employee in employees)
        {
            employeeDtos.Add((EmployeeDto)employee);
        }

        return employeeDtos;
    }

    public EmployeeDto? GetByGuid(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        return (EmployeeDto)employee;
    }

    public EmployeeDto? Create(NewEmployeeDto newEmployeeDto)
    {
        Employee toCreate = newEmployeeDto;
        toCreate.Nik = GenerateHandler.Nik(_employeeRepository.Getlastnik());
        
        var employee = _employeeRepository.Create(toCreate);
        if (employee is null)
        {
            return null;
        }

        return (EmployeeDto)employee;
    }

    public int Update(EmployeeDto employeeDto)
    {
        var employee = _employeeRepository.GetByGuid(employeeDto.Guid);
        if (employee is null)
        {
            return -1;
        }

        Employee toUpdate = employeeDto;
        toUpdate.CreatedDate = employee.CreatedDate;
        var result = _employeeRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return -1;
        }

        var result = _employeeRepository.Delete(employee);
        return result ? 1 
            : 0;
    }

    public IEnumerable<EmployeeDetailDto> GetAllEmployeeDetail()
    {
        var result = from employee in _employeeRepository.GetAll()
            join education in _educationRepository.GetAll() on employee.Guid equals education.Guid
            join university in _universityRepository.GetAll() on education.UniversityGuid equals university.Guid
            select new EmployeeDetailDto
            {
                EmployeeGuid = employee.Guid,
                Nik = employee.Nik,
                FullName = employee.FirstName + " " + employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Major = education.Major,
                Degree = education.Degree,
                Gpa = education.Gpa,
                UniversityName = university.Name
            };

        return result;
        
    }
    public EmployeeDetailDto? GetEmployeeDetailByGuid(Guid guid)
    {
        return GetAllEmployeeDetail().SingleOrDefault(e => e.EmployeeGuid == guid);
    }
}