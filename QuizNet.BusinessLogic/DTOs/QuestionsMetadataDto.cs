using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNet.BusinessLogic.DTOs
{
    public class QuestionsMetadataDto
    {
        public int QuestionsCount { get; set; }
        public DateTime OldestQuestion { get; set; }
        public DateTime NewestQuestion { get; set; }
    }
}
