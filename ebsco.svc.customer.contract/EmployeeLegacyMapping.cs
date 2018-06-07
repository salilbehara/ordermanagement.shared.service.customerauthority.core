using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "Mainframe User ID")]
    public class EmployeeLegacyMapping : IValidatableObject
    {
        public int Id { get; set; }

        [ChangeHistory(Name = "Mainframe User ID")]
        public string MainframeUserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        //public bool IsDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }

    }
}
