using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetCustomerPricingInfoRequest
    {
        public List<CustomerAccountIdentifier> CustomerAccounts { get; set; }
    }
}