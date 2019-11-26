using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNet.BusinessLogic.DTO;
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

        public List<QuestionDto> GenerateQuiz()
        {
            var allQuestions = _questionRepository.GetAll().ToList();
            List<Question> quizQuestions = allQuestions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            List<QuestionDto> quizQuestionsDto = quizQuestions.Select(x => new QuestionDto()
            {
                Answers = x.Answers.Select(y => new AnswerDto() {Id = y.Id, QuestionId = y.QuestionId, Text = y.Text}).ToArray(),
                CorrectAnswerIndex = x.CorrectAnswerIndex,
                Id = x.Id,
                Text = x.Text
            }).ToList();

            return quizQuestionsDto;
        }
    }
}
