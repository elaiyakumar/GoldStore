using GoldStore.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GoldStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
         

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //initialize engine context
            EngineContext.Initialize(false);
        }

        protected void Application_Eror(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            //Log error
            HttpException httpExp  = Ex as HttpException;             

        }
    }
}
