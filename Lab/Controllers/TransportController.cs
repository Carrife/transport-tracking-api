using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;
        private readonly ILogger<TransportController> _logger;
        public TransportController(ITransportService transportService, ILogger<TransportController> logger)
        {
            _transportService = transportService;
            _logger = logger;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Transport/GetAll");

            return Ok(_transportService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TransportDTO model)
        {
            _logger.LogInformation("Transport/Create");

            if (model == null || _transportService.IsExists(model))
                return BadRequest();

            _transportService.Create(model);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(TransportDTO model)
        {
            _logger.LogInformation($"Transport/Update/{model.Id}");

            if (model == null || !_transportService.IsExistsData(model.Id))
                return BadRequest();

            _transportService.Update(model);

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            _logger.LogInformation($"Transport/Delete/{id}");

            if (id < 1 || !_transportService.IsExistsData(id))
                return BadRequest();

            _transportService.Delete(id);

            return Ok();
        }
    }
}
