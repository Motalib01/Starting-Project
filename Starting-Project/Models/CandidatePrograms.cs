namespace Starting_Project.Models
{
    public class CandidatePrograms
    {
        public int CandidateId { get; set; }
        public Candidate candidate { get; set; }


        public int ProgramId { get; set; }
        public Programs Program { get; set; }
    }
}