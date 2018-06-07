using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public class MassUpdateExportItem
    {
        public MassUpdateExportItem()
        {
            Properties = new List<KeyValuePair<string, object>>();
            Suffixes = new List<string>();
        }

        public int CustomerId { get; set; }

        public List<string> Suffixes { get; set; }

        public List<KeyValuePair<string, object>> Properties { get; set; }
    }
}
