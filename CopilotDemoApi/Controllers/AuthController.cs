using CopilotDemoApi.Models;
using CopilotDemoApi.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemoApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel userLogin)
        {
            // TODO: add users to DB and check if user exists
            if (userLogin.Username == "test" && userLogin.Password == "password")
            {
                var jwtKey = _configuration["Jwt:Key"]!;

                var tokenString = JwtTool.GenerateAccessToken(userLogin.Username, jwtKey);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
