using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly ILogger<PriceController> _logger;
        public PriceController(IPriceService priceService, ILogger<PriceController> logger)
        {
            _priceService = priceService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Price/GetAll");

            return Ok(_priceService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PriceDTO model)
        {
            _logger.LogInformation("Price/Create");

            if (model == null || _priceService.IsExists(model.KindId))
                return BadRequest();

            _priceService.Create(model);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(PriceDTO model)
        {
            _logger.LogInformation($"Price/Update/{model.Id}");

            if (model == null || !_priceService.IsExistsData(model.Id))
                return BadRequest();

            _priceService.Update(model);

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            _logger.LogInformation($"Price/Delete/{id}");

            if (id < 1 || !_priceService.IsExistsData(id))
                return BadRequest();

            _priceService.Delete(id);

            return Ok();
        }
    }
}
