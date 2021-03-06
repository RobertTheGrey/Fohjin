using System.Web.Mvc;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers
{
    public partial class ListController : BaseController
    {
        public ListController(IReportingRepository reportingRepository) : base(null, reportingRepository) { }

        public virtual ActionResult Show()
        {
            var clients = GetList<ClientReport>();
            return View(clients);
        }
    }
}