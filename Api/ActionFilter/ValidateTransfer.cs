using JWTClaimsDemo.Controllers;
using JWTClaimsDemo.Entities.Models;
using JWTClaimsDemo.Extentions.Exceptions;
using JWTClaimsDemo.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace JWTClaimsDemo.ActionFilter
{
    public class ValidateTransfer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var svc = context.HttpContext.RequestServices;
            var accountService = svc.GetService<AccountService>();

            if (context.Controller is BaseController controller)
            {
                var transfer = context.ActionArguments["Transfer"] as Transfer;

                var accounts = accountService.GetAccounts(controller.CurrentUser.UserId);

                var accountIds = accounts.Select(x => x.AccountId).ToList();

                if (!accountIds.Contains(transfer.FromAccountId) || !accountIds.Contains(transfer.ToAccountId)) //validate user has access to accounts
                    throw new CustomException(401, "You can't transfer to that account");

                if (transfer.Amount < 1)
                    throw new CustomException(400, "You cannot tranfer less than 1"); //validate amount is greater than 0

                if (accounts.First(x => x.AccountId == transfer.FromAccountId).Funds < transfer.Amount) //validate has enough money in account
                    throw new CustomException(400, "You do not have enough funds");
            }
        }
    }
}