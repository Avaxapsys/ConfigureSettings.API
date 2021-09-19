using ConfigureSettings.API.Models;
using ConfigureSettings.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfigureSettings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureSettingsController : ControllerBase
    {
        private readonly IDataRepository<Settings> _dataRepository;
        public ConfigureSettingsController(IDataRepository<Settings> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Settings
        [HttpGet]
        public IActionResult GetAllSettings()
        {
            IEnumerable<Settings> setting = _dataRepository.GetAll();
            return Ok(setting);
        }

        // GET: api/Settings/1
        [HttpGet("{id}", Name = "GetSettingById")]
        public IActionResult GetSettingById(int id)
        {
            Settings settings = _dataRepository.Get(id);
            if (settings == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            return Ok(settings);
        }

        // Add: api/Settings
        [HttpPost]
        public IActionResult AddSetting([FromBody] Settings settings)
        {
            if (settings == null)
            {
                return BadRequest("Settings is null.");
            }
            _dataRepository.Add(settings);
            return CreatedAtRoute(
                  "GetSettingById",
                  new { id = settings.SettingId },
                  settings);
        }

        // Update: api/Settings/1
        [HttpPut("{id}")]
        public IActionResult UpdateSettingById(int id, [FromBody] Settings settings)
        {
            if (settings == null)
            {
                return BadRequest("Settings is null.");
            }
            Settings settingsToUpdate = _dataRepository.Get(id);
            if (settingsToUpdate == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            _dataRepository.Update(settingsToUpdate, settings);
            return NoContent();
        }

        // DELETE: api/Settings/1
        [HttpDelete("{id}")]
        public IActionResult DeleteSettingById(int id)
        {
            Settings settings = _dataRepository.Get(id);
            if (settings == null)
            {
                return NotFound("The Settings record couldn't be found.");
            }
            _dataRepository.Delete(settings);
            return NoContent();
        }
    }
}
