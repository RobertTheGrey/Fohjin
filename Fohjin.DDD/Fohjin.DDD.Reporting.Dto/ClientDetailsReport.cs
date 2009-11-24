using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fohjin.DDD.Reporting.Dto
{
    public class ClientDetailsReport
    {
        public Guid Id { get; set; }
        public IEnumerable<AccountReport> Accounts { get; private set; }
        public IEnumerable<ClosedAccountReport> ClosedAccounts { get; private set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public ClientDetailsReport() { }

        public ClientDetailsReport(Guid id, string clientName, string street, string streetNumber, string postalCode, string city, string phoneNumber)
        {
            Id = id;
            Accounts = new List<AccountReport>();
            ClosedAccounts = new List<ClosedAccountReport>();
            ClientName = clientName;
            Street = street;
            StreetNumber = streetNumber;
            PostalCode = postalCode;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}