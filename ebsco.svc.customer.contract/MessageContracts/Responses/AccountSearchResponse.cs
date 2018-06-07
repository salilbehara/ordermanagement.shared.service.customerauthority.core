using ebsco.svc.changehistory.contract.Messages.Response;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class AccountSearchResponse: BaseResponse
    {
        public IEnumerable<CustomerSearchResult> Customers { get; set; }
    }
}
