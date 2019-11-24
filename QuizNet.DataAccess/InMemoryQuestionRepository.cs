using QuizNet.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

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
            },
            new Question()
            {
                Id = 3,
                Text = "Kiedy następne zajęcia?",
                CorrectAnswerIndex = 2,
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 9,
                        QuestionId = 3,
                        Text = "Dziś"

                    },
                    new Answer()
                    {
                        Id = 10,
                        QuestionId = 3,
                        Text = "Jutro"

                    },
                    new Answer()
                    {
                        Id = 11,
                        QuestionId = 3,
                        Text = "Za tydzień"

                    },
                    new Answer()
                    {
                        Id = 12,
                        QuestionId = 3,
                        Text = "Nigdy"

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
            var newQuestionId = _questions.Last().Id + 1;
            question.Id = newQuestionId;

            var lastAnswerId = _questions.LastOrDefault().
                Answers.LastOrDefault().Id;


            for (int i = 0; i < question.Answers.Length; i++)
            {
                question.Answers[i].Id = lastAnswerId + i + 1;
                question.Answers[i].QuestionId = newQuestionId;
            }

            _questions.Add(question);
        }

        public void Update(Question updatedQuestion)
        {
            var questionToEdit = _questions.FirstOrDefault(q => q.Id == updatedQuestion.Id);
            questionToEdit.Text = updatedQuestion.Text;
            questionToEdit.CorrectAnswerIndex = updatedQuestion.CorrectAnswerIndex;

            for (int i = 0; i < updatedQuestion.Answers.Length; i++)
            {
                questionToEdit.Answers[i].Text = updatedQuestion.Answers[i].Text;
            }
        }

        public void Delete(int questionId)
        {
            var question = _questions.SingleOrDefault(x => x.Id == questionId);
            _questions.Remove(question);
        }
    }
}
