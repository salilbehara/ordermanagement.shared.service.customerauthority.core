namespace ebsco.svc.customer.contract
{
    public class CustomerSearchResult
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string ExternalId { get; set; }

        public string LegacyMappings { get; set; }

        public string DDECustomerID { get; set; }

        public bool IsInactive { get; set; }

    }
}
