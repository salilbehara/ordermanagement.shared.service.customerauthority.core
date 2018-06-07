namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteContactRequest : UpdateRequestBase
    {
        public int ContactId { get; set; }
    }
}
