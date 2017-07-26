using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMarketting
{
    public class AdminAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["Rol"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/NotFound");
            }
            else if ((string)HttpContext.Current.Session["Rol"] == "User")
            {
                filterContext.Result = new RedirectResult("/Home/NotFound");
            }
        }
    }
}