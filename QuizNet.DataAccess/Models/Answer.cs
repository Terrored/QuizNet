using System.ComponentModel.DataAnnotations;

namespace QuizNet.DataAccess.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}