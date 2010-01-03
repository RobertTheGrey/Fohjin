using System;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Areas.Account.Models;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class DepositController : BaseController
    {
        public DepositController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var deposit = new AccountActivityViewModel { AccountId = id };
            return View(deposit);
        }

        [HttpPost]
        public virtual ActionResult Save(AccountActivityViewModel deposit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new DepositeCashCommand(deposit.AccountId, deposit.Amount));
                    return RedirectToAction(MVC.Account.Details.Show(deposit.AccountId));
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            return View(Views.Show, deposit);
        }
    }
}