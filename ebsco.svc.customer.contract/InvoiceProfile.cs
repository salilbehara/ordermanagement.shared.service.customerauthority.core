using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace ebsco.svc.customer.contract
{
    public class InvoiceProfile : IValidatableObject
    {
        [Flags]
        public enum InvoiceTypestoIncludeEnum : int
        {
            OriginalInvoice = 1,
            SupplementalInvoice = 2,
            Weekly = 4,
            CreditMemo = 8,
        }

        [Flags]
        public enum ConsolidatedInvoiceParametersEnum : int
        {
            IncludeCredit = 1,
            IncludeEBSCOBook = 2,
            IncludeOriginalDebit = 4,
            IncludePayPerView = 8,
            IncludeSupplementalDebit = 16,
        }

        [Flags]
        public enum InvoiceMonthEnumFlag : int
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

        public enum InvoiceMonthEnum : int
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
        }
        [Flags]
        public enum PrintCommentLinesFlag : short
        {
            PrintCommentLine1 = 1,
            PrintCommentLine2 = 2,
            PrintCommentLine3 = 4,
            PrintAllThreeCommentLines = 8,
        }
        public InvoiceProfile()
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

        [Required]
        [Range(0, 99)]
        [ChangeHistory(Name = "Number of Invoice Copies")]
        public int? NumberOfInvoiceCopies { get; set; }

        [MaxLength(250)]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Address for Invoices is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Address for Invoices")]
        public string EmailAddressforInvoices { get; set; }
        [ChangeHistory(Name = "Hegis Number Required")]
        public bool HegisNumbersRequired { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Hegis Number Required Comments")]
        public string HegisNumberRequiredComments { get; set; }
        [ChangeHistory(Name = "Sort by ISC")]
        public string SortbyISC { get; set; }
        [Range(1, 9)]
        [ChangeHistory(Name = "Comment Line Required")]
        public int? CommentLineRequired { get; set; }
        [ChangeHistory(Name = "Use C1* Comment")]
        public bool UseC1Comment { get; set; }
        [ChangeHistory(Name = "Use C3* Comment")]
        public bool UseC3Comment { get; set; }
        [ChangeHistory(Name = "Split Invoice By")]
        public string SplitInvoiceBy { get; set; }
        [Range(0, 99999)]
        [ChangeHistory(Name = "Maximum Invoice Line Items")]
        public int? MaximumInvoiceLineItems { get; set; }
        [MaxLength(450)]
        [ChangeHistory(Name = "Maximum Invoice Line Items Comments")]
        public string MaximumInvoiceLineItemsComments { get; set; }
        [Range(0, 999999)]
        [ChangeHistory(Name = "Maximum Invoice Amount")]
        public int? MaximumInvoiceAmount { get; set; }
        [MaxLength(450)]
        [ChangeHistory(Name = "Maximum Invoice Amount Comments")]
        public string MaximumInvoiceAmountComments { get; set; }
        [ChangeHistory(Name = "TSC Required")]
        public bool TSCRequired { get; set; }
        [MaxLength(125)]
        [ChangeHistory(Name = "TSC Required Comments")]
        public string TSCRequiredComments { get; set; }
        [ChangeHistory(Name = "Multiple Year Rate")]
        public string MultipleYearRate { get; set; }
        [ChangeHistory(Name = "Multiple Year Titles")]
        public string MultipleYearTitles { get; set; }
        [ChangeHistory(Name = "Include EDI Invoicing Details")]
        public bool IncludeEDIInvoicingDetails { get; set; }
        [ChangeHistory(Name = "ILS Format")]
        public string ILSFormat { get; set; }
        [ChangeHistory(Name = "EDI File Transmission Method")]
        public string EDIFileTransmissionMethod { get; set; }
        [ChangeHistory(Name = "Invoice Types to Include")]
        public InvoiceTypestoIncludeEnum? InvoiceTypestoInclude { get; set; }
        [MaxLength(51)]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Addresses for Acknowledgements is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Addresses for Acknowledgements")]
        public string EmailAddressesforAcknowledgements { get; set; }
        [MaxLength(128)]
        [ChangeHistory(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }
        [ChangeHistory(Name = "EDI For Main Renewal Invoice Only")]
        public bool EDIForMainRenewalInvoiceOnly { get; set; }
        [ChangeHistory(Name = "Proforma Only")]
        public bool ProformaOnly { get; set; }
        [Range(0, 99)]
        [ChangeHistory(Name = "Discount Days")]
        public int? DiscountDays { get; set; }
        [ChangeHistory(Name = "Print Invoices Simplex")]
        public bool PrintInvoicesSimplex { get; set; }
        [ChangeHistory(Name = "Consolidate Invoicing")]
        public bool ConsolidateInvoicing { get; set; }
        [ChangeHistory(Name = "Hold Until Current Rates Available")]
        public bool HoldUntilCurrentRatesAvailable { get; set; }
        [ChangeHistory(Name = "Invoice Later")]
        public bool InvoiceLater { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }

        [MaxLength(11)]
        [ChangeHistory(Name = "Account to be merged")]
        public string AccountToBeMerged { get; set; }
        [ChangeHistory(Name = "Cash Discount Percent")]
        public int? CashDiscountPercent { get; set; }
        [ChangeHistory(Name = "Combine Suffixes")]
        public Int16? CombineSuffixes { get; set; }
        [ChangeHistory(Name = "Comment Line Required Comments")]
        public string CommentLineRequiredComments { get; set; }
        [ChangeHistory(Name = "Consolidated Invoice Parameters")]
        public ConsolidatedInvoiceParametersEnum? ConsolidatedInvoiceParameters { get; set; }
        [ChangeHistory(Name = "Include Access Only Titles In Invoices")]
        public bool IncludeAccessOnlyTitlesInInvoices { get; set; }
        [ChangeHistory(Name = "Include Access Only Titles In Renewals")]
        public bool IncludeAccessOnlyTitlesInRenewals { get; set; }
        [ChangeHistory(Name = "Include Access Only Titles In Reports")]
        public bool IncludeAccessOnlyTitlesInReports { get; set; }
        [ChangeHistory(Name = "Consolidated Invoice Month")]
        public InvoiceMonthEnumFlag? ConsolidatedInvoiceMonth { get; set; }
        [ChangeHistory(Name = "Invoice With Book")]
        public bool InvoiceWithBook { get; set; }
        [ChangeHistory(Name = "Packing List With Books")]
        public bool PackingListWithBooks { get; set; }
        [ChangeHistory(Name = "Period Split")]
        public InvoiceMonthEnum? PeriodSplit { get; set; }
        [ChangeHistory(Name = "Print Conversion Line")]
        public bool PrintConversionLine { get; set; }
        [ChangeHistory(Name = "Print Issn on Invoices And Renewals")]
        public bool PrintIssnNumbersOnInvoicesAndRenewals { get; set; }
        [ChangeHistory(Name = "Use C1* Comment Comments")]
        public string UseC1CommentComments { get; set; }
        [ChangeHistory(Name = "Use C3* Comment Comments")]
        public string UseC3CommentComments { get; set; }
        [ChangeHistory(Name = "Process Immediately")]
        public bool ProcessImmediately { get; set; }

        [MaxLength(16)]
        [ChangeHistory(Name = "VAT Fiscal Code Number")]
        public string VATFiscalCodeNumber { get; set; }
        [MaxLength(11)]
        [ChangeHistory(Name = "VAT Non-Company Number")]
        public string VATNonCompanyNumber { get; set; }
        [ChangeHistory(Name = "Omit Comments")]
        public bool OmitComments { get; set; }
        [ChangeHistory(Name = "Break Adjustments by Subscriber")]
        public bool BreakAdjustmentsbySubscriber { get; set; }

        [Required]
        [ChangeHistory(Name = "Adjustment Billing Months")]
        public InvoiceMonthEnumFlag AdjustmentBillingMonths { get; set; }
        [ChangeHistory(Name = "Send Adjustments to A/R (OI)")]
        public bool OriginalInvoiceSendAdjustmentstoAR { get; set; }

        [Range(0, 4)]
        [ChangeHistory(Name = "Item Count (OI)")]
        public int? OriginalInvoiceItemCount { get; set; }

        [Range(0, 30)]
        [ChangeHistory(Name = "Number of Adjustment Copies (OI)")]
        public int? OriginalInvoiceNumberofAdjustmentCopies { get; set; }
        [ChangeHistory(Name = "Send Adjustments to A/R (SI)")]
        public bool SupplementalInvoiceSendAdjustmentstoAR { get; set; }

        [Range(0, 4)]
        [ChangeHistory(Name = "Item Count (SI)")]
        public int? SupplementalInvoiceItemCount { get; set; }

        [Range(0, 30)]
        [ChangeHistory(Name = "Number of Adjustment Copies (SI)")]
        public int? SupplementalInvoiceNumberofAdjustmentCopies { get; set; }

        [MaxLength(500)]
        [ChangeHistory(Name = "Invoice Special Handling")]
        public string InvoiceSpecialHandling { get; set; }

        [MaxLength(500)]
        [ChangeHistory(Name = "Adjustments Special Handling")]
        public string AdjustmentSpecialHandling { get; set; }

        [ChangeHistory(Name = "Break Invoice by VAT Code")]
        public bool BreakInvoiceByVatCode { get; set; }
        [ChangeHistory(Name = "Include Invoice Detail Report")]
        public bool IncludeInvoiceDetailReport { get; set; }
        [ChangeHistory(Name = "Include Purchase Titles On Invoice")]
        public bool IncludePurchaseTitlesOnInvoice { get; set; }
        [ChangeHistory(Name = "Print Invoices In Old Format")]
        public bool PrintInvoicesInOldFormat { get; set; }
        [ChangeHistory(Name = "Print Expire Dates On Invoices And Renewals")]
        public bool PrintExpireDatesOnInvoicesAndRenewals { get; set; }
        [ChangeHistory(Name = "Print Service Charge/Discount By Line Item")]
        public bool PrintServiceChargeDiscountByLineItem { get; set; }
        [ChangeHistory(Name = "Print Line Item Retail, Service Charge and Total")]
        public bool PrintLineItemRetailServiceChargeAndTotal { get; set; }
        [ChangeHistory(Name = "Print Sales Tax By Line Item")]
        public bool PrintSalesTaxByLineItem { get; set; }
        [ChangeHistory(Name = "Print Publisher Retail In Billing Currency")]
        public bool PrintPublisherRetailInBillingCurrency { get; set; }
        [ChangeHistory(Name = "Print VLIP Adjustment Amount at Bottom Left")]
        public bool PrintVlipAdjustmentAmountAtBottomLeft { get; set; }
        [ChangeHistory(Name = "Print Line Item Retail, Service Charge, GST/PST and Total")]
        public bool PrintLineItemRetailServiceChargeGstPstAndTotal { get; set; }
        [ChangeHistory(Name = "Print Net Title Markup(NTM) Flag")]
        public bool PrintNetTitleMarkupFlag { get; set; }
        [ChangeHistory(Name = "Print Expanded Volume Information")]
        public bool PrintExpandedVolumeInformation { get; set; }
        [ChangeHistory(Name = "Print Comment Lines")]
        public PrintCommentLinesFlag? PrintCommentLines { get; set; }
        [ChangeHistory(Name = "Print Page Total")]
        public bool PrintPageTotal { get; set; }
        [ChangeHistory(Name = "Print Running Sub-Total")]
        public bool PrintRunningSubTotal { get; set; }
        [ChangeHistory(Name = "Mail Invoices To")]
        public string MailInvoicesTo { get; set; }
        [ChangeHistory(Name = "Mail Only Hegis Copy Of Invoice")]
        public bool MailOnlyHegisCopyOfInvoice { get; set; }
        [ChangeHistory(Name = "Alternate Reply to Email Address for Invoices")]
        public string AlternateReplyToEmailAddressForInvoices { get; set; }
        [ChangeHistory(Name = "Email Main Invoice")]
        public bool EmailMainInvoice { get; set; }
        [ChangeHistory(Name = "Email Alpha Copy Only")]
        public bool EmailAlphaCopyOnly { get; set; }
        [ChangeHistory(Name = "Email Special Sort Copy Only")]
        public bool EmailSpecialSortCopyOnly { get; set; }
        [ChangeHistory(Name = "Email Address for Overnight Edits")]
        public string EmailAddressForOvernightEdits { get; set; }
        [ChangeHistory(Name = "Split payment - Use Public Administration VAT Matrix")]
        public bool SplitPaymentUsePublicAdministrationVATMatrix { get; set; }
        [ChangeHistory(Name = "Apply VAT at Invoice level")]
        public bool ApplyVatAtInvoiceLevel { get; set; }
        [ChangeHistory(Name = "EDI System")]
        public string EDISystem { get; set; }

        [ChangeHistory(Name = "Fund Code Required")]
        public int FundCodeRequired { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Fund Code Required Comments")]
        public string FundCodeRequiredComments { get; set; }
        [MaxLength(22)]
        [ChangeHistory(Name = "Fund Code to print on Invoice")]
        public string FundCodeToPrintOnInvoice { get; set; }
        [ChangeHistory(Name = "Print Volume Number on All Titles")]
        public bool PrintVolumeNumberOnAllTitles { get; set; }

        [MaxLength(2)]
        [ChangeHistory(Name = "Invoice Layout")]
        public string InvoiceLayout { get; set; }

        [ChangeHistory(Name = "Suppress Volume Information")]
        public bool SuppressVolumeInformation { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var legacyOfficeCodes = LegacyMappings.Select(x => x.LegacyIdentifier.Substring(0, 2)).ToList();

            #region AccountToBeMerged
            if (!string.IsNullOrWhiteSpace(AccountToBeMerged) && IncludeEDIInvoicingDetails == false)
                results.Add(new ValidationResult("Account to be merged is not valid.", new[] { "AccountToBeMerged" }));
            #endregion

            #region CombineSuffixes
            if (CombineSuffixes.HasValue && ConsolidateInvoicing == false)
                results.Add(new ValidationResult("Combine Suffixes cannot be used if account is not consolidated.", new[] { "CombineSuffixes" }));
            #endregion

            #region CommentLineRequiredComments
            if (!string.IsNullOrWhiteSpace(CommentLineRequiredComments) && CommentLineRequired == null)
                results.Add(new ValidationResult("Cannot add Comment Line Required Comments.", new[] { "CommentLineRequiredComments" }));
            #endregion

            #region ConsolidatedInvoiceMonth
            if (ConsolidatedInvoiceMonth == null && ConsolidateInvoicing == true && new[] { "ZE", "ZF", "ZI", "ZN", "ZP", "ZQ", "ZS", "ZT", "ZU", "ZV", "ZY", "ZZ" }.Any(o1 => legacyOfficeCodes.Any(o2 => o1 == o2)))
                results.Add(new ValidationResult("Consolidated Invoice Month must be selected.", new[] { "ConsolidatedInvoiceMonth" }));

            if (ConsolidatedInvoiceMonth != null && ConsolidateInvoicing == false)
                results.Add(new ValidationResult("Consolidated Invoice Month cannot be used if account is not consolidated.", new[] { "ConsolidatedInvoiceMonth" }));
            #endregion

            #region ConsolidatedInvoiceParameters
            if (ConsolidatedInvoiceParameters.HasValue && ConsolidateInvoicing == false)
                results.Add(new ValidationResult("Consolidated Invoice Parameters cannot be used if account is not consolidated.", new[] { "CombineSuffixes" }));
            #endregion

            #region ConsolidatedInvoicing
            IRepository repository = null;
            IValidationRepository validationRepo = null;
            IFeatureConfiguration featureConfig = null;

            try
            {
                string errorMessageConsolidated;
                if (ServiceLocator.IsLocationProviderSet)
                    try
                    {
                        repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                        validationRepo = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                        featureConfig = ServiceLocator.Current.GetInstance(typeof(IFeatureConfiguration)) as IFeatureConfiguration;
                    }
                    catch (ActivationException)
                    {
                        //do nothing
                    }

                if (!legacyOfficeCodes.All(x => new[] { "BR", "BT", "CG", "DC", "DV", "LA", "RB", "SF", "TN", "TO", "TQ" }.Contains(x)))
                {
                    if (repository != null)
                    {
                        var suffixIds = LegacyMappings.Where(x => x.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.Id).ToArray();

                        var customer = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.SecondaryCustomerProfiles);
                        var secondaryProfiles = customer.SecondaryCustomerProfiles;
                        var matchingProfiles = secondaryProfiles.Where(sp => sp.LegacyMappings
                                                                                .Any(splm =>
                                                                                        suffixIds.Contains(splm.Id)));

                        if (matchingProfiles.Any())
                        {
                            //var isoCurrency = matchingProfiles.First().ISOBillingCurrency;
                            //var billingCurrency = matchingProfiles.First().EBSCOBillingCurrency;

                            string errorMessage;

                            if (!validationRepo.ValidateConsolidatedInvoices(this, matchingProfiles.First(), out errorMessageConsolidated))
                                results.Add(new ValidationResult(string.Format(errorMessageConsolidated), null));
                        }
                    }
                }

                #endregion

                #region DiscountDays
                if ((DiscountDays ?? 0) > 0 && (CashDiscountPercent ?? 0) == 0)
                    results.Add(new ValidationResult("Discount Days is not valid.", new[] { "DiscountDays" }));
                if ((DiscountDays ?? 0) == 0 && (CashDiscountPercent ?? 0) > 0)
                    results.Add(new ValidationResult("Discount Days is not valid.", new[] { "DiscountDays" }));
                #endregion

                #region EDIFileTransmissionMethod
                if (string.IsNullOrWhiteSpace(EDIFileTransmissionMethod) && IncludeEDIInvoicingDetails)
                    results.Add(new ValidationResult("EDI File Transmission Method is required.", new[] { "EDIFileTransmissionMethod" }));
                if (!string.IsNullOrWhiteSpace(EDIFileTransmissionMethod) && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("EDI File Transmission Method is not valid.", new[] { "EDIFileTransmissionMethod" }));
                #endregion

                #region EDIForMainRenewalInvoiceOnly
                if (EDIForMainRenewalInvoiceOnly && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("EDI For Main Renewal Invoice Only is not valid.", new[] { "EDIForMainRenewalInvoiceOnly" }));
                #endregion

                #region EmailAddressesforAcknowledgements
                if (!string.IsNullOrWhiteSpace(EmailAddressesforAcknowledgements) && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("Email Addresses for Acknowledgements is not valid.", new[] { "EmailAddressesforAcknowledgements" }));
                if (string.IsNullOrWhiteSpace(EmailAddressesforAcknowledgements) && ILSFormat != null && new[] { "EBSCO Standard", "Innovative" }.Contains(ILSFormat, StringComparer.OrdinalIgnoreCase))
                    results.Add(new ValidationResult("Email Addresses for Acknowledgements is required.", new[] { "EmailAddressesforAcknowledgements" }));
                #endregion

                #region F24216 - Add EDI System
                if (featureConfig != null)
                {
                    if (featureConfig.IsAvailable(FeaturesEnum.EDISystem))
                    {
                        if (!string.IsNullOrWhiteSpace(EDISystem) && IncludeEDIInvoicingDetails == false)
                            results.Add(new ValidationResult("EDI System is not valid.", new[] { "EDISystem" }));
                        if (string.IsNullOrWhiteSpace(EDISystem) && IncludeEDIInvoicingDetails == true)
                            results.Add(new ValidationResult("EDI System is required.", new[] { "EDISystem" }));
                    }
                }
                #endregion

                #region F20178 - Add Fund Code (Client Billing info fields)
                if (featureConfig != null)
                {
                    if (featureConfig.IsAvailable(FeaturesEnum.FundCodeFields))
                    {
                        if (FundCodeRequired == 1 && !string.IsNullOrWhiteSpace(FundCodeRequiredComments))
                            results.Add(new ValidationResult("Cannot add Fund Code Required Comments.", new[] { "FundCodeRequiredComments" }));
                        if (FundCodeRequired == 1 && !string.IsNullOrWhiteSpace(FundCodeToPrintOnInvoice))
                            results.Add(new ValidationResult("Cannot add Fund Code to print on Invoice.", new[] { "FundCodeToPrintOnInvoice" }));
                        if (FundCodeRequired == 2 && FundCodeToPrintOnInvoice?.Length > 6)
                            results.Add(new ValidationResult("Fund Code to print on Invoice can not be more than 6 characters.", new[] { "FundCodeToPrintOnInvoice" }));
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(HegisNumberRequiredComments) && HegisNumbersRequired == false)
                            results.Add(new ValidationResult("Cannot add Hegis Number Required Comments.", new[] { "HegisNumberRequiredComments" }));
                        if (!string.IsNullOrWhiteSpace(HegisNumberRequiredComments) && HegisNumberRequiredComments.StartsWith("------"))
                            results.Add(new ValidationResult("Hegis Number Required Comments is invalid.", new[] { "HegisNumberRequiredComments" }));
                        if (!string.IsNullOrWhiteSpace(HegisNumberRequiredComments) &&
                            (HegisNumberRequiredComments.StartsWith("**C") || HegisNumberRequiredComments.StartsWith("**c")) &&
                            !Regex.IsMatch(HegisNumberRequiredComments, @"\*\*[Cc][123]"))
                            results.Add(new ValidationResult("Hegis Number Required Comments is invalid.", new[] { "HegisNumberRequiredComments" }));
                    }
                }
                #endregion

                #region ILSFormat
                if (string.IsNullOrWhiteSpace(ILSFormat) && IncludeEDIInvoicingDetails == true)
                    results.Add(new ValidationResult("ILS Format is required.", new[] { "ILSFormat" }));
                if (!string.IsNullOrWhiteSpace(ILSFormat) && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("ILS Format is not valid.", new[] { "ILSFormat" }));
                #endregion

                #region InvoiceTypestoInclude
                if (InvoiceTypestoInclude != null && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("Invoice Types to Include is not valid.", new[] { "InvoiceTypestoInclude" }));
                #endregion

                #region MaximumInvoiceAmount
                if ((MaximumInvoiceAmount ?? 0) > 0 && (MaximumInvoiceLineItems ?? 0) > 0)
                    results.Add(new ValidationResult("Maximum Invoice Amount and Maximum Line Items are mutually exclusive.", new[] { "MaximumInvoiceAmount" }));
                #endregion

                #region MaximumInvoiceAmountComments
                if (!string.IsNullOrWhiteSpace(MaximumInvoiceAmountComments) && (MaximumInvoiceAmount ?? 0) == 0)
                    results.Add(new ValidationResult("Cannot add Maximum Invoice Amount Comments.", new[] { "MaximumInvoiceAmountComments" }));
                #endregion

                #region MaximumInvoiceLineItems
                if ((MaximumInvoiceAmount ?? 0) > 0 && (MaximumInvoiceLineItems ?? 0) > 0)
                    results.Add(new ValidationResult("Maximum Invoice Amount and Maximum Line Items are mutually exclusive.", new[] { "MaximumInvoiceLineItems" }));
                #endregion

                #region MaximumInvoiceLineItemsComments
                if (!string.IsNullOrWhiteSpace(MaximumInvoiceLineItemsComments) && (MaximumInvoiceLineItems ?? 0) == 0)
                    results.Add(new ValidationResult("Cannot add Maximum Invoice Line Items Comments.", new[] { "MaximumInvoiceLineItemsComments" }));
                #endregion

                #region PeriodSplit
                if (PeriodSplit != null && !legacyOfficeCodes.All(x => new[] { "ZE", "ZF", "ZI", "ZN", "ZP", "ZQ", "ZS", "ZT", "ZU", "ZV", "ZY", "ZZ" }.Contains(x)))
                    results.Add(new ValidationResult("Period Split cannot be selected for this office code.", new[] { "PeriodSplit" }));
                if (PeriodSplit != null && ConsolidateInvoicing == false)
                    results.Add(new ValidationResult("Period Split cannot be used if account is not consolidated.", new[] { "PeriodSplit" }));
                #endregion

                #region ProcessImmediately
                if (ProcessImmediately && ConsolidateInvoicing == false)
                    results.Add(new ValidationResult("Process Immediately cannot be used if account is not consolidated.", new[] { "ProcessImmediately" }));
                #endregion

                #region HoldUntilCurrentRatesAvailable
                if (HoldUntilCurrentRatesAvailable && ConsolidateInvoicing == false)
                    results.Add(new ValidationResult("Hold Until Current Rates Available cannot be used if account is not consolidated.", new[] { "ProcessImmediately" }));
                #endregion

                #region SortbyISC
                if (!string.IsNullOrWhiteSpace(SortbyISC) && SortbyISC != "S" && TSCRequired == true)
                    results.Add(new ValidationResult("Sort by ISC is not valid.", new[] { "SortbyISC" }));
                #endregion

                #region SpecialInstructions
                if (!string.IsNullOrWhiteSpace(SpecialInstructions) && IncludeEDIInvoicingDetails == false)
                    results.Add(new ValidationResult("Special Instructions is not valid.", new[] { "MaximumInvoiceLineItemsComments" }));
                #endregion

                #region TSCRequiredComments
                if (!string.IsNullOrWhiteSpace(TSCRequiredComments) && TSCRequired == false)
                    results.Add(new ValidationResult("Cannot add TSC Required Comments.", new[] { "TSCRequiredComments" }));
                #endregion

                #region UseC1CommentComments
                if (!string.IsNullOrWhiteSpace(UseC1CommentComments) && UseC1Comment == false)
                    results.Add(new ValidationResult("Cannot add Use C1* Comment Comments.", new[] { "UseC1CommentComments" }));
                #endregion

                #region UseC3CommentComments
                if (!string.IsNullOrWhiteSpace(UseC3CommentComments) && UseC3Comment == false)
                    results.Add(new ValidationResult("Cannot add Use C3* Comment Comments.", new[] { "UseC3CommentComments" }));
                #endregion

                #region BreakAdjustmentsBySubscriber
                if (BreakAdjustmentsbySubscriber && OriginalInvoiceItemCount > 0)
                    results.Add(new ValidationResult("Break Adjustments by Subscriber is invalid.", new[] { "BreakAdjustmentsbySubscriber" }));
                if (BreakAdjustmentsbySubscriber && SupplementalInvoiceItemCount > 0)
                    results.Add(new ValidationResult("Break Adjustments by Subscriber is invalid.", new[] { "BreakAdjustmentsbySubscriber" }));
                #endregion

                #region F13205;
                if (featureConfig != null)
                {
                    IEnumerable<BillingLocation> billingLocations = null;
                    var CcisAddedToInvoicesProfileFeatureEnabled = featureConfig.IsAvailable(FeaturesEnum.CcisAddedToInvoicesProfile);

                    if (CcisAddedToInvoicesProfileFeatureEnabled)
                    {
                        if (IncludeInvoiceDetailReport == true && PrintInvoicesInOldFormat == true)
                            results.Add(new ValidationResult("Cannot include Invoice Detail Report if Invoice is printed in old format.", new[] { "IncludeInvoiceDetailReport" }));

                        if (PrintPageTotal == true && PrintRunningSubTotal == true)
                            results.Add(new ValidationResult("Cannot print both Running Sub-Total and Page Total on an Invoice.", new[] { "PrintPageTotal" }));

                        // if (featureConfig.IsAvailable(FeaturesEnum.ManageBillingAddresses))
                        if (featureConfig.IsAvailable("CA.F7222.US326097.BillingLocationSAPSync"))
                        {
                            if (repository != null && !IsDefault)
                            {
                                var suffixLegacyMappingIds = LegacyMappings.Where(lm => lm.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.Id);

                                billingLocations = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.BillingLocations)
                                       .BillingLocations.Where(x => x.LegacyMappings.Any(lm => suffixLegacyMappingIds.Contains(lm.Id)))
                                       .ToArray();

                                if (SplitPaymentUsePublicAdministrationVATMatrix && !billingLocations.All(x => x.CountryCode.Equals("IT")))
                                    results.Add(new ValidationResult("Public Administration VAT Matrix is only available in Italy.", new[] { "SplitPaymentUsePublicAdministrationVatMatrix" }));

                            }
                        }
                        else
                        {
                            if (SplitPaymentUsePublicAdministrationVATMatrix == true && !legacyOfficeCodes.Any(x => new[] { "ZI", "ZQ" }.Contains(x)))
                                results.Add(new ValidationResult("Public Administration VAT Matrix is only available in Italy.", new[] { "SplitPaymentUsePublicAdministrationVatMatrix" }));
                        }


                        //begin - can move to attributes when feature CA.F13205 enabled
                        if (string.IsNullOrWhiteSpace(MailInvoicesTo))
                            results.Add(new ValidationResult("Mail Invoices To is a required field.", new[] { "MailInvoicesTo" }));

                        Regex regex = new Regex(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*");
                        if (!string.IsNullOrEmpty(AlternateReplyToEmailAddressForInvoices))
                        {
                            if (AlternateReplyToEmailAddressForInvoices.Length > 100)
                                results.Add(new ValidationResult("Alternate Reply To Email Address for Invoices exceeds maximum length of 100.", new[] { "AlternateReplyToEmailAddressForInvoices" }));

                            var email = regex.Match(AlternateReplyToEmailAddressForInvoices);
                            if (email.Value.Length != AlternateReplyToEmailAddressForInvoices.Length)
                            {
                                results.Add(new ValidationResult("Alternate Reply to Email Addresses for Invoices is invalid.  Multiple emails should be seperated by a semicolon ';'", new[] { "AlternateReplyToEmailAddressForInvoices" }));
                            }
                        }

                        if (!string.IsNullOrEmpty(EmailAddressForOvernightEdits))
                        {
                            if (EmailAddressForOvernightEdits.Length > 200)
                                results.Add(new ValidationResult("Email Address for Overnight Edits exceeds maximum length of 200.", new[] { "EmailAddressForOvernightEdits" }));
                            var email = regex.Match(EmailAddressForOvernightEdits);
                            if (email.Value.Length != EmailAddressForOvernightEdits.Length)
                            {
                                results.Add(new ValidationResult("Email Addresses for Overnight Edits is invalid..  Multiple emails should be seperated by a semicolon ';'", new[] { "EmailAddressForOvernightEdits" }));
                            }
                        }
                        //end - can move to attributes when feature CA.F13205 enabled
                    }
                }
                #endregion

                if (validationRepo != null)
                {
                    string errorMessage;
                    if (!validationRepo.ValidateProfile(this, out errorMessage))
                        results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
                }

                return results;
            }
            finally
            {
                repository?.Dispose();
                validationRepo?.Dispose();
            }
        }
    }
}
