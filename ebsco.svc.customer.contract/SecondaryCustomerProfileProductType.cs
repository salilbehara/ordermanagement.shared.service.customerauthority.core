using System;

namespace ebsco.svc.customer.contract
{
    public class SecondaryCustomerProfileProductType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
