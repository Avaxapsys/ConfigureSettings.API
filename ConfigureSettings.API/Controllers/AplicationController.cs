using ConfigureSettings.API.Models;
using ConfigureSettings.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllAplicationsAsync()
        {
            IEnumerable<Aplications> aplications = await _dataRepository.GetAllAsync();
            return Ok(aplications);
        }

        // GET: api/Aplication/1
        [HttpGet("{id}", Name = "GetAplicationsById")]
        public async Task<IActionResult>GetAplicationsByIdAsync(int id)
        {
            Aplications aplication = await _dataRepository.GetByIdAsync(id);
            if (aplication == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            return Ok(aplication);
        }

        // Add: api/Aplication
        [HttpPost]
        public async Task<IActionResult> AddAplicationAsync([FromBody] Aplications aplication)
        {
            if (aplication == null)
            {
                return BadRequest("Aplication is null.");
            }
            await _dataRepository.AddAsync(aplication);
            return CreatedAtRoute(
                  "GetAplicationsById",
                  new { id = aplication.AplicationId },
                  aplication);
        }

        // Update: api/Aplication/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAplicationByIdAsync(int id, [FromBody] Aplications aplication)
        {
            if (aplication == null)
            {
                return BadRequest("Aplication is null.");
            }
            Aplications aplicationToUpdate = await _dataRepository.GetByIdAsync(id);
            if (aplicationToUpdate == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(aplicationToUpdate, aplication);
            return CreatedAtRoute(
                  "GetAplicationsById",
                  new { id = aplication.AplicationId },
                  aplication);
        }

        // DELETE: api/Aplication/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicationByIdAsync(int id)
        {
            Aplications aplication = await _dataRepository.GetByIdAsync(id);
            if (aplication == null)
            {
                return NotFound("The Aplication record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(aplication);
            return NoContent();
        }
    }
}
