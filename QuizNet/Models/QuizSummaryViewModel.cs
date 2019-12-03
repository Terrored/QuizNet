using QuizNet.BusinessLogic.DTOs;
using System.Collections.Generic;

namespace QuizNet.Models
{
    public class QuizSummaryViewModel
    {
        public List<QuestionDto> Questions { get; set; }
        public int[] UserAnswersIndexes { get; set; }
        public int CorrectAnswers { get; set; }

        public double PercentageCorrect => 100 * (double)CorrectAnswers / Questions.Count;

        public string SummaryText
        {
            get
            {
                if (PercentageCorrect > 50)
                    return "Well done!";
                else
                    return "Shame on you!";
            }
        }

        public string ProgressBarColor
        {
            get
            {
                if (PercentageCorrect > 50)
                    return "bg-success";
                else
                    return "bg-danger";
            }
        }

        public string ClassNamesForAnswer(int questionIndex, int answerIndex)
        {
            if (Questions[questionIndex].CorrectAnswerIndex == answerIndex)
                return "list-group-item-success";
            else if (UserAnswersIndexes[questionIndex] == answerIndex)
                return "list-group-item-danger";
            else
                return "";

            //var questionRelated = Questions.SingleOrDefault(q => q.Id == answer.QuestionId);
            //var questionIndex = Questions.FindIndex(q => q.Id == questionRelated.Id);

            //if (questionRelated.CorrectAnswerIndex == iterator)
            //    return "list-group-item-success";
            //else if (UserAnswersIndexes[questionIndex] == iterator)
            //    return "list-group-item-danger";
            //else
            //    return "";
        }
    }
}
