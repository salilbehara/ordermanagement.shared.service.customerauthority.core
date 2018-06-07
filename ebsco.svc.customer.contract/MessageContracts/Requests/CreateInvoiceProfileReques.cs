namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateInvoiceProfileRequest : UpdateRequestBase
    {
        public InvoiceProfile Profile { get; set; }
    }
}
