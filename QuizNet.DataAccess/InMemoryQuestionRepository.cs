using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNet.DataAccess.Models;

namespace QuizNet.DataAccess
{
    public class InMemoryQuestionRepository : IQuestionRepository
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

        public IEnumerable<Question> GetAll()
        {
            return _questions;
        }

        public Question GetById(int id)
        {
            return _questions.SingleOrDefault(x => x.Id == id);
        }

        public void Add(Question question)
        {
            _questions.Add(question);
        }

        public void Update(Question updatedQuestion)
        {
            throw new NotImplementedException();
        }

        public void Delete(int questionId)
        {
            var question = _questions.SingleOrDefault(x => x.Id == questionId);
            _questions.Remove(question);
        }
    }
}
