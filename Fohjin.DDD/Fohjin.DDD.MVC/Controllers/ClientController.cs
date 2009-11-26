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
            return RedirectToAction(Views.List);
        }

        public virtual ActionResult List()
        {
            return View(Views.List, GetClientList<ClientReport>());
        }

        public virtual ActionResult Details(Guid id)
        {
            return View(GetClient<ClientDetailsReport>(id));
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
                    return RedirectToAction(Views.List);
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View();
        }

        public virtual ActionResult ClientChangeName(Guid id)
        {
            return View(GetClient<ClientReport>(id));
        }

        [HttpPost]
        public virtual ActionResult ClientChangeName(ClientReport client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ChangeClientNameCommand(client.Id, client.Name));
                    return RedirectToAction(Views.List);
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(client);
        }

        public virtual ActionResult ClientHasMoved(Guid id)
        {
            return View(GetClient<ClientDetailsReport>(id));
        }

        [HttpPost]
        public virtual ActionResult ClientHasMoved(ClientDetailsReport client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ClientIsMovingCommand(client.Id, client.Street, client.StreetNumber, client.PostalCode, client.City));
                    return RedirectToAction(Views.Details, new {id = client.Id});
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(client);
        }

        public virtual ActionResult ClientChangedPhoneNumber(Guid id)
        {
            return View(GetClient<ClientDetailsReport>(id));
        }

        [HttpPost]
        public virtual ActionResult ClientChangedPhoneNumber(ClientDetailsReport client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ChangeClientPhoneNumberCommand(client.Id, client.PhoneNumber));
                    return RedirectToAction(Views.Details, new {id = client.Id});
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(client);
        }

        private IEnumerable<T> GetClientList<T>() where T : class
        {
            return _reportingRepository.GetByExample<T>(null);
        }

        private T GetClient<T>(Guid id) where T : class
        {
            return _reportingRepository.GetByExample<T>(new {id}).FirstOrDefault();
        }

        private void PublishAndCommit(object message)
        {
            _bus.Publish(message);
            _bus.Commit();
        }

        private void ReportError(string message)
        {
            ModelState.AddModelError("*", string.Format("Aww - SNAP! We didn't see this one coming: {0}", message));
        }
    }
}