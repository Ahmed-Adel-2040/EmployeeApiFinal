using Application.Login_Data;
using Employment_System_Api_V3.GenerateToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Employment_System_Api_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IConfiguration _config;
        public AuthController(JwtTokenGenerator jwtTokenGenerator,IConfiguration config)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUser request)
        {
            // Simulate user validation (replace with real DB check)
            var user = _config["user"];
            var pass = _config["Password"];
            if (request.UserName == user && request.Password == pass)
            {
                var token = _jwtTokenGenerator.GenerateToken(request.UserName, request.Password);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
