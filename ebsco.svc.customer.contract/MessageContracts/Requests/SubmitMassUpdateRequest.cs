using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class SubmitMassUpdateRequest
    {
        [DataMember]
        public byte[] File { get; set; }

        public string RequestedBy { get; set; }

        public string RequestReason { get; set; }

        
    }
}
