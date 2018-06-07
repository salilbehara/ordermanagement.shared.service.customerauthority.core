using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "AlternateAddress")]
    public class JetsAddress : IValidatableObject
    {
        public int Id { get; set; }

        [ChangeHistory(Name = "JETS Attention")]
        [Required(ErrorMessage = "JETS Address Attention is required.")]
        [MaxLength(24, ErrorMessage = "JETS Address Attention length cannot exceed 24 characters.")]
        public string Attention { get; set; }

        [ChangeHistory(Name = "JETS Addressee")]
        [MaxLength(24, ErrorMessage = "JETS Address Addressee length cannot exceed 24 characters.")]
        public string Addressee { get; set; }

        [ChangeHistory(Name = "JETS Address")]
        [Required(ErrorMessage = "JETS Address is required.")]
        public string JetsDisplayAddress { get; set; }

        [ChangeHistory(Name = "JETS Service Charge Percent")]
        [Range(0, 99.999, ErrorMessage = "Jets Service Charge Percent must be between 0 and 99.999.")]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Jets Service Charge Percent is not valid")]
        public decimal? JetsServiceChargePercent { get; set; }

        [ChangeHistory(Name = "Deliver Orders To")]
        [Required(ErrorMessage = "Deliver Orders To is required for JETS Address.")]
        [MaxLength(2, ErrorMessage = "Deliver Orders To length cannot exceed 2 characters")]
        public string DeliverOrdersTo { get; set; }

        public string CountryCode { get; set; }

        [ChangeHistory(Name = "JETS VAT Country Code")]
        [MaxLength(2, ErrorMessage = "VAT Country Code Override length cannot exceed 2 characters")]
        public string VATCountryCodeOverride { get; set; }

        [ChangeHistory(Name = "JETS Service Charge Amount")]
        [Range(0, 99999.99)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for JETS Service Charge Amount cannot exceed 2 decimal places")]
        public decimal? JetsServiceChargeAmount { get; set; }

        [MaxLength(500)]
        [ChangeHistory(Name = "Jets Special Handling")]
        public string JetsSpecialHandling { get; set; }

        [ChangeHistory(Name = "Jets Start Date")]
        public DateTime? JetsStartDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            #region JETSServiceChargeAmount
            if ((JetsServiceChargeAmount.HasValue) && (JetsServiceChargePercent.HasValue))
                results.Add(new ValidationResult("JETS Service Charge Amount and Jets Service Charge Percent are mutually exclusive.", new[] { "JETSServiceChargeAmount" }));
            #endregion

            return results;

        }
    }
}
