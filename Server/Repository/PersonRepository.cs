using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository;


// Real Database
public class PersonRepository : IRepository<Person>
{
    ApplicationDbContext _dbContext;

    public PersonRepository(ApplicationDbContext applicationDbContext)
    {
         _dbContext = applicationDbContext;
    }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<Person> CreateAsync(Person _object)

    {
        var obj = await _dbContext.Persons.AddAsync(_object);
        _dbContext.SaveChanges();
        return obj.Entity;

    }

    public async Task UpdateAsync(Person _object)
    {
        _dbContext.Persons.Update(_object);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return await _dbContext.Persons.ToListAsync();
  
    }

    public async Task<Person> GetByIdAsync(int Id)
    {
        return await _dbContext.Persons.FirstOrDefaultAsync(x => x.Id == Id);

    }

    public async Task DeleteAsync(int id)
    {
        var data = _dbContext.Persons.FirstOrDefault(x => x.Id == id);
        _dbContext.Remove(data);
        await _dbContext.SaveChangesAsync();
    }
}


// Fake for simplicity
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

