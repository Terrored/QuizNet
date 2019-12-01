using QuizNet.BusinessLogic.DTOs;
using System.Collections.Generic;

namespace QuizNet.BusinessLogic.Interfaces
{
    public interface IQuestionService
    {
        List<QuestionDto> GetAll();
        QuestionDto GetById(int id);
        void Update(QuestionDto questionDto);
        void Delete(int id);
        void Add(QuestionDto questionDto);
    }
}
