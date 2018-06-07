namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdatePricingProfileRequest : UpdateRequestBase
    {
        public PricingProfile Profile { get; set; }
    }
}
