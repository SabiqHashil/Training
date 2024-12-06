using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentJobApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Email { get; set; } = "";
        [MaxLength(100)]
        public string Phone { get; set; } = "";
        public DateTime DOB { get; set; }

        [Column(TypeName = "nvarchar(max)")]  
        public string Photo { get; set; } = "";
        [MaxLength(100)]
        public string Resume { get; set; } = "";
    }
}
