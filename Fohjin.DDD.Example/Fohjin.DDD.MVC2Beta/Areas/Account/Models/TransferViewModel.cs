using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Fohjin.DDD.Reporting.Dto;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Models
{
    public class TransferViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid AccountId { get; set; }

        [Required]
        [Range(0.01, 100000.00)]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Target Account")]
        public string TargetAccountNumber { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<AccountReport> TargetAccounts { get; set; }
    }
}