using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMMS.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SessionConfig : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            //Check session
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectResult("/");
                return;
            }

            base.OnActionExecuting(filterContext);
        }


    }
}