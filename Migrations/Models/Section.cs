using System.ComponentModel.DataAnnotations;

namespace Student4API.Models
{
   public class Section
   {
    public int SectionId { get; set; }

    [Required]
    public string SectionCode { get; set; }

    public int CourseId { get; set; }
    public int InstructorId { get; set; }

    [Required]
    public string Room { get; set; }

    [Required]
    public string Schedule { get; set; }
   }
}
