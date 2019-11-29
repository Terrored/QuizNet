using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.DataAccess.Models;

namespace QuizNet.Models
{
    public class QuestionFormViewModel
    {
        public QuestionFormViewModel()
        {
            Question = new QuestionDto();
        }

        public QuestionFormViewModel(Question question)
        {
            Question = new QuestionDto()
            {
                Id = question.Id,
                CorrectAnswerIndex = question.CorrectAnswerIndex,
                Text = question.Text,
                Answers = question.Answers
                    .Select(y => new AnswerDto() {Id = y.Id, QuestionId = y.QuestionId, Text = y.Text}).ToArray()
            };
        }

        public Question GetQuestion()
        {
            return new Question()
            {
                Answers = Question.Answers
                    .Select(a => new Answer() {Id = a.Id, Text = a.Text, QuestionId = a.QuestionId}).ToArray(),
                Text = Question.Text,
                Id = Question.Id,
                CorrectAnswerIndex = Question.CorrectAnswerIndex
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
