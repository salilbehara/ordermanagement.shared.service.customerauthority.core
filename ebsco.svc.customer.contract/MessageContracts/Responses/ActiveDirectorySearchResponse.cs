using ebsco.svc.changehistory.contract.Messages.Response;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{

    public class ActiveDirectorySearchResponse : BaseResponse
    {

        public List<EmployeeSearchResult> EmployeeSearchResults;
    }
}
