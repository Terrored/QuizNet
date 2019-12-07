using AutoMapper;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using System.Collections.Generic;
using System;

namespace QuizNet.BusinessLogic
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public List<QuestionDto> GetAll()
        {
            var questions = _questionRepository.GetAll();
            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);
            return questionsDto;
        }

        public QuestionDto GetById(int id)
        {
            var question = _questionRepository.GetById(id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        public void Update(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            _questionRepository.Update(question);
        }

        public void Delete(int id)
        {
            _questionRepository.Delete(id);
        }

        public QuestionDto Add(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            question.CreationTime = DateTime.Now;
            _questionRepository.Add(question);

            var createdQuestion = _mapper.Map<QuestionDto>(question);
            return createdQuestion;
        }
    }
}
