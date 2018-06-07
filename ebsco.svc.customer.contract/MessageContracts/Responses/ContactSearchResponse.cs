using ebsco.svc.changehistory.contract.Messages.Response;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class ContactSearchResponse : BaseResponse
    {
        public IEnumerable<CustomerContactSearchResult> Contacts { get; set; }
    }
}
