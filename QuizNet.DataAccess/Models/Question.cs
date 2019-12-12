using System;
using System.Collections.Generic;

namespace QuizNet.DataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
