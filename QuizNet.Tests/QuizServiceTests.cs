using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using QuizNet.BusinessLogic;
using QuizNet.BusinessLogic.Mapper;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using FluentAssertions;
using QuizNet.BusinessLogic.DTOs;

namespace QuizNet.Tests
{
    [TestFixture]
    public class QuizServiceTests
    {
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg =>cfg.AddProfile(typeof(MappingProfile))));
        }
        [TearDown]
        public void TearDown()
        {
            _questionRepositoryMock = null;
            _mapper = null;
        }
        [Test]
        public void check_generating_recently_added_questions_quiz()
        {
            //Arrange
            IList<Question> questionList = new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Answers = null,
                    CreationTime = DateTime.Now,
                    Text = "1"
                },
                new Question()
                {
                Id = 2,
                Answers = null,
                CreationTime = DateTime.Now.AddDays(1),
                Text = "2"
                },
                new Question()
                {
                    Id = 3,
                    Answers = null,
                    CreationTime = DateTime.Now.AddDays(2),
                    Text = "3"
                }

            };
            _questionRepositoryMock.Setup(x => x.GetAll()).Returns(questionList);
            var quizService = new QuizService(_questionRepositoryMock.Object, _mapper);
            
            //Act
            var quiz = quizService.GenerateRecentlyAddedQuestionsQuiz();

            //Assert
            _questionRepositoryMock.Verify(x=>x.GetAll(),Times.Once);
            Assert.AreEqual(3, quiz.FirstOrDefault().Id);
            Assert.AreEqual(3, quiz.Count);

            //FluentAssertions
            var firstQuestion = quiz.FirstOrDefault();

            firstQuestion.Id.Should().Be(3);
            

        }
        [Test]
        public void check_quiz()
        {
            //Arrange
            List<QuestionDto> questions = new List<QuestionDto>()
            {
                new QuestionDto()
                {
                    Id = 1
                },
                new QuestionDto()
                {
                    Id = 2
                }
            };


            int[] userAnswers = new[] {44, 67};
            _questionRepositoryMock.Setup(x => x.GetById(It.Is<int>(y => y == 1)))
                .Returns(new Question()
                {
                    Id = 1,
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 44, IsCorrect = true, QuestionId = 1
                        },
                        new Answer()
                        {
                            Id = 45, IsCorrect = false, QuestionId = 1,
                        }

                    }
                });
            _questionRepositoryMock.Setup(x => x.GetById(It.Is<int>(y => y == 2)))
                .Returns(new Question()
                {
                    Id = 2,
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = 66, IsCorrect = true, QuestionId = 2
                        },
                        new Answer()
                        {
                            Id = 67, IsCorrect = false, QuestionId = 2,
                        }

                    }
                });

            var quizService = new QuizService(_questionRepositoryMock.Object,_mapper);
            //Act
            var correctAnswers = quizService.CheckQuiz(questions, userAnswers);
            //Assert
            correctAnswers.Should().Be(1);
        }
    }
}
