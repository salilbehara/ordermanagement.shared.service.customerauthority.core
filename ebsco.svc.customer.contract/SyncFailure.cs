using System;

namespace ebsco.svc.customer.contract
{
    public class SyncFailure
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public string SyncType { get; set; }

        public string EntityType { get; set; }

        public int EntityId { get; set; }

        public DateTime FailureDate { get; set; }

        public int RetryCount { get; set; }
        public DateTime? LastRetryDate { get; set; }
        public DateTime? ClearedDate { get; set; }

        public string FailureReason { get; set; }
    }
}
