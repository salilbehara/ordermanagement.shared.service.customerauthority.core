namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateContactRequest: UpdateRequestBase
    {
        public Contact Contact { get; set; }
    }
}
