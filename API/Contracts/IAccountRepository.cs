using API.Models;

namespace API.Contracts;

public interface IAccountRepository : IGeneralRepository<Account>
{
    public bool isNotExist(string value);
}