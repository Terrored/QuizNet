using QuizNet.BusinessLogic.DTOs;

namespace QuizNet.Models
{
    public class QuestionFormViewModel
    {
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
