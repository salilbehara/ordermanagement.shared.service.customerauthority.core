using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class UpdateMassUpdateRequest
    {
        [DataMember]
        public MassUpdateRequest MassUpdateRequest { get; set; }
    }
}
