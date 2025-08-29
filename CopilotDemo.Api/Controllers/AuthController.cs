using CopilotDemo.Domain.Models;
using CopilotDemo.Infrastructure.Interfaces;
using CopilotDemo.Infrastructure.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CopilotDemo.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILiteDbService _liteDbService;

        public AuthController(IConfiguration configuration, ILiteDbService liteDbService)
        {
            _configuration = configuration;
            _liteDbService = liteDbService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel userLogin)
        {
            var users = _liteDbService.GetUsers();
            var user = users.FindOne(u => u.Username == userLogin.Username && u.Password == userLogin.Password);
            if (user != null)
            {
                var jwtKey = _configuration["Jwt:Key"]!;
                var tokenString = JwtTool.GenerateAccessToken(user.Username, user.Role, jwtKey);
                return Ok(new { Token = tokenString, Role = user.Role });
            }
            return Unauthorized();
        }
    }
}
