using Microsoft.EntityFrameworkCore;
using QuizNet.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuizNet.DataAccess
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly EfDbContext _dbContext;

        public EFQuestionRepository(EfDbContext dbContext)
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
            return _dbContext.Questions.Include(a => a.Answers).AsEnumerable();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.Include(a => a.Answers).SingleOrDefault(q => q.Id == id);
        }

        public void Update(Question updatedQuestion)
        {
            var questionToUpdate = _dbContext.Questions.Include(q => q.Answers).SingleOrDefault(q => q.Id == updatedQuestion.Id);

            questionToUpdate.Text = updatedQuestion.Text;

            for (int i = 0; i < questionToUpdate.Answers.Count; i++)
            {
                questionToUpdate.Answers[i].IsCorrect = updatedQuestion.Answers[i].IsCorrect;
                questionToUpdate.Answers[i].Text = updatedQuestion.Answers[i].Text;
            }

            _dbContext.SaveChanges();
        }
    }
}
