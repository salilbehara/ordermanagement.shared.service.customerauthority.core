namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteInvoiceProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
