using Starting_Project.Models;

namespace Starting_Project.Interfaces
{
    public interface IQuestionsRepository
    {
        ICollection<Questions> GetQuestions();
        Questions GetQuestion(int id);
        bool AddQuestion(Questions question);
        bool UpdateQuestion(Questions question);
        bool DeleteQuestion(int id);
        bool Save();
        bool QuestionExists(int id);
    }
}
