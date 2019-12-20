using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNet.BusinessLogic.DTOs;
using QuizNet.BusinessLogic.Interfaces;

namespace QuizNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsMetadataController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsMetadataController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetMetadata()
        {
            var metadata = _questionService.GetMetadata();
            if (metadata != null)
            {
                return Ok(metadata);
            }

            return BadRequest();

        }
    }
}