using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        [ForeignKey("Department")]
        public int? dept_Id { get; set; }
        //One Course has one Dept [Navigational Prop One]
        public Department Department { get; set; }
        //one Course has Many Instructors [Navigational Prop Many]
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        public ICollection<CrsResult> Results { get; set; } = new HashSet<CrsResult>();


    }
}
