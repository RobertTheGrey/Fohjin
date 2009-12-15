using System;
using System.Web.Mvc;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers
{
    public partial class DetailsController : BaseController
    {
        public DetailsController(IReportingRepository reportingRepository) : base(null, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var client = GetById<ClientDetailsReport>(id);
            return View(client);
        }
    }
}