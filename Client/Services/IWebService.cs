﻿using BlazorCRUDApp.Shared;

namespace BlazorCRUDApp.Client.Services
{
    public interface IWebService
    {
        Task<PersonViewModel> Add(PersonViewModel p);
        Task<PersonViewModel> GetPersonById(string id);
        Task<bool> UpdatePerson(PersonViewModel person);
        Task<bool> DeleteById(string id);
    }
}
