using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class CreateController : BaseController
    {
        public CreateController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var newAccount = new AccountReport { ClientDetailsReportId = id };
            return View(newAccount);
        }

        [HttpPost]
        public virtual ActionResult Save(AccountReport account)
        {
            try
            {
                ModelState["Id"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    var newAccount = new OpenNewAccountForClientCommand(account.ClientDetailsReportId, account.AccountName);
                    PublishAndCommit(newAccount);
                    return RedirectToAction(MVC.Client.Details.Show(account.ClientDetailsReportId));
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(Views.Show, account);
        }
    }
}