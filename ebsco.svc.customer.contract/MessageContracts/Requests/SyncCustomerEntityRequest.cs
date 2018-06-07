using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class SyncCustomerEntityRequest
    {
        [DataMember]
        public EntityTypeEnum EntityType { get; set; }

        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public DatabaseAction RequestedAction { get; set; }
    }
}