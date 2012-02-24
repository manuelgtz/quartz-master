using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Threading;

namespace QuartzMaster
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new Base.ControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "DashboardRoute", // Route name
                "{lang}/Dashboard/{id}", // URL with parameters
                new { lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName, controller = "Overview", action = "Dashboard", id = UrlParameter.Optional } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "{lang}/{controller}/{action}/{id}", // URL with parameters
                new { lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName, controller = "Overview", action = "List", id = UrlParameter.Optional } // Parameter defaults
            );


        }

        protected void Application_Start()
        {

            ViewEngines.Engines.Add(new MobileViewEngine());
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }
    }
}