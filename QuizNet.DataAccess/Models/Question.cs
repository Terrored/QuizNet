using System;

namespace QuizNet.DataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answer[] Answers { get; set; }
        public int CorrectAnswerId { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
