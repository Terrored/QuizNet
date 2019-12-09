using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizNet.DataAccess.Models;

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
            return _dbContext.Questions.Include(a=> a.Answers).AsEnumerable();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.Include(a=> a.Answers).SingleOrDefault(q => q.Id == id);
        }

        public void Update(Question updatedQuestion)
        {

            throw new NotImplementedException();
        }
    }
}
