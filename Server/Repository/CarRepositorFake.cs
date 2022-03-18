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
        fakeDB.Add(new () { Id = 1, Brand = "Richard", Model = "Kjepso", Year = "rkj@hvl.no", Price = "93272465" });
        fakeDB.Add(new () { Id = 2, Brand = "Per", Model = "Hansen", Year = "pha@example.no", Price = "11111111" });
        fakeDB.Add(new () { Id = 3, Brand = "Peter", Model = "Thomsen", Year = "ph@example.no", Price = "11111111" });
        fakeDB.Add(new () { Id = 3, Brand = "Walter", Model = "Mac Party", Year = "wmcp@example.no", Price = "11111111" });
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

    public async Task<List<Car>> GetAllAsync()
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

