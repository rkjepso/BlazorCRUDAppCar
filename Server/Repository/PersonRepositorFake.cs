using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository;


// Fake for simplicity
public class PersonRepositoryFake : IRepository<Person>
{
    static List<Person> fakeDB = new();

    static public void InitData()
    {
        fakeDB.Add(new () { Id = 1, FirstName = "Richard", LastName = "Kjepso", Email = "rkj@hvl.no", MobileNo = "93272465" });
        fakeDB.Add(new () { Id = 2, FirstName = "Per", LastName = "Hansen", Email = "pha@example.no", MobileNo = "11111111" });
        fakeDB.Add(new () { Id = 3, FirstName = "Peter", LastName = "Thomsen", Email = "ph@example.no", MobileNo = "11111111" });
        fakeDB.Add(new () { Id = 3, FirstName = "Walter", LastName = "Mac Party", Email = "wmcp@example.no", MobileNo = "11111111" });
    }
    public PersonRepositoryFake(/*ApplicationDbContext applicationDbContext*/)
    {
        if (fakeDB.Count == 0)
            InitData();
    }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<Person> CreateAsync(Person _object)

    {
        _object.Id = fakeDB.Select(p => p.Id).Max() + 1;
        fakeDB.Add(_object);
        return _object;
    }

    public async Task UpdateAsync(Person _object)
    {
        int idx = fakeDB.FindIndex(p => p.Id == _object.Id);
        if (idx >= 0)
            fakeDB[idx] = _object;
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return fakeDB;
    }

    public async Task<Person> GetByIdAsync(int Id)
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

