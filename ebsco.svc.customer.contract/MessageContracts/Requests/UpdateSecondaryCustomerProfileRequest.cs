namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateSecondaryCustomerProfileRequest : UpdateRequestBase
    {
        public SecondaryCustomerProfile Profile { get; set; }
    }
}
