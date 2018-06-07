namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateCCICodingProfileRequest : UpdateRequestBase
    {
        public CCICodingProfile Profile { get; set; }
    }
}
