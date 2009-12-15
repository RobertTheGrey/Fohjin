using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers
{
    public partial class ChangeAddressController : BaseController
    {
        public ChangeAddressController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var client = GetById<ClientDetailsReport>(id);
            return View(client);
        }

        [HttpPost]
        public virtual ActionResult Save(ClientDetailsReport client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ClientIsMovingCommand(client.Id, client.Street, client.StreetNumber, client.PostalCode, client.City));
                    return RedirectToAction(MVC.Client.Details.Show(client.Id));
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