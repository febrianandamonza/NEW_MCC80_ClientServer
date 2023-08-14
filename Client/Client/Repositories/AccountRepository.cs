using System.Diagnostics;
using System.Text;
using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Newtonsoft.Json;

namespace Client.Repositories;

public class AccountRepository : GeneralRepository<Account, Guid>, IAccountRepository
{
    private readonly HttpClient httpClient;
    private readonly string request;
    
    public AccountRepository(string request = "accounts/") : base(request)
    {
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7040/api/")
        };
        this.request = request;
    }

    public async Task<ResponseHandler<TokenDto>> Login(LoginDto entity)
    {
        ResponseHandler<TokenDto> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json"); 
        using (var response = httpClient.PostAsync(request + "login", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseHandler<TokenDto>>(apiResponse);
            }
            
        return entityVM;
        
    }

    public async Task<ResponseHandler<RegisterDto>> Register(RegisterDto entity)
    {
        ResponseHandler<RegisterDto> entityVM = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = httpClient.PostAsync(request + "Register", content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseHandler<RegisterDto>>(apiResponse);
        }
        return entityVM;
    }
}