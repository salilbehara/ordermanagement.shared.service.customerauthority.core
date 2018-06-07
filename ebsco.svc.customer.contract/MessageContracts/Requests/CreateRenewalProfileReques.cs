namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateRenewalProfileRequest : UpdateRequestBase
    {
        public RenewalProfile Profile { get; set; }
    }
}
