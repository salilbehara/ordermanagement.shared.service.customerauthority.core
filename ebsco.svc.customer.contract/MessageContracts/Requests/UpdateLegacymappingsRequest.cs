using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateLegacyMappingsRequest : UpdateRequestBase
    {
        public List<LegacyMapping> LegacyMappings { get; set; }
    }
}
