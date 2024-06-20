using Starting_Project.Data;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Repository
{
    public class QuestionsRepository: IQuestionsRepository

    {
        private readonly DataContext _context;

        public QuestionsRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddQuestion(Questions question)
        {
            _context.Add(question);
            return Save();
        }

        public bool DeleteQuestion(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public Questions GetQuestion(int id)
        {
            return _context.Questions.Where(q => q.Id == id).FirstOrDefault();
        }

        public ICollection<Questions> GetQuestions()
        {
            return _context.Questions.OrderBy(q => q.Id).ToList();
        }

        public bool QuestionExists(int id)
        {
            return _context.Questions.Any(q => q.Id == id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save>0? true: false;
        }

        public bool UpdateQuestion(Questions question)
        {
            _context.Update(question);
            return Save();
        }
    }
}
