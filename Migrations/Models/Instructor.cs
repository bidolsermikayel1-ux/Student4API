using System.ComponentModel.DataAnnotations;

namespace Student4API.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required]
        public string EmployeeNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public int DepartmentId { get; set; }
    }
}