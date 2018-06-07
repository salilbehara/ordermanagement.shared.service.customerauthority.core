using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public interface IHasLegacyMappings
    {
        List<LegacyMapping> LegacyMappings { get; set; }
    }
}