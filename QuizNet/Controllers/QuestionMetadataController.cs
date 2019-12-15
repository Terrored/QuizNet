using Microsoft.AspNetCore.Mvc;
using QuizNet.BusinessLogic.Interfaces;

namespace QuizNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionMetadataController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionMetadataController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetQuestionMetadata()
        {
            var metadata = _questionService.GetMetadata();
            return Ok(metadata);
        }
    }
}