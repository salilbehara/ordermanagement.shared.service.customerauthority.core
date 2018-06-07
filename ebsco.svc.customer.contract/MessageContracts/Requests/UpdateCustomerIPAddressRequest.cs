namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateCustomerIPAddressRequest : UpdateRequestBase
    {
        public CustomerIPAddress IpAddress { get; set; }
    }
}
