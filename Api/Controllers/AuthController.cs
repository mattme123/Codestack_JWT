using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Extensions;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTClaimsDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Login(request);

            if (user.IsNull())
                return Unauthorized();

            user.Token = _authService.WriteToken();

            return Ok(user);
        }
    }
}
