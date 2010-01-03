using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class DetailsController : BaseController
    {
        public DetailsController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var account = GetById<AccountDetailsReport>(id);
            return View(account);
        }
    }
}