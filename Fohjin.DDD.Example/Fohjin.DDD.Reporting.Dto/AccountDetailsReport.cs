using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fohjin.DDD.Reporting.Dto
{
    public class AccountDetailsReport
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; private set; }
        [HiddenInput(DisplayValue = false)]
        public Guid ClientReportId { get; private set; }
        [ScaffoldColumn(false)]
        public IEnumerable<LedgerReport> Ledgers { get; private set; }
        [Required]
        public string AccountName { get; private set; }
        public decimal Balance { get; set; }
        public string AccountNumber { get; private set; }

        public AccountDetailsReport(Guid id, Guid clientId, string accountName, decimal balance, string accountNumber)
        {
            Id = id;
            ClientReportId = clientId;
            Ledgers = new List<LedgerReport>();
            AccountName = accountName;
            Balance = balance;
            AccountNumber = accountNumber;
        }
    }
}