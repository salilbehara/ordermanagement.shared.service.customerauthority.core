namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteIlsProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
