using System.ComponentModel.DataAnnotations;

namespace MVC_Student.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Sid { get; set; }
        [Required]
        public string? Sname { get; set; }
        [Required]

        public double Marks { get; set; }
       
        
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
