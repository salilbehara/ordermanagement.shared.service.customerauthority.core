using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;

namespace ebsco.svc.customer.contract
{
    //[KnownType(typeof(BillingLocation))]
    //[KnownType(typeof(ShippingLocation))]
    //[ServiceKnownType(typeof(BillingLocation))]
    //[ServiceKnownType(typeof(ShippingLocation))]
    public class Customer : IHasLegacyMappings, IValidatableObject
    {
        public Customer()
        {
            EbookMarcOptions = new EbookMarcOptions();
            LegacyMappings = new List<LegacyMapping>();
            BillingLocations = new List<BillingLocation>();
            ShippingLocations = new List<ShippingLocation>();
            IpAddresses = new List<CustomerIPAddress>();
            CustomerRepresentatives = new List<CustomerRepresentative>();
            PricingClassifications = new List<PricingClassification>();
        }


        public int Id { get; set; }

        [ChangeHistory(Name = "Customer Name")]
        public string Name { get; set; }


        public string ExternalId { get; set; }


        public DateTime? UpdatedAt { get; set; }


        public DateTime? CreatedAt { get; set; }

        //[DataMember]
        //public int FTECounts { get; set; }

        /// <summary>
        /// Used to store legacy mappings, including: MF 5-digit account.
        /// </summary>

        public List<LegacyMapping> LegacyMappings { get; set; }

        public List<CustomerSearchResult> RelatedAccounts { get; set; }

        public List<BillingLocation> BillingLocations { get; set; }

        public List<CustomerIPAddress> IpAddresses { get; set; }

        //[DataMember]
        //public Markets Market { get; set; }


        public bool IsInactive { get; set; }

        //[DataMember]
        //public SalesTerritories SalesTerritory { get; set; }

        [ChangeHistory(Name = "Employee")]
        public List<CustomerRepresentative> CustomerRepresentatives { get; set; }

        public List<PricingClassification> PricingClassifications { get; set; }


        public List<ShippingLocation> ShippingLocations { get; set; }


        public BillingLocation DefaultBillingLocation { get; set; }


        public ShippingLocation DefaultShippingLocation { get; set; }


        //public List<BillingProfile> BillingProfiles { get; set; }

        public List<SecondaryCustomerProfile> SecondaryCustomerProfiles { get; set; }

        public List<RenewalProfile> RenewalProfiles { get; set; }

        public List<PricingProfile> PricingProfiles { get; set; }

        public List<InvoiceProfile> InvoiceProfiles { get; set; }

        public List<OrderProfile> OrderProfiles { get; set; }

        public List<IlsProfile> IlsProfiles { get; set; }

        public List<CCICodingProfile> CCICodingProfiles { get; set; }

        public List<CreditsAndAdjustmentsProfile> CreditsAndAdjustmentsProfiles { get; set; }

        public List<ReportingProfile> ReportingProfiles { get; set; }

        public Customer ParentCustomer { get; set; }


        public virtual Address PrimaryAddress { get; set; }




        public List<Contact> Contacts { get; set; }

        public string OfficeCode { get; set; }

        public string SatelliteCode { get; set; }


        public bool IsAcademicResearchLibrary { get; set; }

        public bool ExportToAdmin { get; set; }


        public int? HoldingsID { get; set; }

        public string MarketSegmentId { get; set; }

        public string TerritoryId { get; set; }

        [ChangeHistory(Name = "Account Special Handling")]
        [MaxLength(1200)]
        public string AccountSpecialHandling { get; set; }

        [ChangeHistory(Name = "Suffix Information")]
        [MaxLength(1200)]
        public string SuffixInformation { get; set; }

        [ChangeHistory(Name = "Subscriber Information")]
        [MaxLength(1200)]
        public string SubscriberInformation { get; set; }


        //[DataMember]
        //public string FTEType { get; set; }

        //public string SalesmanCode { get; set; }

        public virtual EbookMarcOptions EbookMarcOptions { get; set; }

        public string CustomerCategoryCode { get; set; }

        [ChangeHistory(Name = "Carnegie Classification")]
        public string CarnegieClassification { get; set; }

        [ChangeHistory(Name = "Ringgold Number")]
        [Range(minimum:0,maximum:999999,ErrorMessage = "Ringgold Number should be between 0 and 999999.")]
        public int? RinggoldNumber { get; set; }

        [ChangeHistory(Name = "Pricing Classification Comments")]
        [MaxLength(1300)]
        public string PricingClassificationComment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            #region F20329;
            if (Id != -1)
            {
                if (!CustomerRepresentatives.Any(x => x.Role.Role == "CSR"))
                    results.Add(
                        new ValidationResult("Customer Service Representative is required (Employees tab).", new[] { "CustomerServiceRepresentative" }));

                if (!CustomerRepresentatives.Any(x => x.Role.Role == "REP"))
                    results.Add(
                        new ValidationResult("SSD Sales Representative is required (Employees tab).", new[] { "SSDSalesRepresentative" }));
            }
            #endregion

            if (PricingClassifications.GroupBy(x => x.CountType).Any(y => y.Count() > 1))
            {
                results.Add(new ValidationResult("FTE Types may only be used once in Pricing Classifications."));
            }

            if (!string.IsNullOrEmpty(PricingClassificationComment))
            {
                if (PricingClassificationComment.Contains("FTE TYPE COMMENT -->") || PricingClassificationComment.Contains("CARNEGIE CLASSIFICATION COMMENT -->"))
                {
                    results.Add(new ValidationResult("Please move all Account Price Classification information from comments to the appropriate fields. If the comments contain information for multiple FTE Types, a new FTE Type will need to be created."));
                }
            }

            return results;
        }
    }
}
