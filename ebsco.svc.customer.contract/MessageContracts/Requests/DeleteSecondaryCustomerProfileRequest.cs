namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteSecondaryCustomerProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}
