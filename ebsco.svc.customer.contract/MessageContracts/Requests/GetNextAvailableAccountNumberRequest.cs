namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetNextAvailableAccountNumberRequest
    {
        public string OfficeCode { get; set; }
        public string AccountNumber { get; set; }
    }
}
