namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetActiveDirectoryEmployeeRequest
    {
        public string EmailAddress { get; set; }

        public string Sid { get; set; }
    }
}
