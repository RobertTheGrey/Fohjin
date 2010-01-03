using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fohjin.DDD.Reporting.Dto
{
    public class AccountReport
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid ClientDetailsReportId { get; set; }
        [Required]
        public string AccountName { get; set; }
        [HiddenInput(DisplayValue = false)]
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