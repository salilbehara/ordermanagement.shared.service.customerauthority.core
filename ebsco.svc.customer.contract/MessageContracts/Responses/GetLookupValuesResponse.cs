using ebsco.svc.customer.contract.LookupItems;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    [DataContract]
    public class GetLookupValuesResponse<T> where T : LookupItem
    {
        [DataMember]
        public IEnumerable<T> Items { get; set; }
    }
}
