using System.ComponentModel.DataAnnotations;

namespace QuizNet.BusinessLogic.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Please specify question text")]
        public string Text { get; set; }
        public AnswerDto[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}
