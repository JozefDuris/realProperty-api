using CopilotDemo.Application.Interfaces;
using CopilotDemo.Domain.Models;
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
            var user = _liteDbService.GetUser(userLogin.Username, userLogin.Password);
            if (user != null)
            {
                var jwtKey = _configuration["Jwt:Key"]!;
                var tokenString = JwtTool.GenerateAccessToken(user.Username, user.Role, jwtKey);
                return Ok(new { Token = tokenString, user.Role });
            }
            return Unauthorized();
        }
    }
}
