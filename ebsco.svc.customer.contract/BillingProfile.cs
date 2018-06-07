using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class BillingProfile : IValidatableObject

    {
        public int Id { get; set; }

        [ChangeHistory(Name = "Tax Exempt")]
        public bool? TaxExempt { get; set; }

        [ChangeHistory(Name = "GST Exempt")]
        public bool? GSTExempt { get; set; }

        [ChangeHistory(Name = "QST Exempt")]
        public bool? QSTExempt { get; set; }

        [ChangeHistory(Name = "Tax Exempt #")]
        [MaxLength(30, ErrorMessage = "Tax Exempt # cannot exceed 30 characters")]
        public string TaxExemptNumber { get; set; }

        [ChangeHistory(Name = "VAT #")]
        [MaxLength(19, ErrorMessage = "VAT # cannot exceed 19 characters")]
        public string VATNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //Tax Exempt  GST Exempt is null and QST Exempt is null   Value is null   Tax Exemption must be set.
            if (TaxExempt == null && QSTExempt == null && GSTExempt == null)
                results.Add(new ValidationResult("Tax Exemption must be set."));

            return results;
        }
    }
}
