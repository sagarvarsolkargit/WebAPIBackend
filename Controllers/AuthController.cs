using EmpSkills.Data;
using EmpSkills.Models;
using EmpSkills.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepo;
        private readonly JwtTokenService _tokenService;

        public AuthController(UserRepository userRepo, JwtTokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userRepo.ValidateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
