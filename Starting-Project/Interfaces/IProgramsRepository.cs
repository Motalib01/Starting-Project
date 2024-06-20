using Starting_Project.Models;

namespace Starting_Project.Interfaces
{
    public interface IProgramsRepository
    {
        ICollection<Programs> GetPrograms();
        Programs GetProgramById(int id);
        bool CreateProgram(Programs program);
        bool UpdateProgram(Programs program);
        bool DeleteProgram(Programs program);
        bool Save();
        bool ProgramExists(int id);

    }
}
