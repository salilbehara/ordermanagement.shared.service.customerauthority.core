namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateOrderProfileRequest : UpdateRequestBase
    {
        public OrderProfile Profile { get; set; }
    }
}
