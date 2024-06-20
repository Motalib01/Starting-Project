using Starting_Project.Data;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Repository
{
    public class ProgramsRepository : IProgramsRepository
    {
        private readonly DataContext _context;

        public ProgramsRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateProgram(Programs program)
        {
            _context.Add(program);
            return Save();
        }

        public bool DeleteProgram(Programs program)
        {
            _context.Remove(program);
            return Save();

        }

        public Programs GetProgramById(int id)
        {
            return _context.Programss.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Programs> GetPrograms()
        {
            return _context.Programss.OrderBy(p => p.Id).ToList();
        }

        public bool ProgramExists(int id)
        {
            return _context.Programss.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >0 ? true : false; 
        }

        public bool UpdateProgram(Programs program)
        {
            _context.Update(program);
            return Save();
        }
    }
}
