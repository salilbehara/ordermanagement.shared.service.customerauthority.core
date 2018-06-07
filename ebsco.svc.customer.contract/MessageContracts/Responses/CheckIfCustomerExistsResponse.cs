using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class CheckIfCustomerExistsResponse
    {
        [DataMember]
        public bool CustomerExists { get; set; }

    }
}
