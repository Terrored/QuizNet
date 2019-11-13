using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNet.Models;

namespace QuizNet.Controllers
{
    public class QuestionController : Controller
    {
        private static readonly List<Question> _questions = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Text = "Jakie jest hasło admina?",
                CorrectAnswerIndex = 1,
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Text = "qwerty"

                    },
                    new Answer()
                    {
                        Id = 2,
                        QuestionId = 1,
                        Text = "admin"

                    },
                    new Answer()
                    {
                        Id = 3,
                        QuestionId = 1,
                        Text = "hasło"

                    },
                    new Answer()
                    {
                        Id = 4,
                        QuestionId = 1,
                        Text = "password"

                    },
                }
            },
            new Question()
            {
            Id = 2,
            Text = "Jaki jest najlepszy język programowania?",
            CorrectAnswerIndex = 2,
            Answers = new Answer[]
            {
                new Answer()
                {
                    Id = 5,
                    QuestionId = 2,
                    Text = "HTML"

                },
                new Answer()
                {
                    Id = 6,
                    QuestionId = 2,
                    Text = "Java"

                },
                new Answer()
                {
                    Id = 7,
                    QuestionId = 2,
                    Text = "C#"

                },
                new Answer()
                {
                    Id = 8,
                    QuestionId = 2,
                    Text = "JavaScript"

                },
            }
        }
        };

        public IActionResult GetAll()
        {
            var questions = _questions;
            return View(questions);
        }

        public IActionResult Get(int id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            return View(question);
        }

        public IActionResult Delete(int id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            _questions.Remove(question);
            return RedirectToAction("GetAll");
        }
    }
}