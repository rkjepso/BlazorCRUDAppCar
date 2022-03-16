using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

// Real Database
public class PersonRepository : IRepository<Person>
{
    ApplicationDbContext _dbContext;

    public PersonRepository(ApplicationDbContext applicationDbContext)
    {
         _dbContext = applicationDbContext;
        applicationDbContext.Database.EnsureCreated();
    }
    public async Task<Person> CreateAsync(Person _object)

    {
        var obj = await _dbContext.Persons.AddAsync(_object);
        _ = _dbContext.SaveChanges();
        return obj.Entity;

    }

    public async Task UpdateAsync(Person _object)
    {
        _ = _dbContext.Persons.Update(_object);
        _ = await _dbContext.SaveChangesAsync();
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
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        _ = _dbContext.Remove(data);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        _ = await _dbContext.SaveChangesAsync();
    }
}
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

