using API.Models;

namespace API.Contracts;

public interface IUniversityRepository : IGeneralRepository<University>
{
    public University? isExist(string value);
    
    public Guid GetLastUniversityGuid();
}