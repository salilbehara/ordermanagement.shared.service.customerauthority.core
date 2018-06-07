using ebsco.svc.changehistory.contract.Messages.Request;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class ActiveDirectorySearchRequest : BaseRequest
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }
    }
}
