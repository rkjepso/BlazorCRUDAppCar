using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository;


// Fake for simplicity
public class CarRepositoryFake : IRepository<Car>
{
    static List<Car> fakeDB = new();

    static public void InitData()
    {
        fakeDB.Add(new () { Id = 1, Brand = "Volvo", Model = "PV", Year = 1965, Price = 100000 });
        fakeDB.Add(new () { Id = 2, Brand = "Opel", Model = "GT", Year = 1969, Price = 250000 });
        fakeDB.Add(new () { Id = 3, Brand = "Ferrari", Model = "365GTO", Year = 1963, Price = 50000000});
    }
    public CarRepositoryFake(/*ApplicationDbContext applicationDbContext*/)
    {
        if (fakeDB.Count == 0)
            InitData();
    }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<Car> CreateAsync(Car _object)

    {
        _object.Id = fakeDB.Select(p => p.Id).Max() + 1;
        fakeDB.Add(_object);
        return _object;
    }

    public async Task UpdateAsync(Car _object)
    {
        int idx = fakeDB.FindIndex(p => p.Id == _object.Id);
        if (idx >= 0)
            fakeDB[idx] = _object;
    }

    public async Task<List<Car>>  GetAllAsync()
    {
        return fakeDB;
    }

    public async Task<Car> GetByIdAsync(int Id)
    {
        var p = fakeDB.FirstOrDefault(x => x.Id == Id);
        return p;
    }

    public async Task DeleteAsync(int id)
    {
        var data = fakeDB.FirstOrDefault(x => x.Id == id);
        if (data != null)
            fakeDB.Remove(data);
    }
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

