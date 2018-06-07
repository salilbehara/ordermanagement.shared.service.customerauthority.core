namespace ebsco.svc.customer.contract
{
    public class CustomerContactSearchResult
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Title { get; set; }

        public string ContactTypes { get; set; }

        public string LegacyMappings { get; set; }

        public string EmailAddress { get; set; }

    }
}
