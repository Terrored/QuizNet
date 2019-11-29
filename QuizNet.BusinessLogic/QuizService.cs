using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using QuizNet.BusinessLogic.DTOs;
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
            List<Question> questions = _questionRepository.GetAll().ToList();
            List<Question> randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();

            List<QuestionDto> randomQuestionsDto = randomQuestions.Select(x => new QuestionDto()
            {
                Id = x.Id,
                CorrectAnswerIndex = x.CorrectAnswerIndex,
                Text = x.Text,
                Answers = x.Answers.Select(y => new AnswerDto() {Id = y.Id, QuestionId = y.QuestionId, Text = y.Text}).ToArray()
            }).ToList();
            
            return randomQuestionsDto;
        }
    }
}
