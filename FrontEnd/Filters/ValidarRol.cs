using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrontEnd.Filters
{
    public class ValidarRol : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session == null /*|| context.HttpContext.Session["UserName"] == null*/)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Action = "Error", Controller = "Home"
                }));
            }
        }

    }
}
