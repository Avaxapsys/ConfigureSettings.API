using ConfigureSettings.API.Models;
using ConfigureSettings.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureSettingsController : ControllerBase
    {
        private readonly IDataRepository<Settings> _dataRepository;
        private readonly IEnvironventRepository<Settings> _environventRepository;
        public ConfigureSettingsController(IDataRepository<Settings> dataRepository, IEnvironventRepository<Settings> environventRepository)
        {
            _dataRepository = dataRepository;
            _environventRepository = environventRepository;
        }

        // GET: api/Settings
        [HttpGet]
        public async Task<IActionResult> GetAllSettingsAsync()
        {
            IEnumerable<Settings> settings = await _dataRepository.GetAllAsync();
            return Ok(settings);
        }

        // GET: api/Settings/1
        [HttpGet("{id}", Name = "GetSettingById")]
        public async Task<IActionResult> GetSettingByIdAsync(int id)
        {
            Settings settings = await _dataRepository.GetByIdAsync(id);
            if (settings == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            return Ok(settings);
        }

        // GET: api/Settings/CRM
        [HttpGet("/by-aplication/{name}")]
        public async Task<IActionResult> GetSettingByAplicationNameAsync(string name)
        {
            IEnumerable<Settings> settings = await _environventRepository.GetByAplicationNameAsync(name);
            if (settings == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            return Ok(settings);
        }

        // Add: api/Settings
        [HttpPost]
        public async Task<IActionResult> AddSettingAsync([FromBody] Settings settings)
        {
            if (settings == null)
            {
                return BadRequest("Settings is null.");
            }
            await _dataRepository.AddAsync(settings);
            return CreatedAtRoute(
                  "GetSettingById",
                  new { id = settings.SettingId },
                  settings);
        }

        // Update: api/Settings/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSettingByIdAsync(int id, [FromBody] Settings settings)
        {
            if (settings == null)
            {
                return BadRequest("Settings is null.");
            }
            Settings settingsToUpdate = await _dataRepository.GetByIdAsync(id);
            if (settingsToUpdate == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(settingsToUpdate, settings);
            return CreatedAtRoute(
                  "GetSettingById",
                  new { id = settings.SettingId },
                  settings);
        }

        // DELETE: api/Settings/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSettingByIdAsync(int id)
        {
            Settings settings = await _dataRepository.GetByIdAsync(id);
            if (settings == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            await _dataRepository.DeleteAsync(settings);
            return NoContent();
        }
    }
}
