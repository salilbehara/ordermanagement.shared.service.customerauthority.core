namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeletePricingProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
