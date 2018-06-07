namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public abstract class UpdateRequestBase : RequestBase
    {
        public string ChangedBy { get; set; }
    }
}
