using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract.MessageContracts.Faults
{
    [DataContract]
    public class ValidationFault
    {
        [DataMember]
        public IEnumerable<FieldValidationException> FieldExceptions { get; set; }

    }
}
