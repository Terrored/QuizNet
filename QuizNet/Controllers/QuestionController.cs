using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNet.DataAccess;
using QuizNet.DataAccess.Models;
using QuizNet.Models;

namespace QuizNet.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IActionResult GetAll()
        {
            var questions = _questionRepository.GetAll();
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
            return View(newQuestion);
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            var newQuestionId = _questionRepository.GetAll().Last().Id + 1;
            question.Id = newQuestionId;

            var lastAnswerId = _questionRepository.GetAll().LastOrDefault().
                Answers.LastOrDefault().Id;


            for (int i = 0; i < question.Answers.Length; i++)
            {
                question.Answers[i].Id = lastAnswerId + i + 1;
                question.Answers[i].QuestionId = newQuestionId;
            }

            _questionRepository.Add(question);

            return RedirectToAction("Get", new {Id = question.Id});
        }
    }
}