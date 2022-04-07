using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BlazorCRUDApp.Shared;

namespace BlazorCRUDApp.Client
{
    public interface ICarsViewModel
    {
        public List<CarViewModel> Lst { get; set; }
        public Task GetAll();
        public Task<CarViewModel> Add(CarViewModel p);
        public Task<CarViewModel> GetById(string Id);
        public Task<bool> Update(CarViewModel car);
        public Task<bool> DeleteById(string Id);
    }
}
