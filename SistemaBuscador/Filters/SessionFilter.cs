using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaBuscador.Filters
{
    public class SessionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionId = context.HttpContext.Request.Cookies["sessionId"];
            if (string.IsNullOrEmpty(sessionId) || !sessionId.Equals(context.HttpContext.Session.GetString("sessionId")))
            {
                context.Result = new RedirectToActionResult("index", "Login", null);

            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }


    }
}
