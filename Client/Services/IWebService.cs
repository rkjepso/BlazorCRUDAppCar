using BlazorCRUDApp.Shared;

namespace BlazorCRUDApp.Client.Services
{
    public interface IWebService
    {
        Task<PersonViewModel> Add(PersonViewModel p);
    }
}
