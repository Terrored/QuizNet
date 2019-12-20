using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizNet.DataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
