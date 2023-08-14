using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(BookingDbContext context) : base(context) { }
}