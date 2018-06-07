namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteReportingProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
