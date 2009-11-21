using System.Collections.Generic;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC.Controllers
{
    public partial class ClientController : Controller
    {
        private readonly IReportingRepository _reportingRepository;
        private IBus _bus;

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
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Client/Edit/5

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}