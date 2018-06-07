namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateReportingProfileRequest : UpdateRequestBase
    {
        public ReportingProfile Profile { get; set; }
    }
}
