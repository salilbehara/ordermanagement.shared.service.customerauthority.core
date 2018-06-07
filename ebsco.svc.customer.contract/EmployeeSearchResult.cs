using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public class EmployeeSearchResults
    {
        public List<EmployeeSearchResult> Results;
        public int TotalRecords;
    }
    public class EmployeeSearchResult
    {
        public string SecurityId { get; set; }

        public string DisplayName { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Enabled { get; set; }
    }

}
