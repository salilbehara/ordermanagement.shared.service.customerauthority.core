namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateInvoiceProfileRequest : UpdateRequestBase
    {
        public InvoiceProfile Profile { get; set; }
    }
}
