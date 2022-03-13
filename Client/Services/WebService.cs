using BlazorCRUDApp.Shared;
using System.Net.Http.Json;

namespace BlazorCRUDApp.Client.Services;
public class WebService : IWebService
{
    HttpClient Http;
    public WebService(HttpClient httpClient) 
    {
        Http = httpClient;
    }

    public async Task<PersonViewModel> Add(PersonViewModel person)
    {
        var response = await Http.PostAsJsonAsync("api/Person", @person);
        PersonViewModel personResponse = await response.Content.ReadFromJsonAsync<PersonViewModel>();
        return personResponse;

    }
}

