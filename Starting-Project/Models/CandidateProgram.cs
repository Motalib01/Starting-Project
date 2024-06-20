namespace Starting_Project.Models
{
    public class CandidateProgram
    {
        public int CandidateId { get; set; }
        public Candidate candidate { get; set; }


        public int ProgramId { get; set; }
        public Program Program { get; set; }
    }
}