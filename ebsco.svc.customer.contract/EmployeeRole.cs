using ebsco.svc.changehistory.contract;
using System;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "Employee Role")]
    public class EmployeeRole
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //public bool IsDeleted { get; set; }
    }

}
