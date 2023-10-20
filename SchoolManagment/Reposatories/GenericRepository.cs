using Microsoft.EntityFrameworkCore;
using SchoolManagment.Contexts;
using SchoolManagment.Interfaces;
using SchoolManagment.Models;

namespace SchoolManagment.Reposatories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SchoolDbContext _dbContext;

        public GenericRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T item)
          => await _dbContext.Set<T>().AddAsync(item);


        public void Delete(T item)
             => _dbContext.Set<T>().Remove(item);

        public async Task<T> GetById(int id)
              => await _dbContext.Set<T>().FindAsync(id);






        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Instructor))
                return (IEnumerable<T>)await _dbContext.Instructors.Include(I => I.Department).Include(I => I.Course).ToListAsync();
            else if (typeof(T) == typeof(Department))
                return (IEnumerable<T>)await _dbContext.Departments.Include(D => D.Instructors).ToListAsync();
            else
              return await _dbContext.Set<T>().ToListAsync();
        }



        public void Update(T item)
         => _dbContext.Update(item);
    }
}
