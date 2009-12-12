using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fohjin.DDD.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            RegisterIoC();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Client", action = "Index", id = ""} // Parameter defaults
                );
        }

        private static void RegisterIoC()
        {
            MvcApplicationBootStrapper.BootStrap();
            ControllerBuilder.Current.SetControllerFactory(MvcApplicationBootStrapper.GetControllerFactory());
        }


    }
}