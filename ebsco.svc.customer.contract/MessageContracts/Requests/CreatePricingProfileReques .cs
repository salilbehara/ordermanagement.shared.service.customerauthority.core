namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreatePricingProfileRequest : UpdateRequestBase
    {
        public PricingProfile Profile { get; set; }
    }
}
