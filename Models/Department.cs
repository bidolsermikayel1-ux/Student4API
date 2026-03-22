using System.ComponentModel.DataAnnotations;


namespace Student4API.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Office { get; set; }
    }
}