using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class AccountRepository : GeneralRepository<Account>,IAccountRepository
{
    public AccountRepository(BookingDbContext context) : base(context) { }
    public bool isNotExist(string value)
    {
        return _context.Set<Employee>()
            .SingleOrDefault(e => e.Email.Contains(value) || e.PhoneNumber.Contains(value)) is null;
    }
}