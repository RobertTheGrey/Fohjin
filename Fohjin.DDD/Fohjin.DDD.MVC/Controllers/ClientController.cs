using System;
using System.Collections.Generic;
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

        //
        // GET: /Client/

        public virtual ActionResult Index()
        {
            IEnumerable<ClientReport> clients = _reportingRepository.GetByExample<ClientReport>(null);
            return View(Views.List, clients);
        }

        //
        // GET: /Client/Details/5

        public virtual ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Client/Create

        public virtual ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Client/Create

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
                    _reportingRepository.GetByExample<ClientDetailsReport>(new {newClient.Id});
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("*", string.Format("Aww - SNAP! We didn't see this coming: {0}", ex.Message));
            }
            return View();
        }

        //
        // GET: /Client/Edit/5

        public virtual ActionResult ClientChangeName(Guid id)
        {
            return View();
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public virtual ActionResult ClientChangeName(ClientReport clientReport)
        {
            try
            {
                ModelState["Id"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    _bus.Publish(new ChangeClientNameCommand(clientReport.Id, clientReport.Name));
                    _bus.Commit();
                    _reportingRepository.GetByExample<ClientDetailsReport>(new {clientReport.Id});
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