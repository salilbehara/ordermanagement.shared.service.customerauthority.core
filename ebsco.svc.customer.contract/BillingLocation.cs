using CommonServiceLocator;
using ebsco.svc.customer.contract.AddressFormatters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace ebsco.svc.customer.contract
{
    public class BillingLocation : Address, IValidatableObject
    {
        public BillingLocation()
        {
            //Address = new Address();
            LegacyMappings = new List<LegacyMapping>();
        }

        public override CustomerAddressType AddressType => CustomerAddressType.Billing;

        [Required]
        public override string Addressee
        {
            get
            {
                return base.Addressee;
            }

            set
            {
                base.Addressee = value;
            }
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual MainframeBillingAddressOverride MainframeAddressOverride { get; set; }

        public virtual BillingProfile BillingProfile { get; set; }

        public MainframeBillingAddressOverride AddressDisplay { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if ((new[] { "US", "CA" }.Contains(CountryCode)) && string.IsNullOrWhiteSpace(PostalCode))
                results.Add(new ValidationResult("Postal is required.", new[] { "Postal" }));

            if (CountryCode == "US" && PostalCode != null && !Regex.Match(PostalCode, @"^\d{1,5}(\-\d{4})?$").Success)
                results.Add(new ValidationResult("Postal is not valid.", new[] { "Postal" }));

            if ((new[] { "US", "CA", "AU" }.Contains(CountryCode)) && string.IsNullOrWhiteSpace(StateProvince))
                results.Add(new ValidationResult("State is required.", new[] { "StateProvince" }));

            if (CountryCode == "CA" && PostalCode != null && !Regex.Match(PostalCode, @"(\D\d\D\s\d\D\d)").Success)
                results.Add(new ValidationResult("Postal is not valid.", new[] { "Postal" }));

            if (MainframeAddressOverride != null)
            {
                if (string.IsNullOrWhiteSpace(MainframeAddressOverride.PostalCode) && (MainframeAddressOverride.CountryCode == "US"))
                    results.Add(new ValidationResult("ZIP is required.", new[] { "Postal" }));

                if (!string.IsNullOrWhiteSpace(MainframeAddressOverride.PostalCode) && !(MainframeAddressOverride.CountryCode == "US"))
                    results.Add(new ValidationResult("ZIP is for US only.", new[] { "Postal" }));
            }


            var accountLegacyMapping = LegacyMappings.FirstOrDefault(x => x.LegacySystemName == LegacySystemNames.Account.Name);
            if (accountLegacyMapping != null && BillingProfile != null)
            {
                if (accountLegacyMapping.LegacyIdentifier.StartsWith("Z") && BillingProfile.TaxExemptNumber != null)
                    results.Add(new ValidationResult("Tax Exempt Number cannot be used for this office."));

                //VAT Number  Office != Z * Value is not null   VAT Number cannot be used for this office.
                if (BillingProfile.VATNumber != null && !accountLegacyMapping.LegacyIdentifier.StartsWith("Z"))
                    results.Add(new ValidationResult("VAT Number cannot be used for this office.", new[] { "VATNumber" }));

            }

            //GST Exempt  Billing Address Country != Canada  Value = Y   Country cannot be GST Exempt.
            if (BillingProfile.GSTExempt == true && CountryCode != "CA")
                results.Add(new ValidationResult("Country cannot be GST Exempt."));


            //QST Exempt  Billing Address Country != Canada  Value = Y   Country cannot be QST Exempt.
            if (BillingProfile.QSTExempt == true && CountryCode != "CA")
                results.Add(new ValidationResult("Country cannot be QST Exempt."));




            if (results.Count > 0)
                return results;


            IValidationRepository validator = null;
            IRepository repository = null;
            try
            {
                if (ServiceLocator.IsLocationProviderSet)
                    try
                    {
                        validator = ServiceLocator.Current.GetInstance<IValidationRepository>();
                        repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                    }
                    catch (ActivationException) { }

                /* validate the address using the tax service */
                if (validator != null)
                {
                    if (!validator.ValidateTaxAddress(this))
                        results.Add(new ValidationResult("Billing Address is not tax compliant.  City and/or Postal Code are invalid for the selected Country.", new[] { "SystemAddress" }));

                    string errorMessage;
                    if (!validator.ValidateBillingLocation(this, out errorMessage))
                        results.Add(new ValidationResult(string.Format("Billing location failed SAP validation: {0}", errorMessage), null));
                }


                if (LegacyMappings.Any(x => x.LegacySystemName == LegacySystemNames.Suffix.Name))
                {
                    if (MainframeAddressOverride == null)
                    {
                        if (repository != null)
                        {
                            var formatter = new MainframeAddressFormatter(repository);
                            var convertedAddress = formatter.ConvertBillingAddress(this);
                            if (
                                (convertedAddress.Name ?? string.Empty).Length > 30 ||
                                (convertedAddress.Line1 ?? string.Empty).Length > 30 ||
                                (convertedAddress.Line2 ?? string.Empty).Length > 30 ||
                                (convertedAddress.Line3 ?? string.Empty).Length > 30
                                )
                                results.Add(new ValidationResult("Billing Address is not mainframe compliant. Please use Mainframe Override address."));
                        }
                    }
                    else
                    {
                        /* Check if the billing address is mainframe compliant and still mainframe override address is provided  */
                        if (repository != null)
                        {
                            var formatter = new MainframeAddressFormatter(repository);
                            var convertedAddress = formatter.ConvertBillingAddress(this);
                            if (
                                (convertedAddress.Name ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line1 ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line2 ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line3 ?? string.Empty).Length <= 30
                            )
                            {
                                results.Add(new ValidationResult(
                                    "Billing Address is mainframe compliant. Please remove Mainframe Override address."));
                                return results;
                            }
                        }

                        var context = new ValidationContext(MainframeAddressOverride, serviceProvider: null, items: null);
                        Validator.TryValidateObject(MainframeAddressOverride, context, results, true);

                    }

                    if (BillingProfile != null)
                    {
                        var context = new ValidationContext(BillingProfile, serviceProvider: null, items: null);
                        Validator.TryValidateObject(BillingProfile, context, results, true);
                    }


                    if (repository == null)
                        return results;

                    if (accountLegacyMapping == null)
                        return results;

                    var suffixLegacyMapping = LegacyMappings.First(x => x.LegacySystemName == LegacySystemNames.Suffix.Name);

                    var countries = repository.GetCountries();
                    var country = countries.FirstOrDefault(x => x.Value == CountryCode);
                    if (string.IsNullOrEmpty(country?.MainframeShortCode) && MainframeAddressOverride == null)
                        results.Add(new ValidationResult("Billing Address is not mainframe compliant. Mainframe does not support the specified country.  Please use Mainframe Override Address."));
                }

                return results;
            }
            finally
            {
                validator?.Dispose();
                repository?.Dispose();
            }

        }
    }
}
