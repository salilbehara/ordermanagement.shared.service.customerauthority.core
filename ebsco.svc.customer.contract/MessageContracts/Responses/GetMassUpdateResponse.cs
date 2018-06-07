using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    [DataContract]
    public class GetMassUpdateResponse
    {
        [DataMember]
        public MassUpdateRequest MassUpdateRequest { get; set; }
    }
}
