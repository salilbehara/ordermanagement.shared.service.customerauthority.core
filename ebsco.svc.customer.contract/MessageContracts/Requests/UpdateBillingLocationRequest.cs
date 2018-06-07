namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateBillingLocationRequest : UpdateRequestBase
    {
        public BillingLocation Location { get; set; }
    }
}
