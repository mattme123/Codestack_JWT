using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTClaimsDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult TransferFunds([FromBody] Transfer transfer)
        {
            _accountService.TransferFunds(transfer);
            return NoContent();
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetAccounts(int userId)
        {
            return Ok(_accountService.GetAccounts(userId));
        }
    }
}
