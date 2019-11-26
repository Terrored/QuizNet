using Microsoft.AspNetCore.Mvc;
using QuizNet.BusinessLogic.Interfaces;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;

namespace QuizNet.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizService _quizService;

        public QuestionController(IQuestionRepository questionRepository, IQuizService quizService)
        {
            _questionRepository = questionRepository;
            _quizService = quizService;
        }

        public IActionResult GetAll()
        {
            var questions = _questionRepository.GetAll();
            var lol = _quizService.GenerateQuiz();
            return View(questions);
        }

        public IActionResult Get(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }

        public IActionResult Delete(int id)
        {
            _questionRepository.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            var newQuestion = new Question();
            return View("QuestionForm", newQuestion);
        }

        public IActionResult Edit(int id)
        {
            var questionToEdit = _questionRepository.GetById(id);
            return View("QuestionForm", questionToEdit);
        }

        [HttpPost]
        public IActionResult Save(Question question)
        {
            if (question.Id != 0)
                _questionRepository.Update(question);
            else
                _questionRepository.Add(question);

            return RedirectToAction("Get", new { Id = question.Id });
        }

        public IActionResult GenerateQuiz()
        {
            var questions = _quizService.GenerateQuiz();
            return View("Quiz",questions);
        }
    }
}