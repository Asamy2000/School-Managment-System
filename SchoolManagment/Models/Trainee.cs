using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public string Address { get; set; }
        public decimal Grade { get; set; }
        [ForeignKey("Department")]
        public int? dept_Id { get; set; }
        public Department Department { get; set; }

        public ICollection<CrsResult> CrsResults { get; set; } = new HashSet<CrsResult>();
    }
}
