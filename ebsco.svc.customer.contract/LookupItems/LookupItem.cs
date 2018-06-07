using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.LookupItems
{
    [DataContract]
    public abstract class LookupItem
    {
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
