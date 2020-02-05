using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace WDTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Fires upon attempting to authenticate the use
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    FormsIdentity formsIdent = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket formsAuthTicket = formsIdent.Ticket;

                    string[] astrRoles = formsAuthTicket.UserData.Split(',');

                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(formsIdent, astrRoles);
                }
            }
        }
    }
}
