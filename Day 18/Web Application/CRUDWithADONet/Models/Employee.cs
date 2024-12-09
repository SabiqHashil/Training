using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDWithADONet.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("First Name"), Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Last Name"), Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;

        [DisplayName("Date Of Birth"), Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("E-Mail"), Required(ErrorMessage = "Email is required"), EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        public double Salary { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
