using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace ECommApplication.CustomFilters
{
    public class AuthAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["AdminUserName"])))
            {
                filterContext.Result = new RedirectToRouteResult("", null);
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "AdminLogin");
                redirectTargetDictionary.Add("controller", "Account");
                redirectTargetDictionary.Add("customMessage", "Session Timeout!!!");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            //throw new NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
          //  throw new NotImplementedException();
        }
    }
}