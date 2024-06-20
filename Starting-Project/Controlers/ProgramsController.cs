using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Controlers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProgramsController : Controller
    {
        private readonly IProgramsRepository _programsRepository;
        private readonly IMapper _mapper;

        public ProgramsController(IProgramsRepository programsRepository, IMapper mapper)
        {
            _programsRepository = programsRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPrograms()
        {
            var programs = _programsRepository.GetPrograms();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(programs);
        }
        [HttpGet("{Id}")]
        public IActionResult GetProgram(int Id)
        {
            var program = _programsRepository.GetProgramById(Id);
            if (program == null)
            {
                return NotFound();
            }
            return Ok(program);
        }
        [HttpPost]
        public IActionResult CreateProgram([FromBody] Models.Programs program)
        {
            if (program == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var programEntity = _mapper.Map<Programs>(program);
            _programsRepository.CreateProgram(programEntity);
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateProgram(int Id, [FromBody] Models.Programs program)
        {
            if (program == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var programEntity = _mapper.Map<Programs>(program);
            _programsRepository.UpdateProgram(programEntity);
            return Ok();
        }

    }
}
