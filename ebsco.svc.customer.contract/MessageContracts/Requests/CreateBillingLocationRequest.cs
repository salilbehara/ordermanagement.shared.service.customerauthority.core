namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateBillingLocationRequest : UpdateRequestBase
    {
        public BillingLocation Location { get; set; }
    }
}
