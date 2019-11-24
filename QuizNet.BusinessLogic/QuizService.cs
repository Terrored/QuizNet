using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;

namespace QuizNet.BusinessLogic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuizService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<Question> GenerateQuiz()
        {
            var allQuestions = _questionRepository.GetAll().ToList();
            List<Question> quizQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            return quizQuestions;
        }
    }
}
