using Lab.DTOs;
using Lab.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("User/GetAll");

            return Ok(_userService.ListAll());
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserDTO model)
        {
            _logger.LogInformation("User/Create");

            if (model == null)
                return BadRequest();

            _userService.Create(model);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(UserDTO model)
        {
            _logger.LogInformation($"User/Update/{model.Id}");

            if (model == null || !_userService.IsExistsData(model.Id))
                return BadRequest();

            _userService.Update(model);

            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            _logger.LogInformation($"User/Delete/{id}");

            if (id < 1 || !_userService.IsExistsData(id))
                return BadRequest();

            _userService.Delete(id);

            return Ok();
        }
    }
}
