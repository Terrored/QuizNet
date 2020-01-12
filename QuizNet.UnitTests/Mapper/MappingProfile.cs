using AutoMapper;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.DataAccess.Models;

namespace QuizNet.UnitTests.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>();

            CreateMap<AnswerDto, Answer>();
            CreateMap<QuestionDto, Question>();
        }
    }
}