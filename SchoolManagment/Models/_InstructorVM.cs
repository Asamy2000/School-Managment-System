using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagment.Models
{
    public class _InstructorVM
    {

        public int Id { get; set; }

        //[RegularExpression("^[A-Za-z\\s'-]+$ ", ErrorMessage = "not valid name")]
        [Required(ErrorMessage = "Name is Required!!")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        [MinLength(5, ErrorMessage = "Max length is 5")]
        [Remote(action: "CheckName", controller:"Instructor",ErrorMessage ="Name Exist!",AdditionalFields ="Id")]
        public string Name { get; set; }
        public string Imag { get; set; }
        [Required(ErrorMessage = "Salary is Required!!")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Address is Required!!")]
        //[RegularExpression("^\\d+-[A-Za-z]+\\-[A-Za-z]+\\-[A-Za-z]+$",
        //    ErrorMessage = "Address must be like 123-Street-City-Country")]
        [Address]
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? dept_Id { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        public int? crs_id { get; set; }
        public Course? Course { get; set; }
    }
}



