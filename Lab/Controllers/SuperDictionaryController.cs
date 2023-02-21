using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperDictionaryController : ControllerBase
    {
        private readonly ISuperDictionaryService _superDictionaryService;
        private readonly ILogger<SuperDictionaryController> _logger;
        public SuperDictionaryController(ISuperDictionaryService superDictionaryService, ILogger<SuperDictionaryController> logger)
        {
            _superDictionaryService = superDictionaryService;
            _logger = logger;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("SuperDictionary/GetAll");

            return Ok(_superDictionaryService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] SuperDictionaryDTO model)
        {
            _logger.LogInformation("SuperDictionary/Create");

            if (model == null || _superDictionaryService.IsExists(model))
                return BadRequest();

            _superDictionaryService.Create(model);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(SuperDictionaryDTO model)
        {
            _logger.LogInformation($"SuperDictionary/Update/{model.Id}");

            if (model == null || !_superDictionaryService.IsExistsData(model.Id))
                return BadRequest();

            _superDictionaryService.Update(model);

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            _logger.LogInformation($"SuperDictionary/Delete/{id}");

            if (id < 1 || !_superDictionaryService.IsExistsData(id))
                return BadRequest();

            _superDictionaryService.Delete(id);

            return Ok();
        }
    }
}
