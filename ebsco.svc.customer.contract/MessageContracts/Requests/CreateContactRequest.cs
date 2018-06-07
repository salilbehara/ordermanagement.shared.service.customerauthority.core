namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateContactRequest: UpdateRequestBase
    {
        public Contact Contact { get; set; }
    }
}
