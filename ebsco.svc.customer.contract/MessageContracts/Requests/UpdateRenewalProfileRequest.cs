namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateRenewalProfileRequest : UpdateRequestBase
    {
        public RenewalProfile Profile { get; set; }
    }
}
