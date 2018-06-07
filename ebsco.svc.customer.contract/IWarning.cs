using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public interface IWarning
    {
        List<string> Warning { get; set; }
        List<string> WarningValidation();
    }
}
