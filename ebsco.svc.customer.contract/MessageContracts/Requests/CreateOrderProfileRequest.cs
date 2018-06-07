namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateOrderProfileRequest : UpdateRequestBase
    {
        public OrderProfile Profile { get; set; }
    }
}
