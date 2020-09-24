using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCruitChallenge.Logic;
using EasyCruitChallenge.Models;
using EasyCruitChallenge.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCruitChallenge.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : Controller
    {
        private readonly ICandidateLogic _candidateLogic;

        public CandidateController(ICandidateLogic candidateLogic)
        {
            _candidateLogic = candidateLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Candidate candidate)
        {
            if (candidate.IsValid(out IEnumerable<string> errors))
            {
                var result = _candidateLogic.Create(candidate);

                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var success = _candidateLogic.Delete(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<Candidate> result = _candidateLogic.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            Candidate result = _candidateLogic.Get(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
