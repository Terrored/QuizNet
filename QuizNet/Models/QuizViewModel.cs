using QuizNet.BusinessLogic.DTOs;
using System.Collections.Generic;

namespace QuizNet.Models
{
    public class QuizViewModel
    {
        public QuizViewModel()
        { }

        public QuizViewModel(List<QuestionDto> questions)
        {
            Questions = questions;
            UserAnswersIndexes = new int[Questions.Count];
        }

        public List<QuestionDto> Questions { get; set; }
        public int[] UserAnswersIndexes { get; set; }
    }
}
