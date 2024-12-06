using System.ComponentModel.DataAnnotations;

namespace StudentJobApplication.Models
{
    public class StudentDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required"), MaxLength(100)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid Email Address format"), MaxLength(100)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required"), MaxLength(10, ErrorMessage = "Phone number cannot exceed 10 characters")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Resume is required")]
        public IFormFile Resume { get; set; }
    }
}
