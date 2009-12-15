using System.Web.Mvc;

namespace Fohjin.DDD.MVC2Beta.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                new { action = "Index", id = "" }
            );
        }
    }
}
