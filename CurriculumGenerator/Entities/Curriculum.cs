namespace CurriculumGenerator.Entities
{
    public class Curriculum
    {
        public string FullName { get; set; } = String.Empty;

        public string ProfessionalTitle { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string LinkedinLink { get; set; } = String.Empty;
        public string GitHubLink { get; set; } = String.Empty;
        public string Goal { get; set; } = String.Empty;
        public string Highlights { get; set; } = String.Empty;
        public string Experience { get; set; } = String.Empty;
        public List<string> SkillSet { get; set; } = [];

    }
}
