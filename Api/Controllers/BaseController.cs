using JWTClaimsDemo.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWTClaimsDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        public UserClaimsPrincipal CurrentUser
        {
            get => new UserClaimsPrincipal(User);
            set => _ = value;
        }

        public class UserClaimsPrincipal : ClaimsPrincipal
        {
            public UserClaimsPrincipal(ClaimsPrincipal principal) : base(principal) { }
            public int UserId => this.FindFirstValue("UserId").ToInt();
        }
    }
}
