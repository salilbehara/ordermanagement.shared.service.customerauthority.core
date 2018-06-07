using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class ShippingProfile : IValidatableObject
    {
        [Flags]
        public enum RateClassEnum : int
        {
            Field = 1,
            Individual = 2,
            Institution = 4,
            Military = 8,
            RegularEducator = 16,
            RegularProfessional = 32,
            SpecialEducator = 64,
            SpecialProfessional = 128
        }

        public int Id { get; set; }

        [Required]
        [ChangeHistory(Name = "Customer Category")]
        public string CustomerCategory { get; set; }

        [MinLength(1,ErrorMessage = "Postage is required.")]
        [ChangeHistory(Name = "Postage")]
        public string Postage { get; set; }

        [MaxLength(15, ErrorMessage = "Special Name cannot exceed 15 characters.")]
        [ChangeHistory(Name = "Special Name")]
        public string SpecialName { get; set; }

        [MaxLength(15, ErrorMessage = "Special Department cannot exceed 15 characters.")]
        [ChangeHistory(Name = "Special Department")]
        public string SpecialDepartment { get; set; }

        [Required]
        [ChangeHistory(Name = "Autoprice Eligible")]
        public bool AutoPriceEligible { get; set; }

        [Required]
        [ChangeHistory(Name = "Delivery Method")]
        public string DeliveryMethod { get; set; }

        [Required]
        [ChangeHistory(Name = "Rate Code Preference 1")]
        public Int16 RateCodePreference1 { get; set; }

        [Required]
        [ChangeHistory(Name = "Rate Code Preference 2")]
        public Int16 RateCodePreference2 { get; set; }

        [Required]
        [ChangeHistory(Name = "Rate Code Preference 3")]
        public Int16 RateCodePreference3 { get; set; }

        [Required]
        [ChangeHistory(Name = "Rate Code Preference 4")]
        public Int16 RateCodePreference4 { get; set; }

        [ChangeHistory(Name = "Rate Class")]
        [Required]
        public RateClassEnum RateClass { get; set; }

        [ChangeHistory(Name = "Standard Format 1")]
        public string StandardFormat1 { get; set; }
        [ChangeHistory(Name = "Standard Format 2")]
        public string StandardFormat2 { get; set; }
        [ChangeHistory(Name = "Standard Format 3")]
        public string StandardFormat3 { get; set; }
        [ChangeHistory(Name = "Standard Format 4")]
        public string StandardFormat4 { get; set; }
        [ChangeHistory(Name = "Standard Format 5")]
        public string StandardFormat5 { get; set; }
        [ChangeHistory(Name = "Standard Format 6")]
        public string StandardFormat6 { get; set; }

        [ChangeHistory(Name = "Item Format 1")]
        public string ItemFormat1 { get; set; }
        [ChangeHistory(Name = "Item Format 2")]
        public string ItemFormat2 { get; set; }
        [ChangeHistory(Name = "Item Format 3")]
        public string ItemFormat3 { get; set; }
        [ChangeHistory(Name = "Item Format 4")]
        public string ItemFormat4 { get; set; }
        [ChangeHistory(Name = "Item Format 5")]
        public string ItemFormat5 { get; set; }
        [ChangeHistory(Name = "Item Format 6")]
        public string ItemFormat6 { get; set; }

        [ChangeHistory(Name = "Language")]
        public string Language { get; set; }
        
        [ChangeHistory(Name = "Email Address")]
        [MaxLength(60, ErrorMessage = "Email Address cannot exceed 60 characters.")]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Please enter a valid email address.  Multiple emails should be seperated by a semicolon ';'")]
        public string EmailAddress { get; set; }

        [ChangeHistory(Name = "VAT Country Code")]
        public string VATCountryCode { get; set; }

        [ChangeHistory(Name = "Tax Exempt")]
        public bool? TaxExempt { get; set; }

        [ChangeHistory(Name = "GST Exempt")]
        public bool? GSTExempt { get; set; }

        [ChangeHistory(Name = "QST Exempt")]
        public bool? QSTExempt { get; set; }

        [ChangeHistory(Name ="Tax Exempt #")]
        [MaxLength(30, ErrorMessage = "Tax Exempt # cannot exceed 30 characters")]
        public string TaxExemptNumber { get; set; }

        [ChangeHistory(Name = "VAT #")]
        [MaxLength(19, ErrorMessage = "VAT # cannot exceed 19 characters")]
        public string VATNumber { get; set; }

        [ChangeHistory(Name ="State Tax Override")]
        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for State Tax Override cannot exceed 3 decimal places")]
        public decimal? StateTaxOverride { get; set; }

        [ChangeHistory(Name ="County Tax Override")]
        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for County Tax Override cannot exceed 3 decimal places")]
        public decimal? CountyTaxOverride { get; set; }

        [ChangeHistory(Name ="City Tax Override")]
        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for City Tax Override cannot exceed 3 decimal places")]
        public decimal? CityTaxOverride { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //Any validations that can't be handled by attributes go here.

            if (RateCodePreference1 == 0 &&
                 RateCodePreference2 == 0 &&
                 RateCodePreference3 == 0 &&
                 RateCodePreference4 == 0)
                results.Add(new ValidationResult("At least one Rate Code Preference must be selected.",
                    new[] { "RateCodePreference1" }));
            else if 
               ((RateCodePreference1 == 0)
                &&
                (RateCodePreference2 != 10 &&
                 RateCodePreference3 != 10 &&
                 RateCodePreference4 != 10)
               )

                results.Add(new ValidationResult("Regular Rate Code Preference must be selected.",
                    new[] {"RateCodePreference1"}));
             else if (
                (RateCodePreference2 == 0)
                &&
                (RateCodePreference1 != 10 &&
                 RateCodePreference3 != 10 &&
                 RateCodePreference4 != 10)
            )
                results.Add(new ValidationResult("Regular Rate Code Preference must be selected.",
                    new[] {"RateCodePreference2"}));
            else if (
               (RateCodePreference3 == 0)
               &&
               (RateCodePreference1 != 10 &&
                RateCodePreference2 != 10 &&
                RateCodePreference4 != 10)
           )
                results.Add(new ValidationResult("Regular Rate Code Preference must be selected.",
                    new[] { "RateCodePreference3" }));
            else if (
              (RateCodePreference4 == 0)
              &&
              (RateCodePreference1 != 10 &&
               RateCodePreference2 != 10 &&
               RateCodePreference3 != 10)
          )
                results.Add(new ValidationResult("Regular Rate Code Preference must be selected.",
                    new[] { "RateCodePreference4" }));



            if (RateCodePreference1 != 0 &&
                (RateCodePreference1 == RateCodePreference2 ||
                 RateCodePreference1 == RateCodePreference3 ||
                 RateCodePreference1 == RateCodePreference4))
                results.Add(new ValidationResult("Rate Code Preference cannot be selected more than once.", new[] { "RateCodePreference1" }));

            if (RateCodePreference2 != 0 &&
                (RateCodePreference2 == RateCodePreference1 ||
                 RateCodePreference2 == RateCodePreference3 ||
                 RateCodePreference2 == RateCodePreference4))
                results.Add(new ValidationResult("Rate Code Preference cannot be selected more than once.", new[] { "RateCodePreference2" }));

            if (RateCodePreference3 != 0 &&
                (RateCodePreference3 == RateCodePreference1 ||
                 RateCodePreference3 == RateCodePreference2 ||
                 RateCodePreference3 == RateCodePreference4))
                results.Add(new ValidationResult("Rate Code Preference cannot be selected more than once.", new[] { "RateCodePreference3" }));

            if (RateCodePreference4 != 0 &&
                (RateCodePreference4 == RateCodePreference1 ||
                 RateCodePreference4 == RateCodePreference2 ||
                 RateCodePreference4 == RateCodePreference3))
                results.Add(new ValidationResult("Rate Code Preference cannot be selected more than once.", new[] { "RateCodePreference4" }));


            return results;
        }
    }
}
