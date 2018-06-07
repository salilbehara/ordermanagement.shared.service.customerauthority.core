namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteCreditsAndAdjustmentsProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
