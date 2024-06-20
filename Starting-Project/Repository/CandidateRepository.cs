using Starting_Project.Data;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;

        public CandidateRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddCandidate(Candidate candidate)
        {
            _context.Add(candidate);
            return Save();
        }

        public bool CandidateExists(int id)
        {
            return _context.Candidates.Any(c => c.Id == id);
        }

        public bool DeleteCandidate(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public Candidate GetCandidate(int id)
        {
            return _context.Candidates.Where(c=>c.Id ==id).FirstOrDefault();
        }

        public ICollection<Candidate> GetCandidates()
        {
            return _context.Candidates.OrderBy(c => c.Id).ToList();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save <0? true: false;
        }

        public bool UpdateCandidate(Candidate candidate)
        {
            _context.Update(candidate);
            return Save();
        }
    }
}
