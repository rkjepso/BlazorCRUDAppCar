using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Server.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        //ApplicationDbContext _dbContext;
        static  List<Person> fakeDB = new ();   

        static public void InitData()
        {
            fakeDB.Add(new Person() { Id = 1, FirstName = "Richardd", LastName = "Kjepso", Email="rkj@hvl.no", MobileNo="93272465" });
            fakeDB.Add(new Person() { Id = 2, FirstName = "Per", LastName = "Kjepso", Email = "rkj@hvl.no", MobileNo = "93272465" });
            fakeDB.Add(new Person() {Id = 3, FirstName = "Peter", LastName = "Kjepso", Email = "rkj@hvl.no", MobileNo = "93272465"  });
        }


        public PersonRepository(/*ApplicationDbContext applicationDbContext*/)
        {
           // _dbContext = applicationDbContext;
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Person> CreateAsync(Person _object)

        {
            //var obj = await _dbContext.Persons.AddAsync(_object);
            //_dbContext.SaveChanges();
            //return obj.Entity;
            _object.Id = fakeDB.Select(p => p.Id).Max()+1;
            fakeDB.Add(_object);
            return _object; 
        }

        public async Task UpdateAsync(Person _object)
        {
            //_dbContext.Persons.Update(_object);
            //await _dbContext.SaveChangesAsync();
            int idx = fakeDB.FindIndex(p => p.Id == _object.Id);
            if (idx >=0)
                fakeDB[idx] = _object;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            //return await _dbContext.Persons.ToListAsync();
            return fakeDB;
        }

        public async Task<Person> GetByIdAsync(int Id)
        {
           // return await _dbContext.Persons.FirstOrDefaultAsync(x => x.Id == Id);
           var p = fakeDB.FirstOrDefault(x => x.Id == Id);
           return p;
        }

        public async Task DeleteAsync(int id)
        {
            //var data = _dbContext.Persons.FirstOrDefault(x=>x.Id == id);
            //_dbContext.Remove(data);
            //await _dbContext.SaveChangesAsync();
            var data = fakeDB.FirstOrDefault(x => x.Id == id);
            if (data!=null)
                fakeDB.Remove(data);

        }
    }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
}
