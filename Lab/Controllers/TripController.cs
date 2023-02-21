using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly ILogger<TripController> _logger;
        public TripController(ITripService tripService, ILogger<TripController> logger)
        {
            _tripService = tripService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Trip/GetAll");

            return Ok(_tripService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] TripDTO model)
        {
            _logger.LogInformation("Trip/Create");

            if (model == null)
                return BadRequest();

            _tripService.Create(model);

            return Ok();
        }
    }
}
