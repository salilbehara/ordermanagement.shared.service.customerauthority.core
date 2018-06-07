namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetSuffixIsDeletedRequest
    {
        public int CustomerId { get; set; }
        public string Suffix { get; set; }
    }
}
