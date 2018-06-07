using System;

namespace ebsco.svc.customer.contract
{
    public class CustomerRepresentative
    {
        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int EmployeeRolesId { get; set; }
        public Employee Employee { get; set; }


        public EmployeeRole Role { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
