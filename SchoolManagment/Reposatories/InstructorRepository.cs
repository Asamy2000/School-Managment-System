using Microsoft.EntityFrameworkCore;
using SchoolManagment.Contexts;
using SchoolManagment.Interfaces;
using SchoolManagment.Models;
using System.Xml.Linq;

namespace SchoolManagment.Reposatories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly SchoolDbContext _context;
        public InstructorRepository(SchoolDbContext dbContext) :base(dbContext) 
        {
            _context = dbContext;
        }

        public IQueryable<Instructor> GetInstructorByName(string name)
           => _context.Instructors.Where(E => E.Name.ToLower().ToLower().Contains(name.ToLower()));
    }
}
