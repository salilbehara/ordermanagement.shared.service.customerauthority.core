namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteOrderProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
