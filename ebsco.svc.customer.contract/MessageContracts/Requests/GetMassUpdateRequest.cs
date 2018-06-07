using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class GetMassUpdateRequest
    {
        [DataMember]
        public int Id { get; set; }
    }
}
