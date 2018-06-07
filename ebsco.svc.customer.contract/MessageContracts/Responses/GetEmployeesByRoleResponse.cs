using System.Collections.Generic;

namespace ebsco.svc.customer.contract.MessageContracts.Responses
{
    public class GetEmployeesByRoleResponse
    {
        public List<Employee> CSRs { get; set; }
        public List<Employee> ASMs { get; set; }
        public List<Employee> REPs { get; set; }
        public List<Employee> ARs { get; set; }
        public List<Employee> ERs { get; set; }
    }
}
