using Microsoft.AspNetCore.Mvc;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.Helpers;
using QuizNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuizNet.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IQuizService _quizService;

        public QuestionController(IQuestionService questionService, IQuizService quizService)
        {
            _questionService = questionService;
            _quizService = quizService;
        }

        public IActionResult GetAll()
        {
            var questions = _questionService.GetAll();
            return View(questions);
        }

        public IActionResult Get(int id)
        {
            var question = _questionService.GetById(id);
            return View(question);
        }

        public IActionResult Delete(int id)
        {
            _questionService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            var newQuestion = new QuestionFormViewModel();
            return View("QuestionForm", newQuestion);
        }

        public IActionResult Edit(int id)
        {
            var questionToEdit = _questionService.GetById(id);
            var questionViewModel = new QuestionFormViewModel();

            return View("QuestionForm", questionViewModel);
        }

        [HttpPost]
        public IActionResult Save(QuestionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("QuestionForm", viewModel);

            var answers = viewModel.Answers.Select(a => new AnswerDto() { Text = a }).ToArray();

            var questionDto = new QuestionDto()
            {
                Answers = answers,
                Text = viewModel.QuestionText,
                CorrectAnswer = answers[viewModel.CorrectAnswerIndex],
                Id = viewModel.QuestionId

            };

            if (questionDto.Id != 0)
            {
                _questionService.Update(questionDto);
            }
            else
            {
                questionDto = _questionService.Add(questionDto);
            }

            return RedirectToAction("Get", new { Id = questionDto.Id });
        }

        [Route("{controller}/{action}/{quizType}")]
        public IActionResult GenerateQuiz(string quizType)
        {
            List<QuestionDto> quiz = new List<QuestionDto>();

            if (quizType == QuizType.Recent)
            {
                quiz = _quizService.GenerateRecentlyAddedQuestionsQuiz();
            }
            else if (quizType == QuizType.Random)
            {
                quiz = _quizService.GenerateRandomQuiz();
            }
            else
            {
                return RedirectToAction("GetAll");
            }

            var quizViewModel = new QuizViewModel(quiz, quizType);
            return View("Quiz", quizViewModel);
        }

        [HttpPost]
        public IActionResult CheckQuiz(QuizViewModel quizViewModel)
        {
            var correctAnswers = _quizService.CheckQuiz(quizViewModel.Questions, quizViewModel.UserAnswersIndexes);

            var summaryViewModel = new QuizSummaryViewModel()
            {
                Questions = quizViewModel.Questions,
                UserAnswersIndexes = quizViewModel.UserAnswersIndexes,
                CorrectAnswers = correctAnswers
            };

            return View("QuizSummary", summaryViewModel);
        }
    }
}