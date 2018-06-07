using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ebsco.svc.customer.contract
{
    public class RenewalProfile : IValidatableObject, IHasLegacyMappings
    {
        public RenewalProfile()
        {
            LegacyMappings = new List<LegacyMapping>();
        }

        public enum RenewalMonthsEnum
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
            December = 12
        }

        public int Id { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        [ChangeHistory(Name = "Number of Renewal Copies")]
        public int NumberRenewalCopies { get; set; }
        [ChangeHistory(Name = "Renewal Schedule")]
        public RenewalMonthsEnum? RenewalSchedule { get; set; }
        [ChangeHistory(Name = "Renewal Cycle")]
        public string RenewalCycle { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Renewal Information")]
        public string RenewalInformation { get; set; }

        [MaxLength(250)]
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Address to Receive Renewals is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Address to Receive Renewals")]
        public string EmailAddressToReceiveRenewals { get; set; }
        [ChangeHistory(Name = "Uses EBSCONET Renewals")]
        public bool UsesEbsconetForRenewals { get; set; }
        [ChangeHistory(Name = "Uses EBSCONET ePackage Renewals (EPR)")]
        public bool UsesEbsconetEpackageRenewals { get; set; }

        [ChangeHistory(Name = "Print Net Title Markup (NTM) Flag On Renewal List")]
        public bool PrintNetTitleMarkUpFlagOnRenewalList { get; set; }

        [ChangeHistory(Name = "Include Access Only Titles On Renewals")]
        public bool IncludeAccessOnlyTitlesOnRenewals { get; set; }
        [ChangeHistory(Name = "Include Purchase Titles On Renewals")]
        public bool IncludePurchaseTitlesOnRenewals { get; set; }

        [ChangeHistory(Name = "Mail Renewals To")]
        public string MailRenewalsTo { get; set; }

        [ChangeHistory(Name = "Mail Renewals To Comments")]
        public string MailRenewalsToComments { get; set; }
        [ChangeHistory(Name = "Renewal Copy to Email")]
        public string RenewalsCopyToMail { get; set; }
        [ChangeHistory(Name = "Multiple Year Rate for Renewals")]
        public string MultipleYearRateForRenewals { get; set; }
        [ChangeHistory(Name = "Multiple Year Titles for Renewals")]
        public string MultipleYearTitlesForRenewals { get; set; }

        [ChangeHistory(Name = "Renewal Order")]
        public string RenewalOrder { get; set; }
        [ChangeHistory(Name = "Produce Renewal as a Payment Document")]
        public bool ProduceRenewalAsAPaymentDocument { get; set; }

        [ChangeHistory(Name = "Payment Document Heading")]
        public string PaymentDocumentHeading { get; set; }


        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        public string Description { get; set; }

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


            IEnumerable<SecondaryCustomerProfile> secondaryProfiles = null;
            IEnumerable<ShippingLocation> ActiveZZSubscriber = null;
            if (repository != null)
            {
                var suffixLegacyMappingIds = LegacyMappings.Where(lm => lm.LegacySystemName == LegacySystemNames.Suffix.Name).Select(x => x.Id);

                secondaryProfiles = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.SecondaryCustomerProfiles)
                    .SecondaryCustomerProfiles
                    .Where(scp => scp.LegacyMappings.Any(pplm => suffixLegacyMappingIds.Contains(pplm.Id)));

                ActiveZZSubscriber = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.ShippingLocations)
                    .ShippingLocations.Where(x => x.LegacyMappings.Exists(lm => lm.LegacySystemName == LegacySystemNames.Subscriber.Name && lm.LegacyIdentifier.Substring(8, 2) == "ZZ") && x.IsActive)
                    .ToList();
            }

            if (UsesEbsconetForRenewals)
            {
                if (secondaryProfiles != null)
                {
                    if (secondaryProfiles.Any(x => x.EBSCONetCustomer == false))
                        results.Add(new ValidationResult("Cannot use EBSCONET for Renewals if Customer is not set up for EBSCONET", new[] { "EBSCONetCustomer" }));
                }
            }

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }
            #region F17008;

            if (!String.IsNullOrEmpty(MailRenewalsToComments) && String.IsNullOrEmpty(MailRenewalsTo))
                results.Add(new ValidationResult("Mail Renewals To is not selected.", new[] { "MailRenewalsTo" }));

            if (!String.IsNullOrEmpty(MailRenewalsToComments) && MailRenewalsToComments.Length > 500)
                results.Add(new ValidationResult("Mail Renewals To Comments length cannot be greater than 500."));


            if (!String.IsNullOrEmpty(PaymentDocumentHeading) && PaymentDocumentHeading.Length > 30)
                results.Add(new ValidationResult("Payment Document Heading length cannot be greater than 30."));


            if (!String.IsNullOrEmpty(PaymentDocumentHeading) && ProduceRenewalAsAPaymentDocument == false)
                results.Add(new ValidationResult("Heading is not valid if Renewal is not set up as Payment Document."));



            //   if (UsesEbsconetEpackageRenewals == true && UsesEbsconetForRenewals == true)
            //    results.Add(new ValidationResult("EBSCONET ePackage Renewals (EPR) and EBSCONET Renewals are mutually exclusive."));


            if (UsesEbsconetEpackageRenewals)
            {
                if (secondaryProfiles != null)
                {
                    if (secondaryProfiles.Any(x => x.EBSCONetCustomer == false))
                        results.Add(new ValidationResult("Cannot use EBSCONET ePackage Renewals (EPR) if Customer is not set up for EBSCONET.", new[] { "EBSCONetCustomer" }));
                }
            }
            // if (MailRenewalsTo == "ZZ Subscriber" && shippingLocation != shippingLocation.Where(x => x.LegacyMappings.First(lm => lm.LegacySystemName == LegacySystemName.Subscriber).LegacyIdentifier.Reverse().ToString().Substring(0, 2).ToLower().Equals("zz") && x.IsActive))

            //  results.Add(new ValidationResult("Subscriber Code ZZ is not active.", new[] { "MailRenewalsTo" }));
            if (MailRenewalsTo == "ZZ Subscriber" && ActiveZZSubscriber.Count() == 0)
                results.Add(new ValidationResult("Subscriber Code ZZ is not active.", new[] { "MailRenewalsTo" }));
            #endregion
            return results;
        }
    }
}