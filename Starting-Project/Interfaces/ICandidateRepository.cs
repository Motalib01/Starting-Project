using Starting_Project.Models;

namespace Starting_Project.Interfaces
{
    public interface ICandidateRepository
    {
        ICollection<Candidate> GetCandidates();
        Candidate GetCandidate(int id);
        bool AddCandidate(Candidate candidate);
        bool UpdateCandidate(Candidate candidate);
        bool DeleteCandidate(int id);
        bool Save();
        bool CandidateExists(int id);

    }
}
