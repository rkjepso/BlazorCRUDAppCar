using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository;

#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

// Real Database
public class CarRepository : IRepository<Car>
{
    ApplicationDbContext _dbContext;

    public CarRepository(ApplicationDbContext applicationDbContext)
    {
         _dbContext = applicationDbContext;
        applicationDbContext.Database.EnsureCreated();
    }
    public async Task<Car> CreateAsync(Car _object)

    {
        var obj = await _dbContext.Cars.AddAsync(_object);
        _ = _dbContext.SaveChanges();
        return obj.Entity;

    }

    public async Task UpdateAsync(Car _object)
    {
        _ = _dbContext.Cars.Update(_object);
        _ = await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _dbContext.Cars.ToListAsync();
  
    }

    public async Task<Car> GetByIdAsync(int Id)
    {
        return await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task DeleteAsync(int id)
    {
        var data = _dbContext.Cars.FirstOrDefault(x => x.Id == id);
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        _ = _dbContext.Remove(data);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        _ = await _dbContext.SaveChangesAsync();
    }
}
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

