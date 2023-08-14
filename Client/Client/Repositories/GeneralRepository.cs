using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using API.Contracts;
using API.Utilities.Handlers;
using Client.Contracts;
using Microsoft.AspNetCore.Http.Headers;
using Newtonsoft.Json;

namespace Client.Repositories;

public class GeneralRepository<Entity, TId> : IGeneralRepository<Entity, TId> where Entity : class
{
    private readonly string request;
    private readonly HttpClient httpClient;
    private readonly IHttpContextAccessor contextAccessor;

    public GeneralRepository(string request)
    {
        this.request = request;
        contextAccessor = new HttpContextAccessor();
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7040/api/")

        };
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", contextAccessor.HttpContext?.Session.GetString("JWToken"));
    }
    
    public async Task<ResponseHandler<IEnumerable<Entity>>> Get()
    {
        ResponseHandler<IEnumerable<Entity>> entityVM = null;
        using (var response = await httpClient.GetAsync(request))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseHandler<IEnumerable<Entity>>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseHandler<Entity>> Get(TId id)
    {
        ResponseHandler<Entity> entity = null;

        using (var response = await httpClient.GetAsync(request + id))
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entity = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
        }

        return entity;
    }

    public async Task<ResponseHandler<Entity>> Post(Entity entity)
    {
        ResponseHandler<Entity> entityVM = null;
        StringContent content =
            new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = httpClient.PostAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseHandler<Entity>> Put(TId id, Entity entity)
    {
        ResponseHandler<Entity> entityVM = null;
        StringContent content =
            new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        using (var response = httpClient.PutAsync(request, content).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVM = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
        }

        return entityVM;
    }

    public async Task<ResponseHandler<Entity>> Delete(TId id)
    {
        ResponseHandler<Entity> entityVm = null;
        StringContent content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
        using (var response = httpClient.DeleteAsync(request + "?guid=" + id).Result)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();
            entityVm = JsonConvert.DeserializeObject<ResponseHandler<Entity>>(apiResponse);
        }

        return entityVm;
    }
}