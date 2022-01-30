using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestaoInstituto.Helpers
{
    public class BasicAuthorizeAttribute : TypeFilterAttribute
    {
        public BasicAuthorizeAttribute() :
            base(typeof(AuthorizeAttribute))
        {
            Arguments = new object[]
            {
            };
        }
    }
    public class AuthorizeAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Claims.Count() > 0)
            {
               

            }
            else
            {
                context.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                   });
            }
        }
    }
}
