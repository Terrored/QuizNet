using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNet.BusinessLogic.DTO
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public AnswerDto[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}
