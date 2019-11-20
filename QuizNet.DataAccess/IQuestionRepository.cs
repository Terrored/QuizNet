using System;
using System.Collections.Generic;
using System.Text;
using QuizNet.DataAccess.Models;

namespace QuizNet.DataAccess
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        void Add(Question question);
        void Update(Question updatedQuestion);
        void Delete(int questionId);

    }
}
