using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Imag { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? dept_Id { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public Course? Course { get; set; }
    }
}
