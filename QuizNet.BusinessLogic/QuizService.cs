using AutoMapper;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuizNet.BusinessLogic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        public List<QuestionDto> GenerateRandomQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            List<Question> randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

            List<QuestionDto> randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);

            return randomQuestionsDto;
        }

        public int CheckQuiz(List<QuestionDto> questions, int[] userAnswers)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                questions[i] = _mapper.Map<QuestionDto>(_questionRepository.GetById(questions[i].Id));
            }

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Answers.SingleOrDefault(a=>a.IsCorrect).Id == userAnswers[i])
                {
                    correctAnswers++;
                }
            }

            return correctAnswers;
        }

        public List<QuestionDto> GenerateRecentlyAddedQuestionsQuiz()
        {
            var questions = _questionRepository.GetAll().ToList();
            var recentQuestions = questions.OrderByDescending(x => x.CreationTime).Take(3).ToList();

            var recentQuestionsDto = _mapper.Map<List<QuestionDto>>(recentQuestions);

            return recentQuestionsDto;
        }
    }
}
