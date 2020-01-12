using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Moq;
using NUnit.Framework;
using QuizNet.BusinessLogic;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using QuizNet.UnitTests.Mapper;
using FluentAssertions;

namespace QuizNet.UnitTests
{
    [TestFixture]
    public class QuizServiceTests
    {
        private IMapper _mapper;
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private Mock<IMapper> _mapperMock;


        [SetUp]
        public void SetUp()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _mapperMock = new Mock<IMapper>();
            _mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile))));
        }

        [TearDown]
        public void TearDown()
        {
            _questionRepositoryMock = null;
        }

        [Test]
        public void Check_Generating_Recently_Added_Questions_Quiz()
        {
            //Arrange
            List<Question> questionList = new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Answers = null,
                    CreationTime = DateTime.Now,
                    Text = "Test1"
                },
                new Question()
                {
                    Id = 2,
                    Answers = null,
                    CreationTime = DateTime.Now.AddDays(1),
                    Text = "Test2"
                },
                new Question()
                {
                    Id = 3,
                    Answers = null,
                    CreationTime = DateTime.Now.AddDays(2),
                    Text = "Test3"
                },
            };
            _questionRepositoryMock.Setup(x => x.GetAll()).Returns(questionList);

            QuizService quizService = new QuizService(_questionRepositoryMock.Object, _mapper);

            //Act
            List<QuestionDto> quiz = quizService.GenerateRecentlyAddedQuestionsQuiz();
            //Assert

            _questionRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            Assert.AreEqual(questionList.Single(x => x.Id == 3).CreationTime, quiz[0].CreationTime);
            Assert.AreEqual(questionList.Count, quiz.Count);
            //Assert.Throws<ArgumentException>(()=> quizService.GenerateRecentlyAddedQuestionsQuiz());
            //FluentAssertions
            questionList.Single(x => x.Id == 3).CreationTime.Should().BeSameDateAs(quiz[0].CreationTime);



        }
        [Test]
        public void Check_Quiz()
        {
            //new Answer { Id = 1, IsCorrect = true, QuestionId = 1, Text = "s" },
            //new Answer { Id = 2, IsCorrect = false, QuestionId = 1, Text = "s2" }

            //Arrange
            List<QuestionDto> questionDtoList = new List<QuestionDto>()
            {
                new QuestionDto()
                {
                    Id = 1,

                },
                new QuestionDto()
                {
                    Id = 2,
                },

            };
            int[] userAnswers = new[] {69, 18};
            _questionRepositoryMock.Setup(x => x.GetById(It.Is<int>(x=> x == 1)))
                                    .Returns(new Question(){Id = 1,Answers = new List<Answer>()
                                    {
                                        new Answer { Id = 69, IsCorrect = true, QuestionId = 1, Text = "s" },
                                        new Answer { Id = 70, IsCorrect = false, QuestionId = 1, Text = "s2" }
                                    } });
            _questionRepositoryMock.Setup(x => x.GetById(It.Is<int>(x => x == 2)))
                                    .Returns(new Question(){Id = 2,Answers = new List<Answer>()
                                    {
                                        new Answer { Id = 96, IsCorrect = false, QuestionId = 2, Text = "x" },
                                        new Answer { Id = 97, IsCorrect = true, QuestionId = 2, Text = "x2" },
                                    } });

            QuizService quizService = new QuizService(_questionRepositoryMock.Object, _mapper);

            //Act
            int correctAnswers = quizService.CheckQuiz(questionDtoList, userAnswers);
            //Assert
            _questionRepositoryMock.VerifyAll();
            _questionRepositoryMock.Verify(x => x.GetById(1), Times.Once);
            _questionRepositoryMock.Verify(x => x.GetById(2), Times.Once);
            correctAnswers.Should().Be(1);





        }
    }
}
