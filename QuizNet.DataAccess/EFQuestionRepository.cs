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
        private readonly EFDbContext _dbContext;

        public EFQuestionRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions.Include(a=>a.Answers).AsEnumerable();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.Include(a => a.Answers).SingleOrDefault(q => q.Id == id);
        }

        public void Add(Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
        }

        public void Update(Question updatedQuestion)
        {
            var questionToUpdate = _dbContext.Questions.Include(a => a.Answers).SingleOrDefault(q => q.Id == updatedQuestion.Id);

            questionToUpdate.Text = updatedQuestion.Text;

            for (int i = 0; i < questionToUpdate.Answers.Count; i++)
            {
                questionToUpdate.Answers[i].IsCorrect = updatedQuestion.Answers[i].IsCorrect;
                questionToUpdate.Answers[i].Text = updatedQuestion.Answers[i].Text;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int questionId)
        {
            var questionToDelete = _dbContext.Questions.SingleOrDefault(q => q.Id == questionId);
            _dbContext.Questions.Remove(questionToDelete);
            _dbContext.SaveChanges();
        }
    }
}
