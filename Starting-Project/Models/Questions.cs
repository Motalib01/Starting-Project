namespace Starting_Project.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public String Question { get; set; }
        public String Choice { get; set; }
        public QuestionsType Type { get; set; }



        public int ProgramId { get; set; }
        public Programs Program { get; set; }
    }
}