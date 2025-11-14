using System.ComponentModel.DataAnnotations;

namespace CurriculumGenerator.Entities
{
    public class Education
    {
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } = null;

        public string Course { get; set; } = string.Empty;

        public string InstitutionName { get; set; } = string.Empty;

        
    }
}
