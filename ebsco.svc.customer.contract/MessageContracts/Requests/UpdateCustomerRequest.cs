namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateCustomerRequest: UpdateRequestBase
    {
        public Customer Customer { get; set; }
    }
}
