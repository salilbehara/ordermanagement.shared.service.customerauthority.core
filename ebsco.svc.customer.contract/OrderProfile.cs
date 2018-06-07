using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{
    public class OrderProfile : IValidatableObject, IHasLegacyMappings
    {
       
        public OrderProfile()
        {
            LegacyMappings = new List<LegacyMapping>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }
        [ChangeHistory(Name = "Purchase Order Number Satisfies Formal Requirement")]
        public bool PurchaseOrderNumberSatisfiesFormalRequirement { get; set; }

        [MaxLength(450)]
        [ChangeHistory(Name = "Purchase Order Number Satisfies Formal Requirement Comments")]
        public string PurchaseOrderNumberSatisfiesFormalRequirementComments { get; set; }

        [MaxLength(28)]
        [ChangeHistory(Name = "Purchase Order Number")]
        public string PurchaseOrderNumber { get; set; }

        [MaxLength(450)]
        [ChangeHistory(Name = "Purchase Order Number Comments")]
        public string PurchaseOrderNumberComments { get; set; }
        [ChangeHistory(Name = "Purchase Order Number Used Until")]
        public DateTime? PurchaseOrderNumberUsedUntil { get; set; }
        [ChangeHistory(Name = "Purchase Order Received Date")]
        public DateTime? PurchaseOrderReceivedDate { get; set; }

        [Range(0, 99999999999999999999.99, ErrorMessage = "The field Purchase Order Number Amount must be between 0 and 99999999999999999999.99.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Purchase Order Number Amount cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Purchase Order Number Amount")]
        public decimal? PurchaseOrderNumberAmount { get; set; }
        [ChangeHistory(Name = "Combine Purchase Orders")]
        public bool CombinePurchaseOrders { get; set; }

        [MaxLength(550)]
        [ChangeHistory(Name = "Combine Purchase Orders Comments")]
        public string CombinePurchaseOrdersComments { get; set; }
        [ChangeHistory(Name = "Process Without Formal Purchase Order")]
        public bool ProcessWithoutFormalPurchaseOrder { get; set; }
        [ChangeHistory(Name = "Process Without Formal Purchase Order Comments")]
        public string ProcessWithoutFormalPurchaseOrderComments { get; set; }

        [Range(0, 99999.99, ErrorMessage = "The field Order Cannot Exceed Amount On Purchase Order By (Amount) must be between 0 and 99999.99.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Order Cannot Exceed Amount On Purchase Order By (Amount) cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Order Cannot Exceed Amount On Purchase Order By (Amount)")]
        public decimal? OrderCannotExceedAmountOnPurchaseOrderByAmount { get; set; }
        [ChangeHistory(Name = "Order Cannot Exceed Amount On Purchase Order By (Amount) Comments")]
        [MaxLength(450)]
        public string OrderCannotExceedAmountOnPurchaseOrderByAmountComments { get; set; }

        [Range(0, 99.99, ErrorMessage = "The field Order Cannot Exceed Amount On Purchase Order By (Percent) must be between 0 and 99.99.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Decimal value precision for Order Cannot Exceed Amount On Purchase Order By (Percent) cannot exceed 2 decimal places")]
        [ChangeHistory(Name = "Order Cannot Exceed Amount On Purchase Order By (Percent)")]
        public decimal? OrderCannotExceedAmountOnPurchaseOrderByPercent { get; set; }

        [MaxLength(450)]
        [ChangeHistory(Name = "Order Cannot Exceed Amount On Purchase Order By (Percent) Comments")]
        public string OrderCannotExceedAmountOnPurchaseOrderByPercentComments { get; set; }
        [ChangeHistory(Name = "Payment Required Before Processing")]
        public bool PaymentRequiredBeforeProcessing { get; set; }
        [MaxLength(125)]
        [ChangeHistory(Name = "Payment Required Before Processing Comments")]
        public string PaymentRequiredBeforeProcessingComments { get; set; }
        [ChangeHistory(Name = "Edit Required Before Processing")]
        public bool EditRequiredBeforeProcessing { get; set; }

        [MaxLength(500)]
        [ChangeHistory(Name = "Edit Required Before Processing Comments")]
        public string EditRequiredBeforeProcessingComments { get; set; }
        [ChangeHistory(Name = "Has Bad Debt")]
        public bool HasBadDebt { get; set; }

        [MaxLength(200)]
        [ChangeHistory(Name = "Has Bad Debt Comments")]
        public string HasBadDebtComments { get; set; }
        [ChangeHistory(Name = "Purchase Order Flag")]
        public string PurchaseOrderFlag { get; set; }

        [ChangeHistory(Name = "Claim Checker Report")]
        public string ClaimCheckerReport { get; set; }
        [ChangeHistory(Name = "Claim Checker Aging")]
        public string ClaimCheckerAging { get; set; }

        [ChangeHistory(Name = "Refer to Supervisor Before Processing")]
        public bool ReferToSupervisorBeforeProcessing { get; set; }

        [MaxLength(600, ErrorMessage = "Refer to Supervisor Before Processing Comment cannot exceed 600 characters")]
        [ChangeHistory(Name = "Refer To Supervisor Before Processing Comments")]
        public string ReferToSupervisorBeforeProcessingComments { get; set; }

        [Range(0, 9, ErrorMessage = "Additional Years To Retain Order History must be between 0 and 9.")]
        [ChangeHistory(Name = "Additional Years To Retain Order History")]
        public Int16? AdditionalYearsToRetainOrderHistory { get; set; }

        [Range(0, 999999999, ErrorMessage = "Number Of Users with Online Journal Access must be between 0 and 999999999.")]
        [ChangeHistory(Name= "Number Of Users with Online Journal Access")]
        public int? NumberOfUsersWithOnlineJournalAccess { get; set; }

        [MaxLength(250, ErrorMessage = "Number Of Users with Online Journal Access Comment cannot exceed 250 Characters")]
        [ChangeHistory(Name = "Number Of Users with Online Journal Access Comments")]
        public string NumberOfUsersWithOnlineJournalAccessComments { get; set; }

        [ChangeHistory(Name = "Override SOE Autoprice Logic")]
        public bool OverrideSOEAutopriceLogic { get; set; }

        [ChangeHistory(Name = "Allow Bill Later Orders")]
        public bool AllowBillLaterOrders { get; set; }

        [ChangeHistory(Name = "Allow Standing Orders")]
        public bool AllowStandingOrders { get; set; }

        [ChangeHistory(Name = "Bill Later and Standing Orders Only")]
        public bool BillLaterAndStandingOrdersOnly { get; set; }

        [ChangeHistory(Name = "Postage Paid in Advance")]
        public bool PostagePaidInAdvance { get; set; }

        [ChangeHistory(Name = "Start Month")]
        public string StartMonth { get; set; }

        [ChangeHistory(Name = "Special Invoice Date")]
        public DateTime? SpecialInvoiceDate { get; set; }
        [ChangeHistory(Name = "Use Special Invoice Date Until")]
        public DateTime? UseSpecialInvoiceDateUntil { get; set; }

        [ChangeHistory(Name = "Common Expire")]
        public string CommonExpire { get; set; }
        [ChangeHistory(Name = "Allow Long Terms and Double Entries")]
        public bool AllowLongTermsAndDoubleEntries { get; set; }
        [ChangeHistory(Name = "Allow Double Entries")]
        public bool AllowDoubleEntries { get; set; }
        [ChangeHistory(Name = "Allow Long Terms")]
        public bool AllowLongTerms { get; set; }
        [ChangeHistory(Name = "Allow Short Terms")]
        public bool AllowShortTerms { get; set; }

        [ChangeHistory(Name = "E-Journal Title Preference Handled By Office")]
        public bool EJournalTitlePreferenceHandledByOffice { get; set; }

        [ChangeHistory(Name = "Access to Offers for Free Online Journals")]
        public string AccessToOffersForFreeOnlineJournals { get; set; }

        [MaxLength(375, ErrorMessage = "Access to Offers for Free Online Journal Comment cannot exceed 375 Characters")]
        [ChangeHistory(Name = "Access to Offers for Free Online Journals Comments")]
        public string AccessToOffersForFreeOnlineJournalsComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            IValidationRepository validationRepository = null;

            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    validationRepository = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                }
                catch (ActivationException)
                {
                    //do nothing
                }

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }

            #region F25195 - Add additional CCI Lines
            #region BillLaterandStandingOrdersOnly
            if (BillLaterAndStandingOrdersOnly == true && (AllowStandingOrders == false || AllowBillLaterOrders == false))
                results.Add(new ValidationResult("Allow Standing Orders and Allow Bill Later Orders must both be Yes.", new[] { "BillLaterandStandingOrdersOnly" }));
            #endregion

            #region SpecialInvoiceDate
            if (!SpecialInvoiceDate.HasValue && UseSpecialInvoiceDateUntil.HasValue)
                results.Add(new ValidationResult("Cannot add Use Special Invoice Date.", new[] { "SpecialInvoiceDate" }));
            #endregion

            #region CommonExpire
            if (string.IsNullOrWhiteSpace(CommonExpire) || CommonExpire == "No")
            {
                if (AllowLongTermsAndDoubleEntries == true)
                    results.Add(new ValidationResult("Cannot add Allow Long Terms and Double Entries.", new[] { "AllowLongTermsandDoubleEntries" }));
                if (AllowDoubleEntries == true)
                    results.Add(new ValidationResult("Cannot add Allow Double Entries.", new[] { "AllowDoubleEntries" }));
                if (AllowLongTerms == true)
                    results.Add(new ValidationResult("Cannot add Allow Long Terms.", new[] { "AllowLongTerms" }));
                if (AllowShortTerms == true)
                    results.Add(new ValidationResult("Cannot add Allow Short Terms.", new[] { "AllowShortTerms" }));
            }
            #endregion
            #endregion
            
            #region CombinePurchaseOrdersComments
            if (!string.IsNullOrWhiteSpace(CombinePurchaseOrdersComments) && (CombinePurchaseOrders))
                results.Add(new ValidationResult("Cannot add Combine Purchase Orders Comments.", new[] { "CombinePurchaseOrdersComments" }));
            #endregion

            #region HasBadDebtComments
            if (!string.IsNullOrWhiteSpace(HasBadDebtComments) && !(HasBadDebt))
                results.Add(new ValidationResult("Cannot add Has Bad Debt Comments.", new[] { "HasBadDebtComments" }));
            #endregion

            #region OrderCannotExceedAmountOnPurchaseOrderByAmount && OrderCannotExceedAmountOnPurchaseOrderByPercent
            if ((OrderCannotExceedAmountOnPurchaseOrderByAmount.HasValue) && (OrderCannotExceedAmountOnPurchaseOrderByPercent.HasValue))
                results.Add(new ValidationResult("Order Cannot Exceed Amount On Purchase Order By must be either an amount or a percentage.", new[] { "OrderCannotExceedAmountOnPurchaseOrderByAmountComments" }));
            #endregion

            #region OrderCannotExceedAmountOnPurchaseOrderByPercentComments
            if (!string.IsNullOrWhiteSpace(OrderCannotExceedAmountOnPurchaseOrderByPercentComments) && !(OrderCannotExceedAmountOnPurchaseOrderByPercent.HasValue))
                results.Add(new ValidationResult("Cannot add Order Cannot Exceed Amount On Purchase Order By (Percent) Comments.", new[] { "OrderCannotExceedPercentOnPurchaseOrderByPercentComments" }));
            #endregion

            #region OrderCannotExceedAmountOnPurchaseOrderByAmountComments
            if (!string.IsNullOrWhiteSpace(OrderCannotExceedAmountOnPurchaseOrderByAmountComments) && !(OrderCannotExceedAmountOnPurchaseOrderByAmount.HasValue))
                results.Add(new ValidationResult("Cannot add Order Cannot Exceed Amount On Purchase Order By (Amount) Comments.", new[] { "OrderCannotExceedAmountOnPurchaseOrderByAmountComments" }));
            #endregion

            #region PaymentRequiredBeforeProcessingComments
            if (!string.IsNullOrWhiteSpace(PaymentRequiredBeforeProcessingComments) && !(PaymentRequiredBeforeProcessing))
                results.Add(new ValidationResult("Cannot add Payment Required Before Processing Comments.", new[] { "PaymentRequiredBeforeProcessingComments" }));
            #endregion

            #region ProcessWithoutFormalPurchaseOrderComments
            if (!string.IsNullOrWhiteSpace(ProcessWithoutFormalPurchaseOrderComments) && (ProcessWithoutFormalPurchaseOrder))
                results.Add(new ValidationResult("Cannot add Process Without Formal Purchase Order Comments.", new[] { "ProcessWithoutFormalPurchaseOrderComments" }));
            #endregion

            #region PurchaseOrderNumberComments
            if (!string.IsNullOrWhiteSpace(PurchaseOrderNumberComments) && string.IsNullOrWhiteSpace(PurchaseOrderNumber))
                results.Add(new ValidationResult("Cannot add Purchase Order Number Comments.", new[] { "PurchaseOrderNumberComments" }));
            #endregion            

            #region PurchaseOrderNumberSatisfiesFormalRequirementComments
            if (!string.IsNullOrWhiteSpace(PurchaseOrderNumberSatisfiesFormalRequirementComments) && !(PurchaseOrderNumberSatisfiesFormalRequirement))
                results.Add(new ValidationResult("Cannot add Purchase Order Number Satisfies Formal Requirement Comments.", new[] { "PurchaseOrderNumberSatisfiesFormalRequirementComments" }));
            #endregion

            #region EditRequiredBeforeProcessingComments
            if (!string.IsNullOrWhiteSpace(EditRequiredBeforeProcessingComments) && !(EditRequiredBeforeProcessing))
                results.Add(new ValidationResult("Cannot add Edit Required Before Processing Comments.", new[] { "EditRequiredBeforeProcessingComments" }));
            #endregion

            #region NumberOfUsers

            if (string.IsNullOrWhiteSpace(NumberOfUsersWithOnlineJournalAccess.ToString()) &&
                !string.IsNullOrWhiteSpace(NumberOfUsersWithOnlineJournalAccessComments))
                results.Add(new ValidationResult("Number Of Users with Online Journal Access is not provided.",
                    new[] {"NumberOfUsersWithOnlineJournalAccess."}));

            #endregion

            #region AccessToOffers

            if (string.IsNullOrEmpty(AccessToOffersForFreeOnlineJournals))
                results.Add(new ValidationResult(" Access to Offers is not provided",
                    new[] {"AccessToOffersForFreeOnlineJournals"}));

            #endregion


            return results;
        }


    }
}
