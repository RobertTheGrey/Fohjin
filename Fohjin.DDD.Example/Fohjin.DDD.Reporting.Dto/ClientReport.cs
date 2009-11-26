using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Fohjin.DDD.Reporting.Dto
{
    public class ClientReport
    {
        public ClientReport()
        {
        }

        public ClientReport(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}