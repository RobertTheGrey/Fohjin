using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fohjin.DDD.MVC2Beta.Areas.Account.Models
{
    public class AccountActivityViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid AccountId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}