using E_ticaret.Entity;
using E_ticaret.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_ticaret
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Database.SetInitializer(new DataInitializer());
            Database.SetInitializer(new IdentityInitializer());
        }
    }
}
