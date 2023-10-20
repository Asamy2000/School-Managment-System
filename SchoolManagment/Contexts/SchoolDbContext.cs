using Microsoft.EntityFrameworkCore;
using SchoolManagment.Models;

namespace SchoolManagment.Contexts
{
    public class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder/*.UseLazyLoadingProxies()*/.UseSqlServer("Ur Conn"); // U can handle this in the Program.cs AddDbcontect(options => {...}) & appsettings.json

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }


    }
}
