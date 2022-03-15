using BlazorCRUDApp.Shared;
using System.Net.Http.Json;

namespace BlazorCRUDApp.Client.Services;

#pragma warning disable CS8600, CS8603 // Converting null literal or possible null value to non-nullable type.
public class WebService : IWebService
{
    HttpClient Http;
    public WebService(HttpClient httpClient) 
    {
        Http = httpClient;
    }


    // Create a new person
    public async Task<PersonViewModel> Add(PersonViewModel person)
    {
        var response = await Http.PostAsJsonAsync("api/Person", @person);

        PersonViewModel personResponse = await response.Content.ReadFromJsonAsync<PersonViewModel>();

        return personResponse;

    }

    public async Task<PersonViewModel> GetPersonById(string Id)
    {
        var person = await Http.GetFromJsonAsync<PersonViewModel>("api/person/" + Id);
        return person;
    }

    public async Task<bool> UpdatePerson(PersonViewModel person)
    {
        var response = await Http.PutAsJsonAsync("api/Person/" + person.Id, @person);
        bool b = await response.Content.ReadFromJsonAsync<bool>();
        return b;
    }



    // Delete a person
    public async Task<bool> DeleteById(string Id)
    {
        var response = await Http.DeleteAsync("api/Person/" + Id);
        bool deleteResponse = await response.Content.ReadFromJsonAsync<bool>();
        if (deleteResponse)
        {
            return true;

        }
        return false;
    }


    public async Task<List<PersonViewModel>> GetAllPersons()
    {
        var response = await Http.GetAsync("api/person");
        response.EnsureSuccessStatusCode();
        var personList = await response.Content.ReadFromJsonAsync<List<PersonViewModel>>();
        return personList;
    }


    //var response = await _httpClient.GetAsync("api/person");
    //response.EnsureSuccessStatusCode();
    //personList = await response.Content.ReadFromJsonAsync<List<PersonViewModel>>();
}

#pragma warning restore CS8600, CS8603 // Converting null literal or possible null value to non-nullable type.

