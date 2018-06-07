namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateSecondaryCustomerProfileRequest : UpdateRequestBase
    {
        public SecondaryCustomerProfile Profile { get; set; }
    }
}
