using System.Collections.Generic;

namespace QuizNet.Models
{
    public class QuestionFormViewModel
    {
        public QuestionFormViewModel()
        {
            Answers = new List<string>(new string[4]);
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
        //public QuestionDto Question { get; set; }

        public string ActionType
        {
            get
            {
                if (QuestionId == 0)
                    return "Create";
                else
                    return "Edit";
            }
        }
    }
}
