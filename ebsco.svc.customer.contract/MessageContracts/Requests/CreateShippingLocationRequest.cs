namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateShippingLocationRequest : UpdateRequestBase
    {
        public ShippingLocation Location { get; set; }
    }
}
