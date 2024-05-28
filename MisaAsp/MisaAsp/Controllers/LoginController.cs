using Microsoft.AspNetCore.Mvc;
using MisaAsp.Models;
using MisaAsp.Services;
using System.Threading.Tasks;

namespace MisaAsp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public LoginController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAuthenticated = await _registrationService.AuthenticateUserAsync(request);

            if (isAuthenticated)
            {
                return Ok(new { Message = "Login successful!" });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid credentials." });
            }
        }
    }
}
