using SchoolManagment.Models;

namespace SchoolManagment.Interfaces
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {
        public IQueryable<Instructor> GetInstructorByName(string name);
    }
}
