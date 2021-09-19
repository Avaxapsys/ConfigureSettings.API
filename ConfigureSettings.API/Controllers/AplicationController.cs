using ConfigureSettings.API.Models;
using ConfigureSettings.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfigureSettings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicationController : ControllerBase
    {
        private readonly IDataRepository<Aplications> _dataRepository;
        public AplicationController(IDataRepository<Aplications> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Aplications
        [HttpGet]
        public IActionResult GetAllAplications()
        {
            IEnumerable<Aplications> aplications = _dataRepository.GetAll();
            return Ok(aplications);
        }

        // GET: api/Aplication/1
        [HttpGet("{id}", Name = "GetAplicationsById")]
        public IActionResult GetAplicationsById(int id)
        {
            Aplications aplication = _dataRepository.Get(id);
            if (aplication == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            return Ok(aplication);
        }

        // Add: api/Aplication
        [HttpPost]
        public IActionResult AddAplication([FromBody] Aplications aplication)
        {
            if (aplication == null)
            {
                return BadRequest("Aplication is null.");
            }
            _dataRepository.Add(aplication);
            return CreatedAtRoute(
                  "GetAplicationsById",
                  new { id = aplication.AplicationId },
                  aplication);
        }

        // Update: api/Aplication/1
        [HttpPut("{id}")]
        public IActionResult UpdateAplicationById(int id, [FromBody] Aplications aplication)
        {
            if (aplication == null)
            {
                return BadRequest("Aplication is null.");
            }
            Aplications aplicationToUpdate = _dataRepository.Get(id);
            if (aplicationToUpdate == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            _dataRepository.Update(aplicationToUpdate, aplication);
            return CreatedAtRoute(
                  "GetAplicationsById",
                  new { id = aplication.AplicationId },
                  aplication);
        }

        // DELETE: api/Aplication/1
        [HttpDelete("{id}")]
        public IActionResult DeleteAplicationById(int id)
        {
            Aplications aplication = _dataRepository.Get(id);
            if (aplication == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            _dataRepository.Delete(aplication);
            return NoContent();
        }
    }
}
