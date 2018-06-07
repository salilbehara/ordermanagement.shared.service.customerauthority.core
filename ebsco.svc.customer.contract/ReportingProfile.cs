using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ebsco.svc.customer.contract
{
    public class ReportingProfile : IValidatableObject, IHasLegacyMappings
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; } = new List<LegacyMapping>();

        [ChangeHistory(Name = "Price Increase Alert")]
        public string PriceIncreaseAlert { get; set; }

        [Range(0, 100.0, ErrorMessage = "The field Alert Customer if Price Increases by (Percent) must be between 0 and 100.0.")]
        [RegularExpression(@"^[0-9]+(\.[0-9][0]{0,2})?$", ErrorMessage = "Decimal value precision for Alert Customer if Price Increases by (Percent) cannot exceed 1 decimal place")]
        [ChangeHistory(Name = "Alert Customer if Price Increases by (Percent)")]
        public decimal? AlertCustomerIfPriceIncreasesByPercent { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Addresses to send Alert is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Addresses to send Alert")]
        public string EmailAddressesToSendAlert { get; set; }

        [ChangeHistory(Name = "Print Customized Bulletin of Serials Changes")]
        public bool PrintCustomizedBulletinOfSerialsChanges { get; set; }

        [MaxLength(165)]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Address For Customized Bulletin of Serials Changes is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Address For Customized Bulletin of Serials Changes")]
        public string EmailAddressForCustomizedBulletinOfSerialsChanges { get; set; }

        [ChangeHistory(Name = "Show C3 Comment on Bulletin of Serials Changes")]
        public bool ShowC3CommentOnBulletinOfSerialsChanges { get; set; }

        [ChangeHistory(Name = "Send Claim Acknowledgement to Customer")]
        public bool SendClaimAcknowledgementToCustomer { get; set; }

        [ChangeHistory(Name = "Print Cancellation Acknowledgements")]
        public bool PrintCancellationAcknowledgements { get; set; }

        [MaxLength(225)]
        [ChangeHistory(Name = "Claim Checker Information")]
        public string ClaimCheckerInformation { get; set; }

        [MaxLength(225)]
        [ChangeHistory(Name = "Claim Checker Special Handling")]
        public string ClaimCheckerSpecialHandling { get; set; }

        [ChangeHistory(Name = "Print Jets Cumulative Report")]
        public bool PrintJetsCumulativeReport { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Print Jets Cumulative Report Comments")]
        public string PrintJetsCumulativeReportComments { get; set; }
        [ChangeHistory(Name = "Jets Cumulative Report Frequency")]
        public string JetsCumulativeReportFrequency { get; set; }

        [ChangeHistory(Name = "Special Reporting - Renewal Date")]
        public DateTime? SpecialReportingRenewalDate { get; set; }

        [ChangeHistory(Name = "Special Reporting - Invoice Date")]
        public DateTime? SpecialReportingInvoiceDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            IRepository repository = null;
            IValidationRepository validationRepository = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                    validationRepository = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                }
                catch (ActivationException)
                {
                    //do nothing
                }


            IEnumerable<OrderProfile> orderProfiles = null;
            if (repository != null)
            {
                var suffixLegacyMappingIds = LegacyMappings.Where(lm => lm.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.Id);

                orderProfiles = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.OrderProfiles)
                    .OrderProfiles
                    .Where(scp => scp.LegacyMappings.Any(pplm => suffixLegacyMappingIds.Contains(pplm.Id)));
            }

            #region ClaimCheckerInformation
            if (!string.IsNullOrEmpty(ClaimCheckerInformation))
            {
                if (orderProfiles != null)
                {
                    if (orderProfiles.Any(x => string.IsNullOrEmpty(x.ClaimCheckerReport?.Trim())))
                        results.Add(new ValidationResult("Cannot use Claim Checker Information if Claim Checker Report is not selected", new[] { "ClaimCheckerInformation" }));
                }
            }
            #endregion

            #region ClaimCheckerSpecialHandling
            if (!string.IsNullOrEmpty(ClaimCheckerSpecialHandling))
            {
                if (orderProfiles != null)
                {
                    if (orderProfiles.Any(x => string.IsNullOrEmpty(x.ClaimCheckerReport?.Trim())))
                        results.Add(new ValidationResult("Cannot use Claim Checker Special Handling if Claim Checker Report is not selected", new[] { "ClaimCheckerSpecialHandling" }));
                }
            }
            #endregion

            #region AlertCustomerIfPriceIncreasesByPercent
            if ((AlertCustomerIfPriceIncreasesByPercent > 0m) && (string.IsNullOrEmpty(PriceIncreaseAlert)))
                results.Add(new ValidationResult("Price Increase Alert month not selected", new[] { "AlertCustomerIfPriceIncreasesByPercent" }));
            if ((AlertCustomerIfPriceIncreasesByPercent == 0m || !AlertCustomerIfPriceIncreasesByPercent.HasValue) && (!string.IsNullOrEmpty(PriceIncreaseAlert)))
                results.Add(new ValidationResult("Price Increase Alert percentage is not provided", new[] { "AlertCustomerIfPriceIncreasesByPercent" }));
            #endregion

            #region EmailAddressesToSendAlert
            if (string.IsNullOrEmpty(EmailAddressesToSendAlert) && !string.IsNullOrEmpty(PriceIncreaseAlert))
                results.Add(new ValidationResult("Price Increase Alert email not provided", new[] { "EmailAddressesToSendAlert" }));
            if (!string.IsNullOrEmpty(EmailAddressesToSendAlert) && string.IsNullOrEmpty(PriceIncreaseAlert))
                results.Add(new ValidationResult("Price Increase Alert month not selected", new[] { "EmailAddressesToSendAlert" }));
            #endregion

            #region PrintJetsCumulativeReport
            if ((PrintJetsCumulativeReport == false) && !string.IsNullOrWhiteSpace(JetsCumulativeReportFrequency))
                results.Add(new ValidationResult("Cannot add Jets Cumulative Report Frequency.", new[] { "JetsCumulativeReportFrequency" }));
            if ((PrintJetsCumulativeReport == false) && !string.IsNullOrWhiteSpace(PrintJetsCumulativeReportComments))
                results.Add(new ValidationResult("Cannot add Print Jets Cumulative Report Comments.", new[] { "PrintJetsCumulativeReportComments" }));
            #endregion


            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }

            return results;
        }
    }
}
