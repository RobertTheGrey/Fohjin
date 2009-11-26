using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC.Controllers
{
    public partial class ClientController : Controller
    {
        private readonly IBus _bus;
        private readonly IReportingRepository _reportingRepository;

        public ClientController(IBus bus, IReportingRepository reportingRepository)
        {
            _bus = bus;
            _reportingRepository = reportingRepository;
        }

        public virtual ActionResult Index()
        {
            IEnumerable<ClientReport> clients = _reportingRepository.GetByExample<ClientReport>(null);
            return View(Views.List, clients);
        }

        public virtual ActionResult Details(Guid id)
        {
            var client = _reportingRepository.GetByExample<ClientDetailsReport>(new { id }).FirstOrDefault();
            return View(client);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(ClientDetailsReport clientDetailsReport)
        {
            try
            {
                ModelState["Id"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    var newClient = new CreateClientCommand(Guid.NewGuid(),
                                                         clientDetailsReport.ClientName,
                                                         clientDetailsReport.Street,
                                                         clientDetailsReport.StreetNumber,
                                                         clientDetailsReport.PostalCode,
                                                         clientDetailsReport.City,
                                                         clientDetailsReport.PhoneNumber);
                    _bus.Publish(newClient);
                    _bus.Commit();
                    _reportingRepository.GetByExample<ClientDetailsReport>(new { newClient.Id });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("*", string.Format("Aww - SNAP! We didn't see this coming: {0}", ex.Message));
            }
            return View();
        }

        public virtual ActionResult ClientChangeName(Guid id)
        {
            var client = _reportingRepository.GetByExample<ClientReport>(new { id }).FirstOrDefault();
            return View(client);
        }

        [HttpPost]
        public virtual ActionResult ClientChangeName(ClientReport clientReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bus.Publish(new ChangeClientNameCommand(clientReport.Id, clientReport.Name));
                    _bus.Commit();
                    _reportingRepository.GetByExample<ClientDetailsReport>(new { clientReport.Id });
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("*", string.Format("Aww - SNAP! We didn't see this coming: {0}", ex.Message));
            }
            return View();
        }
    }
}