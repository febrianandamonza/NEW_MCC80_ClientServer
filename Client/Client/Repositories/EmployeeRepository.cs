using API.DTOs.Accounts;
using API.Models;
using Client.Contracts;

namespace Client.Repositories;

public class EmployeeRepository : GeneralRepository<Employee, Guid>, IEmployeeRepository
{
    public EmployeeRepository(string request="employees/") : base(request)
    {
    }
}