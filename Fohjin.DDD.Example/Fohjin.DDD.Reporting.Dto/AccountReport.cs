using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fohjin.DDD.Reporting.Dto
{
    public class AccountReport
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; private set; }
        [HiddenInput(DisplayValue = false)]
        public Guid ClientDetailsReportId { get; private set; }
        [Required]
        public string AccountName { get; private set; }
        public string AccountNumber { get; private set; }

        public AccountReport(){}

        public AccountReport(Guid id, Guid clientDetailsId, string accountName, string accountNumber)
        {
            Id = id;
            ClientDetailsReportId = clientDetailsId;
            AccountName = accountName;
            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return string.Format("{0} - ({1})", AccountNumber, AccountName);
        }
    }
}