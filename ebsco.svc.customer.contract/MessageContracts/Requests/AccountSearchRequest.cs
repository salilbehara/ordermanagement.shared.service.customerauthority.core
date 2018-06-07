using ebsco.svc.changehistory.contract.Messages.Request;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class AccountSearchRequest : BaseRequest
    {
        public string CustomerName { get; set; }
        public string ExternalId { get; set; }
        public string LegacyIdentifier { get; set; }

        public string DDECustomerId { get; set; }
    }
}
