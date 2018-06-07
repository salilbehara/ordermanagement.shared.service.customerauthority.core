using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class GetCustomerPricingInfoResponse
    {
        public List<CustomerPricingInfo> CustomerPricingInfos { get; set; }
    }
}