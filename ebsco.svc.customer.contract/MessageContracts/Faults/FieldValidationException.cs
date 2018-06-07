using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Faults
{
    [DataContract]
    public class FieldValidationException
    {
        [DataMember]
        public string FieldName { get; set; }

        [DataMember]
        public string ValidationMessage { get; set; }
    }
}
