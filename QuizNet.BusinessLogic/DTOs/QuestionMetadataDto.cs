using System;

namespace QuizNet.BusinessLogic.DTOs
{
    public class QuestionMetadataDto
    {
        public int QuestionCount { get; set; }
        public DateTime OldestQuestion { get; set; }
        public DateTime NewestQuestion { get; set; }
    }
}
