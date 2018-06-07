namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateCreditsAndAdjustmentsProfileRequest : UpdateRequestBase
    {
        public CreditsAndAdjustmentsProfile Profile { get; set; }
    }
}
