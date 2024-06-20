using Starting_Project.Models;

namespace Starting_Project.Dtos
{
    public class QuestionsDto
    {
        public String Question { get; set; }
        public String Choice { get; set; }
        public QuestionsType Type { get; set; }
    }
}
