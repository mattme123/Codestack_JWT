using JWTClaimsDemo.Controllers;
using JWTClaimsDemo.Extensions;
using JWTClaimsDemo.Extentions.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWTClaimsDemo.ActionFilter
{
    public class ValidateUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("UserId", out object value))
            {
                if (context.Controller is BaseController controller)
                {
                    if (!value.IsNull() && controller.CurrentUser.UserId != value.ToInt())
                    {
                        throw new CustomException(401, "You can't do that");
                    }
                }
            }
        }
    }
}