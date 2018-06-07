namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class GetActiveDirectoryEmployeeResponse
    {
        public string SecurityId { get; set; }

        public string DisplayName { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Enabled { get; set; }

    }
}

