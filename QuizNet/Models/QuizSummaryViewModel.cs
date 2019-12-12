using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizNet.BusinessLogic.DTOs;

namespace QuizNet.Models
{
    public class QuizSummaryViewModel
    {
        public List<QuestionDto> Questions { get; set; }
        public int[] UserAnswerIds { get; set; }
        public int CorrectAnswers { get; set; }
        public double PercentageCorrect => 100 * (double)CorrectAnswers / Questions.Count;

        public string SummaryText
        {
            get
            {
                if (PercentageCorrect > 50)
                {
                    return "Well done!";
                }
                else
                {
                    return "Shame on you!";
                }
            }
        }

        public string ProgressBarColor
        {
            get
            {
                if (PercentageCorrect > 50)
                {
                    return "bg-success";
                }
                else
                {
                    return "bg-danger";
                }

            }
        }

        public string ClassNamesForAnswer(AnswerDto answer , int userAnswerIndex)
        {
            if (answer.IsCorrect)
            {
                return "list-group-item-success";
            }
            else if (UserAnswerIds[userAnswerIndex] == answer.Id)
            {
                return "list-group-item-danger";
            }

            return "";
        }
    }
}
