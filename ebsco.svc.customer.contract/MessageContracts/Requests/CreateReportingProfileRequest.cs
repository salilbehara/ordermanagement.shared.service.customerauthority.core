namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateReportingProfileRequest : UpdateRequestBase
    {
        public ReportingProfile Profile { get; set; }
    }
}
