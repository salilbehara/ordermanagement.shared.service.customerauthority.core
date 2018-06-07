using ebsco.svc.changehistory.contract.Messages.Response;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class AddressSearchResponse : BaseResponse
    {
        public IEnumerable<CustomerAddressSearchResult> Customers { get; set; }
    }
}
