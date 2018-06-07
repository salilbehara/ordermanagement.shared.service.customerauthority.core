namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateIlsProfileRequest : UpdateRequestBase
    {
        public IlsProfile Profile { get; set; }
    }
}
