namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateIlsProfileRequest : UpdateRequestBase
    {
        public IlsProfile Profile { get; set; }
    }
}
