using Microsoft.AspNetCore.Mvc;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.Models;
using System.Collections.Generic;

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
            var questionViewModel = new QuestionFormViewModel()
            {
                Question = questionToEdit
            };

            return View("QuestionForm", questionViewModel);
        }

        [HttpPost]
        public IActionResult Save(QuestionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("QuestionForm", viewModel);

            var question = viewModel.Question;

            if (question.Id != 0)
                _questionService.Update(question);
            else
                _questionService.Add(question);

            return RedirectToAction("Get", new { Id = question.Id });
        }

        public IActionResult GenerateQuiz()
        {
            List<QuestionDto> quiz = _quizService.GenerateQuiz();
            return View("Quiz", quiz);
        }
    }
}