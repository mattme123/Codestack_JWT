using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Extensions;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTClaimsDemo.Controllers
{
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Login(request);

            if (user.IsNull())
                return Unauthorized();

            user.Token = _authService.WriteToken(new JWTRequest
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            });

            return Ok(user);
        }
    }
}
