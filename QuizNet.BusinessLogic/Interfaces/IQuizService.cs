using System;
using System.Collections.Generic;
using System.Text;
using QuizNet.BusinessLogic.DTO;
using QuizNet.DataAccess.Models;

namespace QuizNet.BusinessLogic.Interfaces
{
    public interface IQuizService
    {
        List<QuestionDto> GenerateQuiz();

    }
}
