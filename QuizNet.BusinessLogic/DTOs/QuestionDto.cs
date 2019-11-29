using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuizNet.DataAccess.Models;

namespace QuizNet.BusinessLogic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please specify question text")]
        [StringLength(5)]
        public string Text { get; set; }
        public AnswerDto[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}
