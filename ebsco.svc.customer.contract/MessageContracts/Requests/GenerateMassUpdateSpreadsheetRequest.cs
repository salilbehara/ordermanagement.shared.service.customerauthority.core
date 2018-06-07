using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GenerateMassUpdateSpreadsheetRequest
    {
        public IEnumerable<string> PropertiesToInclude { get; set; }

        public string Query { get; set; }
    }
}
