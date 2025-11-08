using System.ComponentModel.DataAnnotations;

namespace CurriculumGenerator.Entities
{
    public class Experience
    {
        

        public string CompanyName { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; } 

        public DateTime? EndDate { get; set; } = null;

        public string Description { get; set; } = string.Empty;

       



    }
}
