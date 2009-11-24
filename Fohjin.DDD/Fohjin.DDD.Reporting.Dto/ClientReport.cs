using System;

namespace Fohjin.DDD.Reporting.Dto
{
    public class ClientReport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ClientReport(){}

        public ClientReport(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}