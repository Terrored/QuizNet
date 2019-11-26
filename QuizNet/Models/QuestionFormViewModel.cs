using QuizNet.BusinessLogic.DTO;
using QuizNet.DataAccess.Models;
using System.Linq;

namespace QuizNet.Models
{
    public class QuestionFormViewModel
    {
        //temporary - mark as homework to introduce service on top of question repository

        public QuestionFormViewModel()
        {
            Question = new QuestionDto();
        }

        public QuestionFormViewModel(Question question)
        {
            Question = new QuestionDto()
            {
                Answers = question.Answers.Select(a => new AnswerDto()
                {
                    Id = a.Id,
                    QuestionId = a.QuestionId,
                    Text = a.Text
                }).ToArray(),

                CorrectAnswerIndex = question.CorrectAnswerIndex,
                Id = question.Id,
                Text = question.Text
            };
        }

        public Question GetQuestion()
        {
            return new Question()
            {
                Answers = Question.Answers.Select(a => new Answer() { Id = a.Id, QuestionId = a.QuestionId, Text = a.Text }).ToArray(),
                Text = Question.Text,
                CorrectAnswerIndex = Question.CorrectAnswerIndex,
                Id = Question.Id
            };
        }

        public QuestionDto Question { get; set; }
        public string ActionType
        {
            get
            {
                if (Question.Id == 0)
                    return "Create";
                else
                    return "Edit";
            }
        }


    }
}
