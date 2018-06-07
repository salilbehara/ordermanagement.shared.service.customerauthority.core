using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class ClearSyncFailureRequest
    {
        [DataMember]
        public EntityTypeEnum EntityType { get; set; }

        [DataMember]
        public int EntityId { get; set; }
    }
}