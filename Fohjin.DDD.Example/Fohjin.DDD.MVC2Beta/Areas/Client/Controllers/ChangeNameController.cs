using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers
{
    public partial class ChangeNameController : BaseController
    {
        public ChangeNameController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var client = GetById<ClientReport>(id);
            return View(client);
        }

        [HttpPost]
        public virtual ActionResult Save(ClientReport client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ChangeClientNameCommand(client.Id, client.Name));
                    return RedirectToAction(MVC.Client.List.Show());
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(Views.Show, client);
        }
    }
}