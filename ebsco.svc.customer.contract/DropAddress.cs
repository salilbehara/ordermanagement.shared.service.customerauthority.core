using ebsco.svc.changehistory.contract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "AlternateAddress")]
    public class DropAddress : IValidatableObject
    {
        public int Id { get; set; }

        [ChangeHistory(Name = "DROP Attention")]
        [Required(ErrorMessage = "Drop Address Attention is required.")]
        [MaxLength(24, ErrorMessage = "Drop Address Attention length cannot exceed 24 characters")]
        public string Attention { get; set; }

        [ChangeHistory(Name = "DROP Addressee")]
        [MaxLength(24, ErrorMessage = "Drop Address Addressee length cannot exceed 24 characters")]
        public string Addressee { get; set; }

        [ChangeHistory(Name = "DROP Address")]
        [Required(ErrorMessage = "Drop Address is required.")]
        public string DropDisplayAddress { get; set; }

        public string CountryCode { get; set; }

        [ChangeHistory(Name = "DROP VAT Country Code")]
        [MaxLength(2, ErrorMessage = "VAT Country Code Override length cannot exceed 2 characters")]
        public string VATCountryCodeOverride { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
