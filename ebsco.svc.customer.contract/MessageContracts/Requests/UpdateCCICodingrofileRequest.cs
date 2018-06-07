namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateCCICodingProfileRequest : UpdateRequestBase
    {
        public CCICodingProfile Profile { get; set; }
    }
}
