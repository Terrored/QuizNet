using QuizNet.BusinessLogic.DTOs;
using System.Collections.Generic;

namespace QuizNet.BusinessLogic.Interfaces
{
    public interface IQuizService
    {
        List<QuestionDto> GenerateQuiz();
        int CheckQuiz(List<QuestionDto> questions, int[] userAnswers);
    }
}
