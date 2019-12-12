using System;
using System.ComponentModel.DataAnnotations;

namespace QuizNet.BusinessLogic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify question text")]
        [StringLength(300)]
        public string Text { get; set; }
        public AnswerDto[] Answers { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
