using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Reporting;

namespace Fohjin.DDD.MVC2Beta.Controllers
{
    public partial class BaseController : Controller
    {
        private readonly IBus _bus;
        protected IReportingRepository _reportingRepository;

        protected BaseController(){}

        protected BaseController(IBus bus, IReportingRepository reportingRepository)
        {
            _bus = bus;
            _reportingRepository = reportingRepository;
        }

        protected IEnumerable<T> GetList<T>() where T : class
        {
            return _reportingRepository.GetByExample<T>(null);
        }

        protected T GetById<T>(Guid id) where T : class
        {
            return _reportingRepository.GetByExample<T>(new { id }).FirstOrDefault();
        }

        protected void PublishAndCommit(object message)
        {
            _bus.Publish(message);
            _bus.Commit();
        }

        protected void ReportError(string message)
        {
            ModelState.AddModelError("*", string.Format("Aww - SNAP! We didn't see this one coming: {0}", message));
        }
    }
}