namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateShippingLocationRequest : UpdateRequestBase
    {
        public ShippingLocation Location { get; set; }
    }
}
