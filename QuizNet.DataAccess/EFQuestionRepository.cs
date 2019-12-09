using QuizNet.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuizNet.DataAccess
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly EFDbContext _dbContext;

        public EFQuestionRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
        }

        public void Delete(int questionId)
        {
            var questionToDelete = _dbContext.Questions.SingleOrDefault(q => q.Id == questionId);
            _dbContext.Questions.Remove(questionToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions.AsEnumerable();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.SingleOrDefault(q => q.Id == id);
        }

        public void Update(Question updatedQuestion)
        {
            var questionToEdit = _dbContext.Questions.SingleOrDefault(q => q.Id == updatedQuestion.Id);

            questionToEdit.Text = updatedQuestion.Text;
            questionToEdit.CorrectAnswerId = updatedQuestion.CorrectAnswerId;

            for (int i = 0; i < questionToEdit.Answers.Count; i++)
            {
                questionToEdit.Answers[i].Text = updatedQuestion.Answers[i].Text;
            }

            _dbContext.SaveChanges();
        }
    }
}
