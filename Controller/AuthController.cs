using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalManagementSystemAPI.Models;
using HospitalManagementSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using HospitalManagementSystemAPI.DTO;
using System.Threading.Tasks;

namespace HospitalManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService, IConfiguration configuration)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            // Check if user exists.
            if (await _authService.GetUserAsync(model.Username) != null)
                return Conflict("User already exists.");

            var user = await _authService.Register(model);
            return Created("", user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var token = await _authService.Authnticate(model);

            if (token == null)
                Unauthorized();

            return Ok(token);

        }
    }
}
