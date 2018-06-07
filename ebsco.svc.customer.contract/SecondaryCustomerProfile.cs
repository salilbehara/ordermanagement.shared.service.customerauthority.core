using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ebsco.svc.customer.contract
{
    public class SecondaryCustomerProfile : IValidatableObject, IHasLegacyMappings
    {
        public SecondaryCustomerProfile()
        {
            LegacyMappings = new List<LegacyMapping>();
            ProductTypes = new List<SecondaryCustomerProfileProductType>();
        }
        

    public int Id { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        [ChangeHistory(Name = "AKA Name")]
        public string AKAName { get; set; }

        [Required]
        [ChangeHistory(Name = "A/R Currency")]
        public string ARCurrency { get; set; }
        [ChangeHistory(Name = "Cluster 1")]
        public string Cluster1 { get; set; }
        [ChangeHistory(Name = "Cluster 2")]
        public string Cluster2 { get; set; }
        [ChangeHistory(Name = "Cluster 3")]
        public string Cluster3 { get; set; }
        [ChangeHistory(Name = "Consortia Information")]
        public string ConsortiaInformation { get; set; }
        [ChangeHistory(Name = "Cross Referenced From Account")]
        public string CrossReferencedFromAccount { get; set; }
        [ChangeHistory(Name = "Cross Referenced To Account")]
        public string CrossReferencedToAccount { get; set; }

        [Required]
        [ChangeHistory(Name = "Customer Category")]
        public string CustomerCategoryCode { get; set; }
        [ChangeHistory(Name = "Customer Class")]
        public string CustomerClass { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        [ChangeHistory(Name = "EBSCO Billing Currency")]
        public string EBSCOBillingCurrency { get; set; }
        [RegularExpression(@"(([a-zA-Z0-9_\-\.']+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*", ErrorMessage = "Email Address For E-Journal Updates is invalid.  Multiple emails should be seperated by a semicolon ';'")]
        [ChangeHistory(Name = "Email Address For E-Journal Updates")]
        public string EmailAddressForEjournalUpdates { get; set; }
        [ChangeHistory(Name = "Firm Account")]
        public string FirmFixedAccount { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        [ChangeHistory(Name = "ISO Billing Currency")]
        public string ISOBillingCurrency { get; set; }
        [ChangeHistory(Name = "Language Key")]
        public string LanguageKey { get; set; }

        [MaxLength(3)]
        [MinLength(3)]
        [ChangeHistory(Name = "Satellite Office")]
        public string SatelliteOfficeCode { get; set; }

        [MaxLength(2)]
        [ChangeHistory(Name = "Satellite Country")]
        public string SatelliteCountry { get; set; }

        [MaxLength(10)]
        [ChangeHistory(Name = "SAP Corporate Group")]
        public string SapCorporateGroup { get; set; }

        [ChangeHistory(Name = "EBSCONET Customer")]
        public bool EBSCONetCustomer { get; set; }

        [MaxLength(150)]
        [ChangeHistory(Name = "EBSCONET Customer Comments")]
        public string EBSCONetCustomerComments { get; set; }

      
        [ChangeHistory(Name = "Include In Net Publisher's Logic")]
        public bool? IncludeInNetPublishersLogic { get; set; }

        [MaxLength(20)]
        [ChangeHistory(Name = "EJS Customer")]
        public string EJSCustomer { get; set; }

        [MaxLength(21)]
        [ChangeHistory(Name = "Ingenta ID")]
        public string IngentaID { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Ingenta ID Comments")]
        public string IngentaIDComments { get; set; }

        [MaxLength(22)]
        [ChangeHistory(Name = "Athens ID")]
        public string AthensID { get; set; }
        [MaxLength(550)]
        [ChangeHistory(Name = "Athens ID Comments")]
        public string AthensIDComments { get; set; }

        [ChangeHistory(Name = "A To Z Customer")]
        public bool AToZCustomer { get; set; }

        [ChangeHistory(Name = "A To Z With Linksource")]
        public bool AToZWithLinksource { get; set; }

        [ChangeHistory(Name = "A To Z With MARC Updates")]
        public bool AToZWithMarcUpdates { get; set; }

        [ChangeHistory(Name = "Email CSR for E-Journal Updates")]
        public bool? EmailCSRForEJournalUpdates { get; set; }

        [ChangeHistory(Name = "Settlement Account")]
        public bool SettlementAccount { get; set; }

        [ChangeHistory(Name = "Subscribes to E-Packages")]
        public bool SubscribestoEPackages { get; set; }

        [ChangeHistory(Name = "Product Type")]
        public virtual List<SecondaryCustomerProfileProductType> ProductTypes { get; set; }
        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }

        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var officeCodes = LegacyMappings.Where(x => x.LegacySystemName == LegacySystemNames.Account.Name).Select(x => x.LegacyIdentifier.Substring(0, 2)).Distinct();

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

            if (repository != null)
            {
                if (Id > 0)
                {
                    var existingProfile = repository.GetSecondaryCustomerProfile(Id);
                    if (existingProfile != null && !string.IsNullOrEmpty(existingProfile.ISOBillingCurrency.Trim()) && existingProfile.ISOBillingCurrency != ISOBillingCurrency)
                        results.Add(new ValidationResult("ISO Billing Currency cannot be changed.", new[] { "ISOBillingCurrency" }));
                }
            }



            //verify EBSCOBillingCurrency is populated
            if (new[] { "AU", "BA", "FB", "JA", "KO", "MX", "NZ", "TO", "TQ", "TW", "ZE", "ZI", "ZJ", "ZN", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZX", "ZZ", "ZF", "ZY" }.Any(o1 => officeCodes.Any(o2 => o1 == o2)))
                if (string.IsNullOrWhiteSpace(EBSCOBillingCurrency))
                    results.Add(new ValidationResult("EBSCO Billing Currency is required.", new[] { "EBSCOBillingCurrency" }));

            //verify EBSCOBillingCurrency is populated
            //if (new[] { "BR", "BT", "CG", "DC", "DV", "LA", "RB", "SF", "TN" }.Any(o1 => officeCodes.Any(o2 => o1 == o2)))
            //    if (!string.IsNullOrWhiteSpace(EBSCOBillingCurrency) && !StringComparer.OrdinalIgnoreCase.Equals(EBSCOBillingCurrency, "US"))
            //        results.Add(new ValidationResult("EBSCO Billing Currency must be 'US'.", new[] { "EBSCOBillingCurrency" }));

            //verify arcurrency is valid for given EBSCOBillingCurrency
            if (EBSCOBillingCurrency != null && EBSCOBillingCurrency == "US" && ARCurrency != "US")
                results.Add(new ValidationResult("A/R Currency is not a valid selection", new[] { "ARCurrency" }));

            //verify satellite office code and satellite country is not blank for certain offices
            if (new[] { "ZU", "ZA", "ZJ", "ZN", "ZQ", "ZS", "ZT", "ZZ", "ZE", "ZX", "ZR", "ZC", "ZI", "ZP", "ZV", "ZF", "ZY", "AU", "NZ", "BA", "FB", "JA", "KO", "MX", "TW" }.Any(o1 => officeCodes.Any(o2 => o1 == o2)))
            {
                if (string.IsNullOrWhiteSpace(SatelliteOfficeCode))
                    results.Add(new ValidationResult("Satellite Office Code is required.", new[] { "SatelliteOfficeCode" }));
                if (string.IsNullOrWhiteSpace(SatelliteCountry))
                    results.Add(new ValidationResult("Satellite Country is required.", new[] { "SatelliteCountry" }));

            }


            if (new[] { "TO", "TQ" }.Any(o1 => officeCodes.Any(o2 => o1 == o2)) && (ISOBillingCurrency ?? string.Empty) == "USD")
            {
                if (!StringComparer.OrdinalIgnoreCase.Equals(SatelliteOfficeCode, "USA"))
                    results.Add(new ValidationResult("Satellite Office Code must be selected.", new[] { "SatelliteOfficeCode" }));
                if (officeCodes.Count() > 1 || !StringComparer.OrdinalIgnoreCase.Equals(officeCodes.First(), SatelliteCountry))
                    results.Add(new ValidationResult("Satellite Country must equal the Office Code.", new[] { "SatelliteCountry" }));
            }


            //verify satellite office code and satellite country are populated only for certain offices
            if (officeCodes.Any(o1 => !new[] { "ZU", "ZA", "ZJ", "ZN", "ZQ", "ZS", "ZT", "ZZ", "ZE", "ZX", "ZR", "ZC", "ZI", "ZP", "ZV", "ZF", "ZY", "AU", "NZ", "BA", "FB", "JA", "KO", "MX", "TW", "TO", "TQ" }.Any(o2 => o1 == o2)))
            {
                if (!string.IsNullOrWhiteSpace(SatelliteOfficeCode))
                    results.Add(new ValidationResult("Satellite Office Code is not available.", new[] { "SatelliteOfficeCode" }));
                if (!string.IsNullOrWhiteSpace(SatelliteCountry))
                    results.Add(new ValidationResult("Satellite Country is not available.", new[] { "SatelliteCountry" }));
            }

            if ((!string.IsNullOrWhiteSpace(SatelliteOfficeCode) && string.IsNullOrWhiteSpace(SatelliteCountry)) ||
                (string.IsNullOrWhiteSpace(SatelliteOfficeCode) && !string.IsNullOrWhiteSpace(SatelliteCountry))){
                results.Add(new ValidationResult("Satellite Office Code and Satellite Country must both be provided."));
            }


            if (!string.IsNullOrWhiteSpace(EBSCONetCustomerComments) && EBSCONetCustomer == false)
                results.Add(new ValidationResult("EBSCONET Customer Comments cannot be entered.", new[] { "EBSCONetCustomerComments" }));

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            } 

            //verify ebsco billing currency belongs to iso billing currency
            if (validationRepository != null)
            {
                if (!string.IsNullOrEmpty(ISOBillingCurrency) && !string.IsNullOrEmpty(EBSCOBillingCurrency))
                {
                    string errorMessage;
                    if (!validationRepository.HasMatchingEbscoAndISOCurrencies(ISOBillingCurrency, EBSCOBillingCurrency, out errorMessage))
                        results.Add(new ValidationResult(errorMessage));
                }
            }

            if (!IncludeInNetPublishersLogic.HasValue)
            {
                IncludeInNetPublishersLogic = true;
            }

            if (!EmailCSRForEJournalUpdates.HasValue)
            {
                EmailCSRForEJournalUpdates = true;
            }

            if (string.IsNullOrWhiteSpace(EJSCustomer))
            {
                EJSCustomer = "No";
            }

            if (featureConfig != null)
            {
                if (featureConfig.IsAvailable(FeaturesEnum.AddRemainingCCILines))
                {
                    //Verify Ingenta ID Comments cannot be entered if Ingenta ID is null
                    if (!string.IsNullOrWhiteSpace(IngentaIDComments) && string.IsNullOrWhiteSpace(IngentaID))
                        results.Add(new ValidationResult("Ingenta ID Comments cannot be entered.", new[] { "IngentaIDComments" }));

                    //Verify Athens ID Comments cannot be entered if Athens ID is null
                    if (!string.IsNullOrWhiteSpace(AthensIDComments) && string.IsNullOrWhiteSpace(AthensID))
                        results.Add(new ValidationResult("Athens ID Comments cannot be entered.", new[] { "AthensIDComments" }));
                }
            }

            return results;
        }
    }
}
