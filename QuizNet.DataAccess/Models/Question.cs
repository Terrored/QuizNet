using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizNet.DataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        [ForeignKey("CorrectAnswer")]
        public int? CorrectAnswerId { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
