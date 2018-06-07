namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateCreditsAndAdjustmentsProfileRequest : UpdateRequestBase
    {
        public CreditsAndAdjustmentsProfile Profile { get; set; }
    }
}
