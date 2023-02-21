using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransportChoiceController : ControllerBase
    {
        private readonly IUserTransportChoiceService _userTransportChoiceService;
        private readonly ILogger<UserTransportChoiceController> _logger;
        public UserTransportChoiceController(IUserTransportChoiceService userTransportChoiceService, ILogger<UserTransportChoiceController> logger)
        {
            _userTransportChoiceService = userTransportChoiceService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("UserTransportChoice/GetAll");

            return Ok(_userTransportChoiceService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserTransportChoiceDTO model)
        {
            _logger.LogInformation("UserTransportChoice/Create");

            if (model == null || _userTransportChoiceService.IsExists(model))
                return BadRequest();

            _userTransportChoiceService.Create(model);

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            _logger.LogInformation($"UserTransportChoice/Delete/{id}");

            if (id < 1 || !_userTransportChoiceService.IsExistsData(id))
                return BadRequest();

            _userTransportChoiceService.Delete(id);

            return Ok();
        }
    }
}
