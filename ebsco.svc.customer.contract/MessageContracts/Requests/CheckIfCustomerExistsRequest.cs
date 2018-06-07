using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    [DataContract]
    public class CheckIfCustomerExistsRequest
    {
        [DataMember]
        public string OfficeCode { get; set; }

        [DataMember]
        public int Account { get; set; }
    }
}
