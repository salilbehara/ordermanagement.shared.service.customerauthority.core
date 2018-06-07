namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateCustomerIPAddressRequest : UpdateRequestBase
    {
        public CustomerIPAddress IpAddress { get; set; }
    }
}
