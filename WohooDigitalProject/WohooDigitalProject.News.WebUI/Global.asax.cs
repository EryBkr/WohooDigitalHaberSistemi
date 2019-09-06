using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WohooDigitalProject.Core.Utilities.Mvc.Infastructure;
using WohooDigitalProject.News.Bussiness.DependencyResolvers.Ninject;

namespace WohooDigitalProject.News.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BussinessModule()));
            log4net.Config.XmlConfigurator.Configure();
        }

    }
}
