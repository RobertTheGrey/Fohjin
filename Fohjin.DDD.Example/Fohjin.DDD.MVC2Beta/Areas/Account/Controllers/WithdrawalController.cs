using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Areas.Account.Models;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class WithdrawalController : BaseController
    {
        public WithdrawalController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var withdrawal = new AccountActivityViewModel{AccountId = id};
            return View(withdrawal);
        }

        [HttpPost]
        public virtual ActionResult Save(AccountActivityViewModel withdrawal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new WithdrawlCashCommand(withdrawal.AccountId, withdrawal.Amount));
                    return RedirectToAction(MVC.Account.Details.Show(withdrawal.AccountId));
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(Views.Show, withdrawal);
        }
    }
}