using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ebsco.svc.customer.contract
{
    public class PricingProfile : IValidatableObject, IHasLegacyMappings, IWarning
    {
        public PricingProfile()
        {
            LegacyMappings = new List<LegacyMapping>();
        }

        public int Id { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int CustomerId { get; set; }
        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }
        public string Description { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Service Charge Percent")]
        public decimal? ServiceChargePercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Original Invoice - Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Original Invoice - Service Charge Percent")]
        public decimal? OriginalInvoiceServiceChargePercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Supplemental Invoice - Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Supplemental Invoice - Service Charge Percent")]
        public decimal? SupplementalInvoiceServiceChargePercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Maximum Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Maximum Discount Percent")]
        public decimal? MaximumDiscountPercent { get; set; }

        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Discount Percent")]
        public decimal? DiscountPercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Minimum Profit Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Minimum Profit Percent")]
        public decimal? MinimumProfitPercent { get; set; }
        [ChangeHistory(Name = "Service Charge Discount Type")]
        public string ServiceChargeDiscountType { get; set; }
        [ChangeHistory(Name = "VLIP Indicator")]
        public string VLIPIndicator { get; set; }

        [Range(0, 99)]
        [ChangeHistory(Name = "VLIP Table Number")]
        public int? VLIPTableNumber { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Original Invoice - Maximum Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Original Invoice - Maximum Discount Percent")]
        public decimal? OriginalInvoiceMaximumDiscountPercent { get; set; }

        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Original Invoice - Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Original Invoice - Discount Percent")]
        public decimal? OriginalInvoiceDiscountPercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Original Invoice - Minimum Profit Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Original Invoice - Minimum Profit Percent")]
        public decimal? OriginalInvoiceMinimumProfitPercent { get; set; }
        [ChangeHistory(Name = "Original Invoice - Service Charge Discount Type")]
        public string OriginalInvoiceServiceChargeDiscountType { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Supplemental Invoice - Maximum Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Supplemental Invoice - Maximum Discount Percent")]
        public decimal? SupplementalInvoiceMaximumDiscountPercent { get; set; }

        [Range(0, 99.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Supplemental Invoice - Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Supplemental Invoice - Discount Percent")]
        public decimal? SupplementalInvoiceDiscountPercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Supplemental Invoice - Minimum Profit Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Supplemental Invoice - Minimum Profit Percent")]
        public decimal? SupplementalInvoiceMinimumProfitPercent { get; set; }
        [ChangeHistory(Name = "Supplemental Invoice - Service Charge Discount Type")]
        public string SupplementalInvoiceServiceChargeDiscountType { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Maximum Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Maximum Service Charge Percent")]
        public decimal? MaximumServiceChargePercent { get; set; }

        [Range(0, 9999999.99)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Maximum Adjusting Amount cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Maximum Adjusting Amount")]
        public decimal? MaximumAdjustingAmount { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Guaranteed Rate Program Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Guaranteed Rate Program Percent")]
        public decimal? GuaranteedRateProgramPercent { get; set; }
        [ChangeHistory(Name = "Guaranteed Rate Program Type")]
        public string GuaranteedRateProgramType { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Reserve Rate cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Reserve Rate")]
        public decimal? ReserveRate { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Net Out Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Net Out Percent")]
        public decimal? NetOutPercent { get; set; }
        [ChangeHistory(Name = "Pricing Method")]
        public string PricingMethod { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Domestic Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Domestic Service Charge Percent")]
        public decimal? DomesticServiceChargePercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Domestic Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Domestic Discount Percent")]
        public decimal? DomesticDiscountPercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Non-Domestic Service Charge Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Non-Domestic Service Charge Percent")]
        public decimal? NonDomesticServiceChargePercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Non-Domestic Discount Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Non-Domestic Discount Percent")]
        public decimal? NonDomesticDiscountPercent { get; set; }
        [ChangeHistory(Name = "Include Proforma in Net Title Markup")]
        public bool IncludeProformaInNetTitleMarkup { get; set; }
        [ChangeHistory(Name = "Include account in Net Title Markup")]
        public bool IncludeAccountInNetTitleMarkup { get; set; }
        [ChangeHistory(Name = "Add Net Title Markup to Renewal List")]
        public bool AddNetTitleMarkupToRenewalList { get; set; }

        [Range(0, 9999999.99)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Net Title Markup Override cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Net Title Markup Override")]
        public decimal? NetTitleMarkupOverride { get; set; }

        [MaxLength(250)]
        [ChangeHistory(Name = "Net Title Markup Override Comments")]
        public string NetTitleMarkupOverrideComments { get; set; }

        [Range(0, 9999999.99)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Low Title Markup Override cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Low Title Markup override")]
        public decimal? LowTitleMarkupOverride { get; set; }

        [MaxLength(250)]
        [ChangeHistory(Name = "Low Title Markup override comments")]
        public string LowTitleMarkupOverrideComments { get; set; }
        [ChangeHistory(Name = "Include Price Add-On (ERM)")]
        public bool IncludePriceAddOnERM { get; set; }
        [ChangeHistory(Name = "Apply VLIP Pricing if Customer and Publisher in same Country")]
        public bool ApplyVLIPPricingIfCustomerAndPublisherInSameCountry { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Domestic ERM Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Domestic ERM Percent")]
        public decimal? DomesticERMPercent { get; set; }

        [Range(0, 999.999)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Decimal value precision for Foreign ERM Percent cannot exceed 3 decimal places")]
        [ChangeHistory(Name = "Foreign ERM Percent")]   
        public decimal? ForeignERMPercent { get; set; }

        [ChangeHistory(Name = "Apply ERM to Bill Later and Standing Orders")]
        public bool ApplyERMToBillLaterAndStandingOrders { get; set; }

        [ChangeHistory(Name = "Preprice if Standing Order or Bill Later")]
        public bool PrepriceIfStandingOrderOrBillLater { get; set; }

        [MaxLength(300)]
        [ChangeHistory(Name = "Pricing Special Handling")]
        public string PricingSpecialHandling { get; set; }
        
        public List<string> Warning { get; set; }

        [ChangeHistory(Name = "Display Service Charge in EBSCONET Pricing")]
        public bool DisplayServiceChargeInEbsconetPricing { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            IRepository repository = null;
            IValidationRepository validationRepository = null;
            IFeatureConfiguration featureConfig = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                    validationRepository = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                    featureConfig = ServiceLocator.Current.GetInstance(typeof(IFeatureConfiguration)) as IFeatureConfiguration;
                }
                catch (ActivationException)
                {
                    //do nothing
                }


            IEnumerable<SecondaryCustomerProfile> secondaryProfiles = null;
            if (repository != null)
            {
                var suffixLegacyMappingIds = LegacyMappings.Where(scplm => scplm.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.Id);

                secondaryProfiles = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.SecondaryCustomerProfiles)
                    .SecondaryCustomerProfiles
                    .Where(pp => pp.LegacyMappings.Any(pplm => suffixLegacyMappingIds.Contains(pplm.Id)));
            }

            #region DiscountPercent
            if (DiscountPercent.HasValue)
            {
                switch (ServiceChargeDiscountType)
                {
                    case "D":
                        if (DiscountPercent.Value == 0)
                            results.Add(new ValidationResult("Discount Charge percent is not valid for selected Service Charge Discount Type.", new[] { "DiscountPercent" }));
                        break;
                    case "H":
                        if (DiscountPercent.Value > 0)
                            results.Add(new ValidationResult("Discount Charge percent is not valid for selected Service Charge Discount Type.", new[] { "DiscountPercent" }));
                        break;
                    case "K":
                        if (DiscountPercent.Value == 0 && ServiceChargePercent == 0)
                            results.Add(new ValidationResult("Discount Charge percent is not valid for selected Service Charge Discount Type.", new[] { "DiscountPercent" }));
                        break;
                    default:
                        if (DiscountPercent > 0 && (ServiceChargePercent ?? 0) > 0)
                            results.Add(new ValidationResult("Discount Percent and Service Charge Percent are mutually exclusive.", new[] { "DiscountPercent" }));
                        if (DiscountPercent > 0 &&
                            ((MinimumProfitPercent ?? 0) > 0 ||
                            (MaximumDiscountPercent ?? 0) > 0 ||
                            (MaximumServiceChargePercent ?? 0) > 0))
                            results.Add(new ValidationResult("Discount Percent is not valid.", new[] { "DiscountPercent" }));

                        break;
                }
            }
            #endregion

            #region OriginalInvoiceDiscountPercent
            if (OriginalInvoiceDiscountPercent.HasValue)
            {
                switch (OriginalInvoiceServiceChargeDiscountType)
                {
                    case "D":
                        if (OriginalInvoiceDiscountPercent.Value == 0)
                            results.Add(new ValidationResult("Original Invoice - Discount Charge percent is not valid for selected Original Invoice - Service Charge Discount Type.", new[] { "OriginalInvoiceDiscountPercent" }));
                        break;
                    case "H":
                        if (OriginalInvoiceDiscountPercent.Value > 0)
                            results.Add(new ValidationResult("Original Invoice - Discount Charge percent is not valid for selected Original Invoice - Service Charge Discount Type.", new[] { "OriginalInvoiceDiscountPercent" }));
                        break;
                    case "K":
                        if (OriginalInvoiceDiscountPercent.Value == 0 && OriginalInvoiceServiceChargePercent == 0)
                            results.Add(new ValidationResult("Original Invoice - Discount Charge percent is not valid for selected Original Invoice - Service Charge Discount Type.", new[] { "OriginalInvoiceDiscountPercent" }));
                        break;
                    default:
                        if (OriginalInvoiceDiscountPercent > 0 && (OriginalInvoiceServiceChargePercent ?? 0) > 0)
                            results.Add(new ValidationResult("Original Invoice - Discount Percent and Original Invoice - Service Charge Percent are mutually exclusive.", new[] { "OriginalInvoiceDiscountPercent" }));

                        if (OriginalInvoiceDiscountPercent > 0 &&
                            ((OriginalInvoiceMinimumProfitPercent ?? 0) > 0 ||
                            (OriginalInvoiceMaximumDiscountPercent ?? 0) > 0))
                            results.Add(new ValidationResult("Original Invoice - Discount Percent is not valid.", new[] { "OriginalInvoiceDiscountPercent" }));

                        break;
                }
            }
            #endregion

            #region SupplementalInvoiceDiscountPercent
            if (SupplementalInvoiceDiscountPercent.HasValue)
            {
                switch (SupplementalInvoiceServiceChargeDiscountType)
                {
                    case "D":
                        if (SupplementalInvoiceDiscountPercent.Value == 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Charge percent is not valid for selected Supplemental Invoice - Service Charge Discount Type.", new[] { "SupplementalInvoiceDiscountPercent" }));
                        break;
                    case "H":
                        if (SupplementalInvoiceDiscountPercent.Value > 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Charge percent is not valid for selected Supplemental Invoice - Service Charge Discount Type.", new[] { "SupplementalInvoiceDiscountPercent" }));
                        break;
                    case "K":
                        if (SupplementalInvoiceDiscountPercent.Value == 0 && SupplementalInvoiceServiceChargePercent == 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Charge percent is not valid for selected Supplemental Invoice - Service Charge Discount Type.", new[] { "SupplementalInvoiceDiscountPercent" }));
                        break;
                    default:
                        if (SupplementalInvoiceDiscountPercent > 0 && (SupplementalInvoiceServiceChargePercent ?? 0) > 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Percent and Supplemental Invoice - Service Charge Percent are mutually exclusive.", new[] { "SupplementalInvoiceDiscountPercent" }));

                        if (SupplementalInvoiceDiscountPercent > 0 &&
                            ((SupplementalInvoiceMinimumProfitPercent ?? 0) > 0 ||
                            (SupplementalInvoiceMaximumDiscountPercent ?? 0) > 0))
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Percent is not valid.", new[] { "SupplementalInvoiceDiscountPercent" }));

                        break;
                }
            }
            #endregion


            #region LowTitleMarkupOverrideComments
            if (!string.IsNullOrWhiteSpace(LowTitleMarkupOverrideComments) && (LowTitleMarkupOverride ?? 0) == 0)
                results.Add(new ValidationResult("Cannot enter comments if Low Title Markup Override Amount is blank.", new[] { "LowTitleMarkupOverrideComments" }));
            #endregion

            #region NetTitleMarkupOverrideComments
            if (!string.IsNullOrWhiteSpace(NetTitleMarkupOverrideComments) && (NetTitleMarkupOverride ?? 0) == 0)
                results.Add(new ValidationResult("Cannot enter comments if Net Title Markup Override Amount is blank.", new[] { "NetTitleMarkupOverrideComments" }));
            #endregion

            var legacyOfficeCodes = LegacyMappings.Where(x => x.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.LegacyIdentifier.Substring(0, 2).ToUpper());


            #region PricingMethod
            if (string.IsNullOrWhiteSpace(PricingMethod) &&
                ((DomesticDiscountPercent ?? 0) > 0 ||
                (DomesticServiceChargePercent ?? 0) > 0 ||
                (NonDomesticDiscountPercent ?? 0) > 0 ||
                (NonDomesticServiceChargePercent ?? 0) > 0
                ))
                results.Add(new ValidationResult("Pricing Method must be specified.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && legacyOfficeCodes.Any(oc => oc != "ZV"))
                results.Add(new ValidationResult("Pricing Method cannot be selected for this Office Code.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && ((DiscountPercent ?? 0) > 0 || (ServiceChargePercent ?? 0) > 0))
                results.Add(new ValidationResult("Pricing Method cannot be selected if there is a Service Charge or Discount.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && DomesticServiceChargePercent == null)
                results.Add(new ValidationResult("Domestic Service Charge Percent is not valid.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && DomesticDiscountPercent == null)
                results.Add(new ValidationResult("Domestic Discount Percent is not valid.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && NonDomesticServiceChargePercent == null)
                results.Add(new ValidationResult("Non-Domestic Service Charge Percent is not valid.", new[] { "PricingMethod" }));

            if (!string.IsNullOrWhiteSpace(PricingMethod) && NonDomesticDiscountPercent == null)
                results.Add(new ValidationResult("Non-Domestic Discount Percent is not valid.", new[] { "PricingMethod" }));
            #endregion

            #region MaximumAdjustingAmount
            if (MaximumAdjustingAmount.HasValue)
            {
                if (MaximumAdjustingAmount > 0 && !string.IsNullOrWhiteSpace(VLIPIndicator))
                    results.Add(new ValidationResult("Maximum Adjusting Amount is not valid with selected VLIP Indicator.", new[] { "MaximumAdjustingAmount" }));

                if (MaximumAdjustingAmount > 0 &&
                            ((MinimumProfitPercent ?? 0) > 0 ||
                            (MaximumDiscountPercent ?? 0) > 0 ||
                            (MaximumServiceChargePercent ?? 0) > 0))
                    results.Add(new ValidationResult("Maximum Adjusting Amount is not valid.", new[] { "MaximumAdjustingAmount" }));

                if (MaximumAdjustingAmount > 9999.99m && legacyOfficeCodes.Any(x => x.StartsWith("Z")))
                    results.Add(new ValidationResult("Maximum Adjusting Amount is not valid with selected office code.", new[] { "MaximumAdjustingAmount" }));

                if (MaximumAdjustingAmount > 999.99m && string.IsNullOrWhiteSpace(ServiceChargeDiscountType))
                    results.Add(new ValidationResult("Maximum Adjusting Amount is not valid.", new[] { "MaximumAdjustingAmount" }));

                if (MaximumAdjustingAmount > 99.99m &&
                    legacyOfficeCodes.Any(x => x.StartsWith("Z")) &&
                    ServiceChargeDiscountType != null &&
                    new[] { "H", "D" }.Contains(ServiceChargeDiscountType))
                    results.Add(new ValidationResult("Maximum Adjusting Amount is not valid with selected office code.", new[] { "MaximumAdjustingAmount" }));

                //validate against customer class on secondary profiles
                if (MaximumAdjustingAmount > 99.99m && legacyOfficeCodes.Contains("TO"))
                {
                    if (secondaryProfiles != null)
                    {
                        if (secondaryProfiles.Any(x => x.CustomerClass == "M"))
                            results.Add(new ValidationResult("Maximum Adjusting Amount is not valid with selected office code.", new[] { "MaximumAdjustingAmount" }));
                    }
                }
            }
            #endregion

            #region MaximumDiscountPercent
            if (MaximumDiscountPercent.HasValue)
            {
                if (MaximumDiscountPercent > 0)
                {
                    if (!string.IsNullOrWhiteSpace(VLIPIndicator))
                        results.Add(new ValidationResult("Maximum Discount Percent is not valid with selected VLIP Indicator.", new[] { "MaximumDiscountPercent" }));

                    if (ServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(ServiceChargeDiscountType))
                        results.Add(new ValidationResult("Maximum Discount Percent is not valid.", new[] { "MaximumDiscountPercent" }));

                    if ((MaximumAdjustingAmount ?? 0) > 0)
                        results.Add(new ValidationResult("Maximum Discount Percent is not valid.", new[] { "MaximumDiscountPercent" }));
                }
                else if (MaximumDiscountPercent == 0)
                    if ((ServiceChargeDiscountType ?? string.Empty) == "L")
                        results.Add(new ValidationResult("Maximum Discount Percent is not valid.", new[] { "MaximumDiscountPercent" }));
            }
            #endregion

            #region OriginalInvoiceMaximumDiscountPercent
            if (OriginalInvoiceMaximumDiscountPercent.HasValue)
            {
                if (OriginalInvoiceMaximumDiscountPercent > 0)
                {
                    if (OriginalInvoiceServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(OriginalInvoiceServiceChargeDiscountType))
                        results.Add(new ValidationResult("Original Invoice - Maximum Discount Percent is not valid.", new[] { "OriginalInvoiceMaximumDiscountPercent" }));

                    if ((OriginalInvoiceMinimumProfitPercent ?? 0) == 0)
                        results.Add(new ValidationResult("Original Invoice - Maximum Discount Percent is not valid.", new[] { "OriginalInvoiceMaximumDiscountPercent" }));
                }
                else if (OriginalInvoiceMaximumDiscountPercent == 0)
                    if ((OriginalInvoiceMinimumProfitPercent ?? 0) > 0)
                        results.Add(new ValidationResult("Original Invoice - Maximum Discount Percent is not valid.", new[] { "OriginalInvoiceMaximumDiscountPercent" }));
            }
            #endregion

            #region SupplementalInvoiceMaximumDiscountPercent
            if (SupplementalInvoiceMaximumDiscountPercent.HasValue)
            {
                if (SupplementalInvoiceMaximumDiscountPercent > 0)
                {
                    if (SupplementalInvoiceServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(SupplementalInvoiceServiceChargeDiscountType))
                        results.Add(new ValidationResult("Supplemental Invoice - Maximum Discount Percent is not valid.", new[] { "SupplementalInvoiceMaximumDiscountPercent" }));

                    if ((SupplementalInvoiceMinimumProfitPercent ?? 0) == 0)
                        results.Add(new ValidationResult("Supplemental Invoice - Maximum Discount Percent is not valid.", new[] { "SupplementalInvoiceMaximumDiscountPercent" }));
                }
                else if (SupplementalInvoiceMaximumDiscountPercent == 0)
                    if ((SupplementalInvoiceMinimumProfitPercent ?? 0) > 0)
                        results.Add(new ValidationResult("Supplemental Invoice - Maximum Discount Percent is not valid.", new[] { "SupplementalInvoiceMaximumDiscountPercent" }));
            }
            #endregion

            #region MaximumServiceChargePercent
            if (MaximumServiceChargePercent.HasValue)
            {
                if (MaximumServiceChargePercent > 0)
                {
                    if (!string.IsNullOrWhiteSpace(VLIPIndicator))
                        results.Add(new ValidationResult("Maximum Service Charge Percent is not valid with selected VLIP Indicator.", new[] { "MaximumServiceChargePercent" }));

                    if (ServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(ServiceChargeDiscountType))
                        results.Add(new ValidationResult("Maximum Service Charge Percent is not valid.", new[] { "MaximumServiceChargePercent" }));

                    if ((MaximumAdjustingAmount ?? 0) > 0)
                        results.Add(new ValidationResult("Maximum Service Charge Percent is not valid.", new[] { "MaximumServiceChargePercent" }));
                }
            }
            #endregion

            #region MinimumProfitPercent
            if (MinimumProfitPercent.HasValue)
            {
                if (MinimumProfitPercent > 0)
                {
                    if (!string.IsNullOrWhiteSpace(VLIPIndicator))
                        results.Add(new ValidationResult("Minimum Profit Percent is not valid.", new[] { "MinimumProfitPercent" }));

                    if (ServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(ServiceChargeDiscountType))
                        results.Add(new ValidationResult("Minimum Profit Percent is not valid.", new[] { "MinimumProfitPercent" }));

                    if ((MaximumAdjustingAmount ?? 0) > 0)
                        results.Add(new ValidationResult("Minimum Profit Percent is not valid.", new[] { "MinimumProfitPercent" }));
                }
                else if (MinimumProfitPercent == 0)
                {
                    if ((ServiceChargeDiscountType ?? string.Empty) == "L")
                        results.Add(new ValidationResult("Minimum Profit Percent is not valid.", new[] { "MinimumProfitPercent" }));

                    if ((MaximumDiscountPercent ?? 0) > 0 || (MaximumServiceChargePercent ?? 0) > 0)
                        results.Add(new ValidationResult("Minimum Profit Percent is not valid.", new[] { "MinimumProfitPercent" }));
                }
            }
            #endregion

            #region OriginalInvoiceMinimumProfitPercent
            if (OriginalInvoiceMinimumProfitPercent.HasValue)
            {
                if (OriginalInvoiceMinimumProfitPercent > 0)
                {
                    if (OriginalInvoiceServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(OriginalInvoiceServiceChargeDiscountType))
                        results.Add(new ValidationResult("Original Invoice - Minimum Profit Percent is not valid.", new[] { "OriginalInvoiceMinimumProfitPercent" }));

                    if (VLIPIndicator != null && new[] { "Y", "A", "Z", "E", "U", "P" }.Contains(VLIPIndicator))
                        results.Add(new ValidationResult("Original Invoice - Minimum Profit Percent is not valid.", new[] { "OriginalInvoiceMinimumProfitPercent" }));

                    if ((OriginalInvoiceMaximumDiscountPercent ?? 0) == 0)
                        results.Add(new ValidationResult("Original Invoice - Minimum Profit Percent is not valid.", new[] { "OriginalInvoiceMinimumProfitPercent" }));
                }
                else if (OriginalInvoiceMinimumProfitPercent == 0)
                    if ((OriginalInvoiceMaximumDiscountPercent ?? 0) > 0)
                        results.Add(new ValidationResult("Original Invoice - Minimum Profit Percent is not valid.", new[] { "OriginalInvoiceMinimumProfitPercent" }));
            }
            #endregion

            #region SupplementalInvoiceMinimumProfitPercent
            if (SupplementalInvoiceMinimumProfitPercent.HasValue)
            {
                if (SupplementalInvoiceMinimumProfitPercent > 0)
                {
                    if (SupplementalInvoiceServiceChargeDiscountType != null && new[] { "D", "H", "K" }.Contains(SupplementalInvoiceServiceChargeDiscountType))
                        results.Add(new ValidationResult("Supplemental Invoice - Minimum Profit Percent is not valid.", new[] { "SupplementalInvoiceMinimumProfitPercent" }));

                    if (VLIPIndicator != null && new[] { "Y", "A", "Z", "E", "U", "P" }.Contains(VLIPIndicator))
                        results.Add(new ValidationResult("Supplemental Invoice - Minimum Profit Percent is not valid.", new[] { "SupplementalInvoiceMinimumProfitPercent" }));

                    if ((SupplementalInvoiceMaximumDiscountPercent ?? 0) == 0)
                        results.Add(new ValidationResult("Supplemental Invoice - Minimum Profit Percent is not valid.", new[] { "SupplementalInvoiceMinimumProfitPercent" }));
                }
                else if (SupplementalInvoiceMinimumProfitPercent == 0)
                    if ((SupplementalInvoiceMaximumDiscountPercent ?? 0) > 0)
                        results.Add(new ValidationResult("Supplemental Invoice - Minimum Profit Percent is not valid.", new[] { "SupplementalInvoiceMinimumProfitPercent" }));
            }
            #endregion

            #region ServiceChargeDiscountType
            if (!string.IsNullOrWhiteSpace(ServiceChargeDiscountType))
            {
                if (VLIPIndicator != null)
                {
                    if (VLIPIndicator == "S" && !new[] { "H", "D" }.Contains(ServiceChargeDiscountType))
                        results.Add(new ValidationResult("Service Charge Discount Type is not valid.", new[] { "ServiceChargeDiscountType" }));
                    if (new[] { "A", "E", "P", "U", "Z" }.Contains(VLIPIndicator) && !new[] { "H", "D", "" }.Contains(ServiceChargeDiscountType))
                        results.Add(new ValidationResult("Service Charge Discount Type is not valid.", new[] { "ServiceChargeDiscountType" }));
                }

                if ((string.IsNullOrWhiteSpace(VLIPIndicator) || (VLIPTableNumber ?? 0) == 0) && ((GuaranteedRateProgramPercent ?? 0) > 0) && !new[] { "H", "D" }.Contains(ServiceChargeDiscountType))
                    results.Add(new ValidationResult("Service Charge Discount Type is not valid.", new[] { "ServiceChargeDiscountType" }));

                if (new[] { "B", "C" }.Contains(ServiceChargeDiscountType) && !legacyOfficeCodes.All(x => x == "AU"))
                    results.Add(new ValidationResult("Service Charge Discount Type is not valid for selected office code.", new[] { "ServiceChargeDiscountType" }));

                if (new[] { "S", "K" }.Contains(ServiceChargeDiscountType) && !legacyOfficeCodes.All(x => x.StartsWith("Z")) && (MaximumAdjustingAmount ?? 0) > 0)
                    results.Add(new ValidationResult("Service Charge Discount Type is not valid for selected office code.", new[] { "ServiceChargeDiscountType" }));
            }

            #endregion

            #region OriginalInvoiceServiceChargeDiscountType
            if (!string.IsNullOrWhiteSpace(OriginalInvoiceServiceChargeDiscountType))
            {

                if (new[] { "B", "C" }.Contains(OriginalInvoiceServiceChargeDiscountType) && !legacyOfficeCodes.All(x => x == "AU"))
                    results.Add(new ValidationResult("Original Invoice - Service Charge Discount Type is not valid for selected office code.", new[] { "OriginalInvoiceServiceChargeDiscountType" }));
            }
            #endregion

            #region SupplementalInvoiceServiceChargeDiscountType
            if (!string.IsNullOrWhiteSpace(SupplementalInvoiceServiceChargeDiscountType))
            {
                if (new[] { "B", "C" }.Contains(SupplementalInvoiceServiceChargeDiscountType) && !legacyOfficeCodes.All(x => x == "AU"))
                    results.Add(new ValidationResult("Supplemental Invoice - Service Charge Discount Type is not valid for selected office code.", new[] { "SupplementalInvoiceServiceChargeDiscountType" }));
            }
            #endregion

            #region NetOutPercent
            if (NetOutPercent.HasValue)
            {
                if (NetOutPercent > 0)
                {
                    if (!string.IsNullOrWhiteSpace(VLIPIndicator))
                        results.Add(new ValidationResult("Net Out Percent is not valid.", new[] { "NetOutPercent" }));
                }
            }
            #endregion


            #region GuaranteedRateProgramPercent
            if ((GuaranteedRateProgramPercent ?? 0) > 0 && (ReserveRate ?? 0) > 0)
                results.Add(new ValidationResult("Guaranteed Rate Program Percent and Reserve Rate are mutually exclusive.", new[] { "GuaranteedRateProgramPercent" }));
            if (((GuaranteedRateProgramPercent ?? 0) == 0) && new[] { "H", "D" }.Contains(GuaranteedRateProgramType))
                results.Add(new ValidationResult("Guaranteed Rate Program Percent is required if Type is selected.", new[] { "GuaranteedRateProgramType" }));
            #endregion

            #region GuaranteedRateProgramType
            if (((GuaranteedRateProgramPercent ?? 0) > 0) && !new[] { "H", "D" }.Contains(GuaranteedRateProgramType))
                results.Add(new ValidationResult("Guaranteed Rate Program Type is not valid.", new[] { "GuaranteedRateProgramType" }));
            #endregion

            #region ReserveRate
            if ((ReserveRate ?? 0) > 0 && (GuaranteedRateProgramPercent ?? 0) > 0)
                results.Add(new ValidationResult("Guaranteed Rate Program Percent and Reserve Rate are mutually exclusive.", new[] { "ReserveRate" }));
            #endregion

            #region ServiceChargePercent
            if (ServiceChargePercent.HasValue)
            {
                switch (ServiceChargeDiscountType)
                {
                    case "D":
                        if (ServiceChargePercent.Value > 0)
                            results.Add(new ValidationResult("Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "ServiceChargePercent" }));
                        break;
                    case "H":
                        if (ServiceChargePercent.Value == 0)
                            results.Add(new ValidationResult("Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "ServiceChargePercent" }));
                        break;
                    case "K":
                        if ((DiscountPercent ?? 0) == 0)
                            results.Add(new ValidationResult("Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "ServiceChargePercent" }));
                        break;
                    default:
                        if (ServiceChargePercent > 0 && (DiscountPercent ?? 0) > 0)
                            results.Add(new ValidationResult("Discount Percent and Service Charge Percent are mutually exclusive.", new[] { "ServiceChargePercent" }));
                        if (ServiceChargePercent > 0 &&
                            ((MinimumProfitPercent ?? 0) > 0 ||
                            (MaximumDiscountPercent ?? 0) > 0 ||
                            (MaximumServiceChargePercent ?? 0) > 0))
                            results.Add(new ValidationResult("Service Charge Percent is not valid.", new[] { "ServiceChargePercent" }));
                        break;
                }
            }
            #endregion

            #region OriginalInvoiceServiceChargePercent
            if (OriginalInvoiceServiceChargePercent.HasValue)
            {
                switch (OriginalInvoiceServiceChargeDiscountType)
                {
                    case "D":
                        if (OriginalInvoiceServiceChargePercent.Value > 0)
                            results.Add(new ValidationResult("Original Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "OriginalInvoiceServiceChargePercent" }));
                        break;
                    case "H":
                        if (OriginalInvoiceServiceChargePercent.Value == 0)
                            results.Add(new ValidationResult("Original Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "OriginalInvoiceServiceChargePercent" }));
                        break;
                    case "K":
                        if ((OriginalInvoiceDiscountPercent ?? 0) == 0)
                            results.Add(new ValidationResult("Original Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "OriginalInvoiceServiceChargePercent" }));
                        break;
                    default:
                        if (OriginalInvoiceServiceChargePercent > 0 && (OriginalInvoiceDiscountPercent ?? 0) > 0)
                            results.Add(new ValidationResult("Original Invoice - Discount Percent and Original Invoice - Service Charge Percent are mutually exclusive.", new[] { "OriginalInvoiceServiceChargePercent" }));
                        if (OriginalInvoiceServiceChargePercent > 0 &&
                            (OriginalInvoiceMinimumProfitPercent ?? 0) > 0 ||
                            (OriginalInvoiceMaximumDiscountPercent ?? 0) > 0)
                            results.Add(new ValidationResult("Original Invoice - Service Charge Percent is not valid.", new[] { "OriginalInvoiceServiceChargePercent" }));
                        break;
                }
            }
            #endregion

            #region SupplementalInvoiceServiceChargePercent
            if (SupplementalInvoiceServiceChargePercent.HasValue)
            {
                switch (SupplementalInvoiceServiceChargeDiscountType)
                {
                    case "D":
                        if (SupplementalInvoiceServiceChargePercent.Value > 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "SupplementalInvoiceServiceChargePercent" }));
                        break;
                    case "H":
                        if (SupplementalInvoiceServiceChargePercent.Value == 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "SupplementalInvoiceServiceChargePercent" }));
                        break;
                    case "K":
                        if ((SupplementalInvoiceDiscountPercent ?? 0) == 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Service Charge percent is not valid for selected Service Charge Discount Type.", new[] { "SupplementalInvoiceServiceChargePercent" }));
                        break;
                    default:
                        if (SupplementalInvoiceServiceChargePercent > 0 && (SupplementalInvoiceDiscountPercent ?? 0) > 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Discount Percent and Supplemental Invoice - Service Charge Percent are mutually exclusive.", new[] { "SupplementalInvoiceServiceChargePercent" }));
                        if (SupplementalInvoiceServiceChargePercent > 0 &&
                            (SupplementalInvoiceMinimumProfitPercent ?? 0) > 0 ||
                            (SupplementalInvoiceMaximumDiscountPercent ?? 0) > 0)
                            results.Add(new ValidationResult("Supplemental Invoice - Service Charge Percent is not valid.", new[] { "SupplementalInvoiceServiceChargePercent" }));
                        break;
                }
            }
            #endregion

            #region VLIPIndicator
            if (!string.IsNullOrWhiteSpace(VLIPIndicator))
            {
                if (VLIPIndicator == "Z" && legacyOfficeCodes.Any(oc => oc != "NZ"))
                    results.Add(new ValidationResult("VLIP Indicator is not valid.", new[] { "VLIPIndicator" }));

                if ((MinimumProfitPercent ?? 0) > 0 ||
                    (MaximumDiscountPercent ?? 0) > 0 ||
                    (MaximumServiceChargePercent ?? 0) > 0 ||
                    (NetOutPercent ?? 0) > 0 ||
                    (MaximumAdjustingAmount ?? 0) > 0)
                    results.Add(new ValidationResult("VLIP Indicator is not valid.", new[] { "VLIPIndicator" }));
                if (secondaryProfiles != null)
                {
                    switch (VLIPIndicator)
                    {
                        case "E":
                            if (!secondaryProfiles.All(x => x.ISOBillingCurrency == "EUR"))
                                results.Add(new ValidationResult("VLIP Indicator is not valid for selected ISO Billing Currency.", new[] { "VLIPIndicator" }));
                            break;
                        case "A":
                            if (!secondaryProfiles.All(x => x.ISOBillingCurrency == "AUD"))
                                results.Add(new ValidationResult("VLIP Indicator is not valid for selected ISO Billing Currency.", new[] { "VLIPIndicator" }));
                            break;
                        case "P":
                            if (!secondaryProfiles.All(x => x.ISOBillingCurrency == "GBP"))
                                results.Add(new ValidationResult("VLIP Indicator is not valid for selected ISO Billing Currency.", new[] { "VLIPIndicator" }));
                            break;
                        case "Z":
                            if (!secondaryProfiles.All(x => x.ISOBillingCurrency == "NZD"))
                                results.Add(new ValidationResult("VLIP Indicator is not valid for selected ISO Billing Currency.", new[] { "VLIPIndicator" }));
                            break;
                        case "U":
                            if (!secondaryProfiles.All(x => x.ISOBillingCurrency == "USD"))
                                results.Add(new ValidationResult("VLIP Indicator is not valid for selected ISO Billing Currency.", new[] { "VLIPIndicator" }));
                            break;
                    }
                }
            }
            #endregion

            #region Include Price Add-On (ERM)
            if (featureConfig != null)
            {
                if (featureConfig.IsAvailable(FeaturesEnum.AddInflationRatesToPricingProfile))
                {
                    if (!IncludePriceAddOnERM)
                    {
                        if (DomesticERMPercent != null && DomesticERMPercent > 0m)
                            results.Add(new ValidationResult("Domestic ERM Percentage is not valid for selected Include Price Add-On (ERM).", new[] { "DomesticERMPercent" }));

                        if (ForeignERMPercent != null && ForeignERMPercent > 0m)
                            results.Add(new ValidationResult("Foreign ERM Percentage is not valid for selected Include Price Add-On (ERM).", new[] { "ForeignERMPercent" }));

                        if (ApplyERMToBillLaterAndStandingOrders)
                            results.Add(new ValidationResult("Apply ERM to Bill Later and Standing Orders is not valid for selected Include Price Add-On (ERM).", new[] { "ApplyERMToBillLaterAndStandingOrders" }));
                    }
                }
            }
            #endregion

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }

            return results;
        }

        public List<string> WarningValidation()
        {
            List<string> warnings = new List<string>();

            IRepository repository = null;
            IFeatureConfiguration featureConfig = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                    featureConfig = ServiceLocator.Current.GetInstance(typeof(IFeatureConfiguration)) as IFeatureConfiguration;
                }
                catch (ActivationException)
                {
                    //do nothing
                }

            try
            {
                if (featureConfig != null)
                {
                    if (featureConfig.IsAvailable(FeaturesEnum.AddInflationRatesToPricingProfile))
                    {
                        if (DomesticERMPercent > 10m)
                            warnings.Add("Domestic ERM Percent is over 10.0%");
                        if (ForeignERMPercent > 10m)
                            warnings.Add("Foreign ERM Percent is over 10.0%");
                    }
                }

                return warnings;
                
            }
            finally
            {
                repository?.Dispose();
            }
        }
    }
}
