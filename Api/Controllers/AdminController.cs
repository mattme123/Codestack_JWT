using JWTClaimsDemo.ActionFilter;
using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTClaimsDemo.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AdminController : BaseController
    {
        private readonly AccountService _accountService;
        public AdminController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult AddChristmasGift()
        {
            _accountService.AddChristmasGift();
            return NoContent();
        }
    }
}
