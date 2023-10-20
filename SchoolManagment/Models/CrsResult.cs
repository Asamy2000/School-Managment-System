using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public decimal Degree { get; set; }
        [ForeignKey("Course")]
        public int? crs_Id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int? trainee_Id { get; set; }
        public Trainee Trainee { get; set; }
    }
}
