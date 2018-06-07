using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ebsco.svc.customer.contract
{
    [ExcludeFromCodeCoverage]
    public class UnassociatedIds
    {
        public List<int> ContactIds;
        public List<int> IpIds;

        public UnassociatedIds()
        {
            ContactIds = new List<int>();
            IpIds = new List<int>();
        }
    }
}
