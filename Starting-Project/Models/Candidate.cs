using System.ComponentModel.DataAnnotations;

namespace Starting_Project.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Nationality { get; set; }
        public String CurrentResidence { get; set; }
        public DateOnly BirthDate { get; set; }
        public String Gender { get; set; }


        public ICollection<CandidatePrograms> CandidatePrograms { get; set; }
    }
}
