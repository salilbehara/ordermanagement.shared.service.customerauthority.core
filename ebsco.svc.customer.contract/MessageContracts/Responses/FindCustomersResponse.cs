using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class FindCustomersResponse
    {
        public List<Customer> Customers { get; set; }
    }
}
