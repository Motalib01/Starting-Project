using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starting_Project.Interfaces;
using Starting_Project.Models;

namespace Starting_Project.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCandidates()
        {
            var candidates = _candidateRepository.GetCandidates();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(candidates);
        }

        [HttpGet("{Id}")]
        public IActionResult GetCandidate(int Id)
        {
            var candidate = _candidateRepository.GetCandidate(Id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpPost]
        public IActionResult CreateCandidate([FromBody] Models.Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var candidateEntity = _mapper.Map<Candidate>(candidate);
            _candidateRepository.AddCandidate(candidateEntity);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateCandidate(int Id, [FromBody] Models.Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var candidateEntity = _candidateRepository.GetCandidate(Id);
            if (candidateEntity == null)
            {
                return NotFound();
            }   
            _mapper.Map(candidate, candidateEntity);
            _candidateRepository.UpdateCandidate(candidateEntity);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCandidate(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var candidate = _candidateRepository.GetCandidate(Id);
            if (candidate == null)
            {
                return NotFound();
            }
            _candidateRepository.DeleteCandidate(Id);
            return Ok();
        }   
    }
}
