using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class EducationRepository : GeneralRepository<Education>, IEducationRepository
{
    public EducationRepository(BookingDbContext context) : base(context) { }
}