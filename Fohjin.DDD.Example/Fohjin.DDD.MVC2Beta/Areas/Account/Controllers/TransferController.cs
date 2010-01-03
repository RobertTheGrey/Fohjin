using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Fohjin.DDD.Bus;
using Fohjin.DDD.Commands;
using Fohjin.DDD.MVC2Beta.Areas.Account.Models;
using Fohjin.DDD.MVC2Beta.Controllers;
using Fohjin.DDD.Reporting;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Controllers
{
    public partial class TransferController : BaseController
    {
        public TransferController(IBus bus, IReportingRepository reportingRepository) : base(bus, reportingRepository) { }

        public virtual ActionResult Show(Guid id)
        {
            var transfer = new TransferViewModel { AccountId = id, TargetAccounts = GetPossibleTargetAccounts(id) };
            return View(transfer);
        }

        [HttpPost]
        public virtual ActionResult Save(TransferViewModel transfer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PublishAndCommit(new SendMoneyTransferCommand(transfer.AccountId, transfer.Amount, transfer.TargetAccountNumber));
                    return RedirectToAction(MVC.Account.Details.Show(transfer.AccountId));
                }
            }
            catch (Exception ex)
            {
                ReportError(ex.Message);
            }
            transfer.TargetAccounts = GetPossibleTargetAccounts(transfer.AccountId);
            return View(Views.Show, transfer);
        }

        private IEnumerable<AccountReport> GetPossibleTargetAccounts(Guid id)
        {
            var clientId = GetById<AccountDetailsReport>(id).ClientReportId;
            return GetById<ClientDetailsReport>(clientId).Accounts.Where(account => account.Id != id);
        }

    }
}