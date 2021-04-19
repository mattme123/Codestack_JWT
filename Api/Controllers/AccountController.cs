using JWTClaimsDemo.ActionFilter;
using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTClaimsDemo.Controllers
{
    public class AccountController : BaseController
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [ValidateTransfer]
        [HttpPost]
        public IActionResult TransferFunds([FromBody] Transfer transfer)
        {
            _accountService.TransferFunds(transfer);
            return NoContent();
        }

        [ValidateUser]
        [HttpGet("{userId:int}")]
        public IActionResult GetAccounts(int userId)
        {
            return Ok(_accountService.GetAccounts(userId));
        }
    }
}
