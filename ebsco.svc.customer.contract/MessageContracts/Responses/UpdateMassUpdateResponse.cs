using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    [DataContract]
    public class UpdateMassUpdateResponse
    {
        [DataMember]
        public MassUpdateRequest MassUpdateRequest { get; set; }
    }
}
