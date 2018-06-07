using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.FeatureFlags;

namespace ebsco.svc.customer.contract
{
    public class LegacyMapping : IValidatableObject
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string LegacySystemName { get; set; }

        [ChangeHistory(Name = "Legacy Identifier")]
        public string LegacyIdentifier { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IsDeleted || !IsActive)
            {

                IRepository repository = null;
                IValidationRepository validationRepo = null;

                try
                {
                    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                    validationRepo = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                }
                catch (ActivationException ae)
                {

                }

                if (this.LegacySystemName == LegacySystemNames.Suffix.Name)
                {
                    if (validationRepo != null)
                    {
                        if (validationRepo.HasActiveInvoices(this))
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " has pending invoices and cannot be deleted or deactivated."));
                        }
                    }
                }

                if (repository != null)
                {
                    var customer = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.SecondaryCustomerProfiles |
                                                                        RelatedEntitiesEnum.RenewalProfiles |
                                                                        RelatedEntitiesEnum.OrderProfiles |
                                                                        RelatedEntitiesEnum.InvoiceProfiles |
                                                                        RelatedEntitiesEnum.PricingProfiles |
                                                                        RelatedEntitiesEnum.IlsProfiles |
                                                                        RelatedEntitiesEnum.CCICodingProfiles |
                                                                        RelatedEntitiesEnum.ReportingProfiles |
                                                                        RelatedEntitiesEnum.CreditsAndAdjustmentsProfiles);

                    var secondaries = customer.SecondaryCustomerProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    secondaries.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a Secondary Customer Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var renewals = customer.RenewalProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    renewals.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a Renewals Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var orders = customer.OrderProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    orders.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares an Orders Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var invoices = customer.InvoiceProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    invoices.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares an Invoice Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var pricing = customer.PricingProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    pricing.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a Pricing Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var ils = customer.IlsProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    ils.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares an ILS Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var cci = customer.CCICodingProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    cci.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a CCI Coding Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var reporting = customer.ReportingProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    reporting.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a Reporting Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });

                    var credits = customer.CreditsAndAdjustmentsProfiles.Where(x => !x.IsDefault)
                                                                        .Where(y => y.LegacyMappings.Any(z => z.LegacySystemName == "Mainframe - Suffix" &&
                                                                                                                z.LegacyIdentifier == LegacyIdentifier));

                    credits.ToList().ForEach(profile =>
                    {
                        if (profile.LegacyMappings.Where(mapping => mapping.LegacySystemName == "Mainframe - Suffix").ToList().Count > 1)
                        {
                            results.Add(new ValidationResult("Suffix " + LegacyIdentifier + " shares a Credits and Adjustments Profile with another suffix and cannot be deleted or deactivated."));
                        }
                    });
                }
            }
            return results;
        }
    }
}
