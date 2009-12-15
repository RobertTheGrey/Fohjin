using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Client.Controllers
{
    public partial class CreateController : BaseController
    {
        public CreateController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Save(ClientDetailsReport client)
        {
            try
            {
                ModelState["Id"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    var newClient = new CreateClientCommand(Guid.NewGuid(),
                                                            client.ClientName,
                                                            client.Street,
                                                            client.StreetNumber,
                                                            client.PostalCode,
                                                            client.City,
                                                            client.PhoneNumber);
                    PublishAndCommit(newClient);
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