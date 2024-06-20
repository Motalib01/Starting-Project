using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionsRepository questionsRepository, IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            var questions = _questionsRepository.GetQuestions();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(questions);
        }
        [HttpGet("{Id}")]
        public IActionResult GetQuestion(int Id)
        {
            var question = _questionsRepository.GetQuestion(Id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        [HttpPost]
        public IActionResult CreateQuestion([FromBody] Models.Questions question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var questionEntity = _mapper.Map<Questions>(question);
            _questionsRepository.AddQuestion(questionEntity);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateQuestion(int Id, [FromBody] Models.Questions question)
        {
            if (question == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var questionEntity = _mapper.Map<Questions>(question);
            _questionsRepository.UpdateQuestion( questionEntity);
            return Ok();
        }
    }
}
