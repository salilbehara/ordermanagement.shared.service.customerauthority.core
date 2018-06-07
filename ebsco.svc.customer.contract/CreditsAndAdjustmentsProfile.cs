using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{
    public class CreditsAndAdjustmentsProfile: IValidatableObject, IHasLegacyMappings
    {
        [Flags]
        public enum MonthEnumFlag : int
        {
            January = 1,
            February = 2,
            March = 4,
            April = 8,
            May = 16,
            June = 32,
            July = 64,
            August = 128,
            September = 256,
            October = 512,
            November = 1024,
            December = 2048,
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; } = new List<LegacyMapping>();

        [ChangeHistory(Name = "Credit Memo Months")]
        public MonthEnumFlag? CreditMemoMonths {get; set; }

        [ChangeHistory(Name = "Number of Credit Memo Copies")]
        [Range(0, 9, ErrorMessage = "The field Number of Credit Memo Copies must be between 0 and 9.")]
        public int NumberofCreditMemoCopies {get; set; }

        [ChangeHistory(Name = "Post Credits to A/R")]
        public bool PostCreditstoAR {get; set; }

        [Range(1, 4, ErrorMessage = "The field Number of Line Items On Credits must be between 1 and 4.")]
        [ChangeHistory(Name = "Number of Line Items On Credits")]
        public int? NumberOfLineItemsOnCredits {get; set; }

        [ChangeHistory(Name = "Mail Credit Memos")]
        public bool MailCreditMemos { get; set; } = true;

        [MaxLength(30)]
        [RegularExpression(@"^(([a-zA-Z0-9_\-\.']+)@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?))$", ErrorMessage = "Email Address is invalid.")]
        [ChangeHistory(Name = "Email Address for Credit Memos")]
        public string EmailAddressToSendCreditMemos {get; set; }

        [MaxLength(30)]
        [RegularExpression(@"^(([a-zA-Z0-9_\-\.']+)@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?))$", ErrorMessage = "Email Address is invalid.")]
        [ChangeHistory(Name = "Internal Email Address for Credit Memos")]
        public string InternalEmailAddressToSendCreditMemos {get; set; }

        [ChangeHistory(Name = "Mail Cost Only Reports")]
        public bool MailCostOnlyReports { get; set; } = true;

        [MaxLength(30)]
        [ChangeHistory(Name = "Email Address for Cost Only Reports")]
        [RegularExpression(@"^(([a-zA-Z0-9_\-\.']+)@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?))$", ErrorMessage = "Email Address is invalid.")]
        public string EmailAddressToSendCostOnlyReports {get; set; }

        [ChangeHistory(Name = "Mail Original Invoices (OI)")]
        public bool MailOriginalInvoices { get; set; } = true;

        [ChangeHistory(Name = "Mail Supplemental Invoices (SI)")]
        public bool MailSupplementalInvoices { get; set; } = true;

        [ChangeHistory(Name = "Use Current Purchase Order Number on Adjustment")]
        public bool UseCurrentPurchaseOrderNumberonAdjustment { get; set; }

        [ChangeHistory(Name = "Break Adjustments by Subscriber")]
        public bool BreakAdjustmentsbySubscriber { get; set; }

        [Required]
        [ChangeHistory(Name = "Adjustment Billing Months")]
        public MonthEnumFlag AdjustmentBillingMonths { get; set; }

        [ChangeHistory(Name = "Send Adjustments to A/R (OI)")]
        public bool OriginalInvoiceSendAdjustmentstoAR { get; set; } = true;

        [Range(0, 4, ErrorMessage = "The field Item Count (OI) must be between 0 and 4.")]
        [ChangeHistory(Name = "Item Count (OI)")]
        public int? OriginalInvoiceItemCount { get; set; }

        [Range(0, 30, ErrorMessage = "The field Number of Adjustment Copies (OI) must be between 0 and 30.")]
        [ChangeHistory(Name = "Number of Adjustment Copies (OI)")]
        public int? OriginalInvoiceNumberofAdjustmentCopies { get; set; }

        [ChangeHistory(Name = "Send Adjustments to A/R (SI)")]
        public bool SupplementalInvoiceSendAdjustmentstoAR { get; set; } = true;

        [Range(0, 4, ErrorMessage = "The field Item Count (SI) must be between 0 and 4.")]
        [ChangeHistory(Name = "Item Count (SI)")]
        public int? SupplementalInvoiceItemCount { get; set; }

        [Range(0, 30, ErrorMessage = "The field Number of Adjustment Copies (SI) must be between 0 and 30.")]
        [ChangeHistory(Name = "Number of Adjustment Copies (SI)")]
        public int? SupplementalInvoiceNumberofAdjustmentCopies { get; set; }

        [MaxLength(500)]
        [ChangeHistory(Name = "Adjustments Special Handling")]
        public string AdjustmentSpecialHandling { get; set; }

        [MaxLength(200)]
        [ChangeHistory(Name = "Email Address for Adjustments")]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Address for Adjustments is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        public string EmailAddressToSendAdjustments { get; set; }
        
        [ChangeHistory(Name = "Email Original And Supplemental Invoices")]
        public bool EmailOriginalAndSupplementalInvoices { get; set; } = false;

        [ChangeHistory(Name = "Email Original Invoices Only")]
        public bool EmailOriginalInvoicesOnly { get; set; } = false;

        [ChangeHistory(Name = "Email Special Sort Copy Only")]
        public bool EmailSpecialSortCopyOnly { get; set; } = false;

        [ChangeHistory(Name = "Email Alpha Copy Only")]
        public bool EmailAlphaCopyOnly { get; set; } = false;

        [MaxLength(500)]
        [ChangeHistory(Name = "Credits Special Handling")]
        public string CreditsSpecialHandling { get; set; }

        [ChangeHistory(Name = "Issue Refund by Check - No Credits")]
        public bool IssueRefundByCheckNoCredits { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Issue Refund by Check - No Credits Comments")]
        public string IssueRefundByCheckNoCreditsComments { get; set; }

        [ChangeHistory(Name = "Apply Credit to Any Outstanding Charge")]
        public bool ApplyCreditToAnyOutstandingCharge { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            IValidationRepository validationRepository = null;
            IFeatureConfiguration featureConfig = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    validationRepository = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                    featureConfig = ServiceLocator.Current.GetInstance(typeof(IFeatureConfiguration)) as IFeatureConfiguration;
                }
                catch (ActivationException)
                {
                    //do nothing
                }

            #region BreakAdjustmentsBySubscriber
            if (BreakAdjustmentsbySubscriber && (OriginalInvoiceItemCount > 0 || SupplementalInvoiceItemCount > 0))
                results.Add(new ValidationResult("Cannot break Adjustments by Subscriber.", new[] { "BreakAdjustmentsbySubscriber" }));

            #endregion

            if(string.IsNullOrEmpty(EmailAddressToSendAdjustments) &&
                (EmailAlphaCopyOnly || EmailOriginalAndSupplementalInvoices || EmailOriginalInvoicesOnly || EmailSpecialSortCopyOnly))
                results.Add(new ValidationResult("Email Address for Adjustments is not provided.", new[] { "EmailAddressToSendAdjustments" }));

            #region IssueRefundbyCheckNoCredits
            if (featureConfig != null)
            {
                if (featureConfig.IsAvailable(FeaturesEnum.AddRemainingCCILines))
                {
                    if ((IssueRefundByCheckNoCredits == false) && !string.IsNullOrWhiteSpace(IssueRefundByCheckNoCreditsComments))
                        results.Add(new ValidationResult("Cannot add Issue Refund by Check - No Credits Comments.", new[] { "IssueRefundbyCheckNoCreditsComments" }));
                }
            }
            #endregion

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }

            if(!(AdjustmentBillingMonths.HasFlag(MonthEnumFlag.January) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.February) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.March) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.April) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.May) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.June) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.July) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.August) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.September) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.October) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.November) ||
                AdjustmentBillingMonths.HasFlag(MonthEnumFlag.December)
                ))
                results.Add(new ValidationResult("Adjustment Billing Months is required", null));


            return results;
        }
    }
}
