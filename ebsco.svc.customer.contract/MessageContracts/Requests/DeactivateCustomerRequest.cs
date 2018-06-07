namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeactivateCustomerRequest : UpdateRequestBase
    {
        public int CustomerID { get; set; }
    }
}
