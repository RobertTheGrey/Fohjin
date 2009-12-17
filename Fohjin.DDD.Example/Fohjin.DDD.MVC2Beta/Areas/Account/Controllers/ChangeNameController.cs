using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class ChangeNameController : BaseController
    {
        public ChangeNameController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var account = GetById<AccountReport>(id);
            return View(account);
        }

        [HttpPost]
        public virtual ActionResult Save(AccountReport account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new ChangeAccountNameCommand(account.Id, account.AccountName));
                    return RedirectToAction(MVC.Account.Details.Show(account.Id));
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View("Show", account);
        }
    }
}