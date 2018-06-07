using System;

namespace ebsco.svc.customer.contract
{
    public class MassUpdateRequest
    {
        public enum StatusEnum
        {
            Submitted = 0,
            Processing = 1,
            Complete = 2
        }

        public int Id { get; set; }

        public StatusEnum Status { get; set; }

        public int TotalRecords { get; set; }

        public int RecordsProcessed { get; set;  }

        public DateTime DateSubmitted { get; set; }

        public string RequestedBy { get; set; }

        public string RequestedByEmail { get; set; }

        public string UpdateReason { get; set; }
    }
}
