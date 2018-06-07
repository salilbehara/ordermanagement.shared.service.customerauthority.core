namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class ActivateCustomerRequest : UpdateRequestBase
    {
        public int CustomerID { get; set; }
    }
}
