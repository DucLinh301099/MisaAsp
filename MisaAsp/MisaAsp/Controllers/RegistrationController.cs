using Microsoft.AspNetCore.Mvc;
using MisaAsp.Models;
using MisaAsp.Services;
using System.Threading.Tasks;

namespace MisaAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registrationService.RegisterUserAsync(request);

            if (result > 0)
            {
                return Ok(new { Message = "Registration successful!" });
            }
            else
            {
                return StatusCode(500, "An error occurred while registering the user.");
            }
        }
    }
}
