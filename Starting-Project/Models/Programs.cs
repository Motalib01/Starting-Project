namespace Starting_Project.Models
{
    public class Programs
    {
        public int Id { get; set; }
        public String Titel { get; set; }
        public String Titelescription { get; set; }

        public ICollection<CandidatePrograms> CandidatePrograms { get; set; }
        public ICollection<Questions> Questions { get; set; }
    }
}
