using System;
using System.Collections.Generic;
using System.Text;
using QuizNet.DataAccess.Models;

namespace QuizNet.BusinessLogic.Interfaces
{
    public interface IQuizService
    {
        List<Question> GenerateQuiz();

    }
}
