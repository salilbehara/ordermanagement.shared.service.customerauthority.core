using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.AddressFormatters;
using ebsco.svc.customer.contract.FeatureFlags;

namespace ebsco.svc.customer.contract
{


    public class ShippingLocation : Address, IValidatableObject, IWarning
    {
        public ShippingLocation()
        {
            //Address = new ShippingAddress();
            LegacyMappings = new List<LegacyMapping>();
            FteCounts = new List<ShippingFteCount>();
        }

        public override CustomerAddressType AddressType => CustomerAddressType.Shipping;

        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public override string Attention
        {
            get
            {
                return base.Attention;
            }

            set
            {
                base.Attention = value;
            }
        }

        public string TaxExemptId { get; set; }

        public int? TaxExemptCode { get; set; }

        public bool TaxExemptExpires { get; set; }

        public DateTime? TaxExemptExpireDate { get; set; }

        [ChangeHistory(Name = "Mainframe Override Address")]
        public virtual MainframeShippingAddressOverride MainframeAddressOverride { get; set; }
        [ChangeHistory(Name = "Jets Address")]
        public virtual JetsAddress JetsAddress { get; set; }
        [ChangeHistory(Name = "Drop Address")]
        public virtual DropAddress DropAddress { get; set; }

        [ChangeHistory(Name = "Tape Address")]
        public virtual TapeAddress TapeAddress { get; set; }

        public virtual ShippingProfile ShippingProfile { get; set; }

        public List<ShippingFteCount> FteCounts { get; set; }

        [ChangeHistory(Name = "Notify Publisher of Shipping Address Change")]
        public bool NotifyPublisherOfShippingAddressChange { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
        public List<string> Warning { get; set; }

        public MainframeShippingAddressOverride AddressDisplay { get; set; }

        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
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

            if (FteCounts?.Select(x => x.CountType).Distinct().Count() != FteCounts?.Select((x => x.CountType)).Count())
                results.Add(new ValidationResult("FTE Type cannot be selected more than once.", new[] { "Fte" }));

            if (ShippingProfile != null)
            {
                var tempGST = ShippingProfile.GSTExempt.HasValue ? (bool)ShippingProfile.GSTExempt : false;
                var tempQST = ShippingProfile.QSTExempt.HasValue ? (bool)ShippingProfile.QSTExempt : false;

                if (CountryCode != "CA" && tempGST)
                    results.Add(new ValidationResult("Country cannot be GST Exempt.", new[] { "GST Exempt" }));

                if (CountryCode != "CA" && tempQST)
                    results.Add(new ValidationResult("Country cannot be QST Exempt.", new[] { "QST Exempt" }));

                //LANGUAGE
                var accountLegacyMapping = LegacyMappings.FirstOrDefault(x => x.LegacySystemName == LegacySystemNames.Account.Name);
                if (accountLegacyMapping != null)
                {
                    if (!string.IsNullOrWhiteSpace(ShippingProfile.Language) &&
                        !accountLegacyMapping.LegacyIdentifier.StartsWith("Z") &&
                        !new[] { "AU", "BA", "FB", "JA", "KO", "NZ", "TO", "TQ", "TW" }.Contains(accountLegacyMapping.LegacyIdentifier.Substring(0, 2)))
                        results.Add(new ValidationResult("Language cannot be selected for this office.", new[] { "Language" }));

                    if (!string.IsNullOrWhiteSpace(ShippingProfile.Language) &&
                        //!new[] { "DU - Dutch", "EN - Englisth", "FR - French", "GE - German", "IT - Italian", "PR - Portuguese", "SO - South African", "SP - Spanish", "TU - Turkish" }.Contains(ShippingProfile.Language))
                        !new[] { "DU", "EN", "FR", "GE", "IT", "PR", "SO", "SP", "TU" }.Contains(ShippingProfile.Language))
                        results.Add(new ValidationResult("Language code is invalid.", new[] { "Language" }));

                    if (ShippingProfile != null)
                    {
                        if (accountLegacyMapping.LegacyIdentifier.StartsWith("Z") && !string.IsNullOrEmpty(ShippingProfile.TaxExemptNumber))
                            results.Add(new ValidationResult("Tax Exempt Number cannot be used for this office."));

                        //VAT Number  Office != Z * Value is not null   VAT Number cannot be used for this office.
                        if (!string.IsNullOrEmpty(ShippingProfile.VATNumber) && !accountLegacyMapping.LegacyIdentifier.StartsWith("Z"))
                            results.Add(new ValidationResult("VAT Number cannot be used for this office.", new[] { "VATNumber" }));
                    }
                }

                //ITEM FORMATS
                var ItemFormat1Thru6 = new List<string>();

                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat1))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat1);
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat2))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat2);
                    if (ItemFormat1Thru6.Distinct().Count() != ItemFormat1Thru6.Count())
                        results.Add(new ValidationResult("Item Formats cannot be selected more than once.", new[] { "ItemFormat2" }));
                }


                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat3))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat3);
                    if (ItemFormat1Thru6.Distinct().Count() != ItemFormat1Thru6.Count())
                        results.Add(new ValidationResult("Item Formats cannot be selected more than once.", new[] { "ItemFormat3" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat4))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat4);
                    if (ItemFormat1Thru6.Distinct().Count() != ItemFormat1Thru6.Count())
                        results.Add(new ValidationResult("Item Formats cannot be selected more than once.", new[] { "ItemFormat4" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat5))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat5);
                    if (ItemFormat1Thru6.Distinct().Count() != ItemFormat1Thru6.Count())
                        results.Add(new ValidationResult("Item Formats cannot be selected more than once.", new[] { "ItemFormat5" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.ItemFormat6))
                {
                    ItemFormat1Thru6.Add(ShippingProfile.ItemFormat6);
                    if (ItemFormat1Thru6.Distinct().Count() != ItemFormat1Thru6.Count())
                        results.Add(new ValidationResult("Item Formats cannot be selected more than once.", new[] { "ItemFormat6" }));
                }

                //STANDARD FORMATS
                var StandardFormat1Thru6 = new List<string>();

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat1))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat1);
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat1))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat1" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat2))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat2);
                    if (StandardFormat1Thru6.Distinct().Count() != StandardFormat1Thru6.Count())
                        results.Add(new ValidationResult("Standard Formats cannot be selected more than once.", new[] { "StandardFormat2" }));
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat2))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat2" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat3))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat3);
                    if (StandardFormat1Thru6.Distinct().Count() != StandardFormat1Thru6.Count())
                        results.Add(new ValidationResult("Standard Formats cannot be selected more than once.", new[] { "StandardFormat3" }));
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat3))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat3" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat4))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat4);
                    if (StandardFormat1Thru6.Distinct().Count() != StandardFormat1Thru6.Count())
                        results.Add(new ValidationResult("Standard Formats cannot be selected more than once.", new[] { "StandardFormat4" }));
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat4))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat4" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat5))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat5);
                    if (StandardFormat1Thru6.Distinct().Count() != StandardFormat1Thru6.Count())
                        results.Add(new ValidationResult("Standard Formats cannot be selected more than once.", new[] { "StandardFormat5" }));
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat5))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat5" }));
                }

                if (!string.IsNullOrWhiteSpace(ShippingProfile.StandardFormat6))
                {
                    StandardFormat1Thru6.Add(ShippingProfile.StandardFormat6);
                    if (StandardFormat1Thru6.Distinct().Count() != StandardFormat1Thru6.Count())
                        results.Add(new ValidationResult("Standard Formats cannot be selected more than once.", new[] { "StandardFormat6" }));
                    if (ItemFormat1Thru6.Contains(ShippingProfile.StandardFormat6))
                        results.Add(new ValidationResult("Format cannot be selected as both Standard and Item Format.", new[] { "StandardFormat6" }));
                }

                //RATE CLASS
                if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Institution) &&
                    ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Individual))
                    results.Add(new ValidationResult("Individual and Institution are mutually exclusive.", new[] { "RateClass" }));

                if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularEducator) &&
                    ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialEducator))
                    results.Add(new ValidationResult("Special Educator and Regular Educator are mutually exclusive.", new[] { "RateClass" }));

                if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularProfessional) &&
                    ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialProfessional))
                    results.Add(new ValidationResult("Special Professional and Regular Professional are mutually exclusive.", new[] { "RateClass" }));

                if ((ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialEducator)) &&
                    (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularProfessional) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialProfessional) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Field) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Military)))
                    results.Add(new ValidationResult("Rate Class selection is mutually exclusive.", new[] { "RateClass" }));

                if ((ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularProfessional) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialProfessional)) &&
                    (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Field) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Military)))
                    results.Add(new ValidationResult("Rate Class selection is mutually exclusive.", new[] { "RateClass" }));

                if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Field) &&
                    (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Military) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialProfessional) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularProfessional)))
                    results.Add(new ValidationResult("Rate Class selection is mutually exclusive.", new[] { "RateClass" }));

                if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Military) &&
                    (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularEducator) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Field) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.SpecialProfessional) ||
                        ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.RegularProfessional)))
                    results.Add(new ValidationResult("Rate Class selection is mutually exclusive.", new[] { "RateClass" }));


                #region Postage
                if (!string.IsNullOrEmpty(ShippingProfile.Postage))
                {
                    string countryCode = CountryCode;
                    bool isAlternateShippingAddress = false;

                    if (JetsAddress != null)
                    {
                        countryCode = JetsAddress.CountryCode;
                        isAlternateShippingAddress = true;
                    }
                    else if (DropAddress != null)
                    {
                        countryCode = DropAddress.CountryCode;
                        isAlternateShippingAddress = true;
                    }

                    if (ShippingProfile.Postage == " " && countryCode != "US")
                    {
                        results.Add(isAlternateShippingAddress
                            ? new ValidationResult("US postage may not be valid based on alternate shipping address.",
                                new[] { "Postage" })
                            : new ValidationResult("US postage may not be valid based on shipping address.",
                                new[] { "Postage" }));
                    }

                    if (ShippingProfile.Postage != " " && countryCode == "US")
                    {
                        results.Add(isAlternateShippingAddress
                            ? new ValidationResult("Postage must be US based on alternate shipping address.",
                                new[] { "Postage" })
                            : new ValidationResult("Postage must be US based on shipping address.",
                                new[] { "Postage" }));
                    }
                }
                #endregion

            }

            #region JetsAddress.JetsServiceChargePercent
            if (JetsAddress != null)
            {
                var accountLegacyMapping = LegacyMappings.FirstOrDefault(x => x.LegacySystemName == "Mainframe - Account");
                if (accountLegacyMapping != null)
                {
                    if ((JetsAddress.JetsServiceChargePercent > 0m) &&
                        (!new[] { "AU", "BA", "FB", "JA", "KO", "MX", "TW", "ZE", "ZF", "ZI", "ZJ", "ZN", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZX", "ZY", "ZZ" }.Contains(accountLegacyMapping.LegacyIdentifier.Substring(0, 2))))
                        results.Add(new ValidationResult("JETS Service Charge Percent cannot be used for this office.", new[] { "JetsServiceChargePercent" }));
                }
            }
            #endregion

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



                //var context = new ValidationContext(Address, serviceProvider: null, items: null);
                //var result = Validator.TryValidateObject(Address, context, results, true);
                //if(!result)
                //    return results;

                //IRepository repository = null;
                ////IListLookupService lookupService = null;
                //if (ServiceLocator.IsLocationProviderSet)
                //    try
                //    {
                //        //repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                //        //lookupService = ServiceLocator.Current.GetInstance(typeof(IListLookupService)) as IListLookupService;
                //    }
                //    catch (ActivationException)
                //    {
                //        //do nothing
                //    }

                /* validate the address using the tax service */
                if (validator != null)
                {
                    if (!validator.ValidateTaxAddress(this))
                        results.Add(new ValidationResult("Shipping Address is not tax compliant.  City and/or Postal Code are invalid for the selected Country.", new[] { "SystemAddress" }));
                }

                if (LegacyMappings.Any(x => x.LegacySystemName == LegacySystemNames.Subscriber.Name))
                {
                    if (MainframeAddressOverride == null)
                    {
                        if (LegacyMappings.Any(x => x.LegacySystemName == LegacySystemNames.Subscriber.Name))
                        {
                            if (repository != null)
                            {
                                var formatter = new MainframeAddressFormatter(repository);
                                var convertedAddress = formatter.ConvertShippingAddress(this);
                                if (
                                    (convertedAddress.Name ?? string.Empty).Length > 30 ||
                                    (convertedAddress.Line1 ?? string.Empty).Length > 30 ||
                                    (convertedAddress.Line2 ?? string.Empty).Length > 30 ||
                                    (convertedAddress.Line3 ?? string.Empty).Length > 30 ||
                                    (convertedAddress.Line4 ?? string.Empty).Length > 30
                                    )
                                    results.Add(new ValidationResult("Shipping Address is not mainframe compliant. Please use Mainframe Override address."));
                            }
                        }
                    }
                    else
                    {
                        /* Check if the shipping address is mainframe compliant and still mainframe override address is provided  */
                        if (repository != null)
                        {
                            var formatter = new MainframeAddressFormatter(repository);
                            var convertedAddress = formatter.ConvertShippingAddress(this);
                            if (
                                (convertedAddress.Name ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line1 ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line2 ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line3 ?? string.Empty).Length <= 30 &&
                                (convertedAddress.Line4 ?? string.Empty).Length <= 30
                            )
                            {
                                results.Add(new ValidationResult(
                                    "Shipping Address is mainframe compliant. Please remove Mainframe Override address."));
                                return results;
                            }
                        }

                        var context = new ValidationContext(MainframeAddressOverride, serviceProvider: null, items: null);
                        Validator.TryValidateObject(MainframeAddressOverride, context, results, true);

                    }

                    if (TapeAddress != null)
                    {
                        var context = new ValidationContext(TapeAddress, serviceProvider: null, items: null);
                        Validator.TryValidateObject(TapeAddress, context, results, true);
                    }

                    if (JetsAddress != null)
                    {
                        var context = new ValidationContext(JetsAddress, serviceProvider: null, items: null);
                        Validator.TryValidateObject(JetsAddress, context, results, true);
                    }

                    if (DropAddress != null)
                    {
                        var context = new ValidationContext(DropAddress, serviceProvider: null, items: null);
                        Validator.TryValidateObject(DropAddress, context, results, true);
                    }

                    if (ShippingProfile != null)
                    {
                        var context = new ValidationContext(ShippingProfile, serviceProvider: null, items: null);
                        Validator.TryValidateObject(ShippingProfile, context, results, true);
                    }

                    if (LegacyMappings.Count > 0)
                    {
                        if (repository == null)
                            return results;

                        var accountLegacyMapping = LegacyMappings.FirstOrDefault(x => x.LegacySystemName == LegacySystemNames.Account.Name);
                        if (accountLegacyMapping == null)
                            return results;

                        var subcodeLegacyMapping = LegacyMappings.FirstOrDefault(x => x.LegacySystemName == LegacySystemNames.Subscriber.Name);

                        if (subcodeLegacyMapping != null)
                        {
                            if (subcodeLegacyMapping.LegacyIdentifier.Length < 10)
                            {
                                results.Add(new ValidationResult("Subscriber Mapping is not 2 character long.", new[] { "Subscriber Code" }));
                            }

                            var existingCustomer = repository.GetCustomer(CustomerId, RelatedEntitiesEnum.ShippingLocations);
                            foreach (var location in existingCustomer.ShippingLocations.Where(x => x.Id != Id && x.LegacyMappings.Any(alm => alm.Id == accountLegacyMapping.Id)))
                            {
                                if (location.LegacyMappings.Any(x => x.LegacySystemName == LegacySystemNames.Subscriber.Name && x.LegacyIdentifier == subcodeLegacyMapping.LegacyIdentifier))
                                {
                                    results.Add(new ValidationResult("Subscriber is already mapped to an existing address.", new[] { "Subscriber Code" }));
                                    break;
                                }
                            }

                            var countries = repository.GetCountries();
                            var country = countries.FirstOrDefault(x => x.Value == CountryCode);
                            if (string.IsNullOrEmpty(country?.MainframeShortCode) && MainframeAddressOverride == null)
                                results.Add(new ValidationResult("Shipping Address is not mainframe compliant. Mainframe does not support the specified country.  Please use Mainframe Override Address."));
                        }
                    }

                    if (ShippingProfile != null)
                    {
                        if (!string.IsNullOrWhiteSpace(ShippingProfile.VATCountryCode) && !LegacyMappings[0].LegacyIdentifier.StartsWith("Z"))
                            results.Add(new ValidationResult("VAT Country Code cannot be selected for this office.", new[] { "VATCountryCode" }));
                    }

                    return results;
                }
                else
                {
                    if (TapeAddress != null)
                    {
                        results.Add(new ValidationResult("Tape Address cannot be provided without a subscriber code.", new[] { "Tape Address" }));
                    }
                }
                return results;
            }
            finally
            {
                validator?.Dispose();
                repository?.Dispose();
            }
        }

        public List<string> WarningValidation()
        {

            List<string> warnings = new List<string>();

            IRepository repository = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                }
                catch (ActivationException)
                {
                    //do nothing
                }

            try
            {
                if (LegacyMappings.Any(x => x.LegacySystemName == LegacySystemNames.Subscriber.Name))
                {
                    if (TapeAddress != null)
                    {
                        if (repository != null)
                        {
                            if (MainframeAddressOverride == null)
                            {
                                var formatter = new MainframeAddressFormatter(repository);
                                var convertedAddress = formatter.ConvertShippingAddress(this);
                                if (
                                    (convertedAddress.Name ?? string.Empty).Length <= 24 &&
                                    (convertedAddress.Line1 ?? string.Empty).Length <= 24 &&
                                    (convertedAddress.Line2 ?? string.Empty).Length <= 24 &&
                                    (convertedAddress.Line3 ?? string.Empty).Length <= 24 &&
                                    (convertedAddress.Line4 ?? string.Empty).Length <= 24
                                    )
                                {
                                    warnings.Add("Shipping Address is tape compliant. Please remove Tape address if it is no longer needed.");
                                }
                            }
                            else
                            {
                                if (
                                   (MainframeAddressOverride.Name ?? string.Empty).Length <= 24 &&
                                   (MainframeAddressOverride.Line1 ?? string.Empty).Length <= 24 &&
                                   (MainframeAddressOverride.Line2 ?? string.Empty).Length <= 24 &&
                                   (MainframeAddressOverride.Line3 ?? string.Empty).Length <= 24 &&
                                   (MainframeAddressOverride.Line4 ?? string.Empty).Length <= 24 &&
                                   (MainframeAddressOverride.Line5 ?? string.Empty).Length <= 24
                                   )
                                {
                                    warnings.Add("Mainframe Override Address is tape compliant. Please remove Tape address if it is no longer needed.");
                                }
                            }

                        }
                    }

                    if (ShippingProfile != null)
                    {
                        var tempGST = ShippingProfile.GSTExempt.HasValue ? (bool)ShippingProfile.GSTExempt : false;
                        var tempQST = ShippingProfile.QSTExempt.HasValue ? (bool)ShippingProfile.QSTExempt : false;

                        if (string.IsNullOrWhiteSpace(ShippingProfile.VATCountryCode) && LegacyMappings[0].LegacyIdentifier.StartsWith("Z"))
                            warnings.Add("VAT Country Code not selected.");

                        //if (!string.IsNullOrEmpty(ShippingProfile?.Postage))
                        //{

                        //    if (new[] { " " }.Contains(ShippingProfile.Postage) && CountryCode != "US")
                        //    {
                        //        warnings.Add("US postage may not be valid based on shipping address.");
                        //    }

                        //    if (new[] { "F" }.Contains(ShippingProfile.Postage) && (CountryCode == "US" || CountryCode == "CA"))
                        //    {
                        //        warnings.Add("Foreign postage may not be valid based on shipping address.");
                        //    }

                        //    if (new[] { "P" }.Contains(ShippingProfile.Postage) && (CountryCode == "US" || CountryCode == "CA"))
                        //    {
                        //        warnings.Add("Pan-American postage may not be valid based on shipping address.");
                        //    }

                        //    if (new[] { "C" }.Contains(ShippingProfile.Postage) && CountryCode != "CA")
                        //    {
                        //        warnings.Add("Canadian postage may not be valid based on shipping address.");
                        //    }

                        //    if (!new[] { "C" }.Contains(ShippingProfile.Postage) && CountryCode == "CA")
                        //    {
                        //        warnings.Add("Non-Canadian postage may not be valid based on shipping address.");
                        //    }

                        //}
                        //var flag = featureConfig.IsAvailable(FeaturesEnum.)
                        //_log.

                        if (!string.IsNullOrEmpty(ShippingProfile?.Postage))
                        {
                            string countryCode = CountryCode;
                            bool isAlternateShippingAddress = false;

                            if (JetsAddress != null)
                            {
                                countryCode = JetsAddress.CountryCode;
                                isAlternateShippingAddress = true;
                            }
                            else if (DropAddress != null)
                            {
                                countryCode = DropAddress.CountryCode;
                                isAlternateShippingAddress = true;
                            }

                            if (ShippingProfile.Postage == "C" && countryCode != "CA")
                            {
                                warnings.Add(isAlternateShippingAddress ? "Canadian postage may not be valid based on alternate shipping address." : "Canadian postage may not be valid based on shipping address.");
                            }

                            if (ShippingProfile.Postage == "F" && countryCode == "CA")
                            {
                                warnings.Add(isAlternateShippingAddress ? "Foreign postage may not be valid based on alternate shipping address." : "Foreign postage may not be valid based on shipping address.");
                            }

                            if (ShippingProfile.Postage == "P" && countryCode == "CA")
                            {
                                warnings.Add(isAlternateShippingAddress ? "Pan-American postage may not be valid based on alternate shipping address." : "Pan-American postage may not be valid based on shipping address.");
                            }
                        }
                        if (!string.IsNullOrEmpty(ShippingProfile?.Postage))
                        {

                            if (new[] { " " }.Contains(ShippingProfile.Postage) && CountryCode != "US")
                            {
                                warnings.Add("US postage may not be valid based on shipping address.");
                            }

                            if (new[] { "F" }.Contains(ShippingProfile.Postage) && (CountryCode == "US" || CountryCode == "CA"))
                            {
                                warnings.Add("Foreign postage may not be valid based on shipping address.");
                            }

                            if (new[] { "P" }.Contains(ShippingProfile.Postage) && (CountryCode == "US" || CountryCode == "CA"))
                            {
                                warnings.Add("Pan-American postage may not be valid based on shipping address.");
                            }

                            if (new[] { "C" }.Contains(ShippingProfile.Postage) && CountryCode != "CA")
                            {
                                warnings.Add("Canadian postage may not be valid based on shipping address.");
                            }

                            if (!new[] { "C" }.Contains(ShippingProfile.Postage) && CountryCode == "CA")
                            {
                                warnings.Add("Non-Canadian postage may not be valid based on shipping address.");
                            }

                        }

                        if (!ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Individual) &&
                            new[] { "CD", "CI", "EN", "GD", "HD", "IN", "LN", "MN", "PR", "SN", "XI" }.Contains(ShippingProfile.CustomerCategory))
                        {
                            warnings.Add("Rate Class selection does not match Customer Category.");
                        }

                        if (ShippingProfile.RateClass.HasFlag(ShippingProfile.RateClassEnum.Individual) &&
                            !new[] { "CD", "CI", "EN", "GD", "HD", "IN", "LN", "MN", "PR", "SN", "XI" }.Contains(ShippingProfile.CustomerCategory))
                        {
                            warnings.Add("Rate Class selection does not match Customer Category.");
                        }

                        //POSTAGE
                        if (ShippingProfile.Postage != "C")
                        {
                            if (CountryCode == "CA" && tempGST == false)
                                warnings.Add("Must be GST Exempt for Postage Code.");
                        }

                        if (ShippingProfile.Postage != "C")
                        {
                            if (CountryCode == "CA" && tempQST == false)
                                warnings.Add("Must be QST Exempt for Postage Code.");
                        }
                    }

                    if (TapeAddress == null && JetsAddress == null && DropAddress == null)
                    {
                        if (MainframeAddressOverride == null)
                        {
                            if (repository != null)
                            {
                                var formatter = new MainframeAddressFormatter(repository);
                                var convertedAddress = formatter.ConvertShippingAddress(this);

                                if (    (convertedAddress.Name ?? string.Empty).Length > 24 ||
                                        (convertedAddress.Line1 ?? string.Empty).Length > 24 ||
                                        (convertedAddress.Line2 ?? string.Empty).Length > 24 ||
                                        (convertedAddress.Line3 ?? string.Empty).Length > 24 ||
                                        (convertedAddress.Line4 ?? string.Empty).Length > 24
                                   )
                                        warnings.Add("Shipping Address is not tape compliant. Please enter a Tape address if one is needed.");
                            }
                        }
                    }
                }

                if (TapeAddress == null && JetsAddress == null && DropAddress == null)
                {
                    if (repository != null)
                    {
                        if (MainframeAddressOverride != null)
                        {
                            if (
                               (MainframeAddressOverride.Name ?? string.Empty).Length > 24 ||
                               (MainframeAddressOverride.Line1 ?? string.Empty).Length > 24 ||
                               (MainframeAddressOverride.Line2 ?? string.Empty).Length > 24 ||
                               (MainframeAddressOverride.Line3 ?? string.Empty).Length > 24 ||
                               (MainframeAddressOverride.Line4 ?? string.Empty).Length > 24 ||
                               (MainframeAddressOverride.Line5 ?? string.Empty).Length > 24
                               )
                            {
                                warnings.Add("Mainframe Override Address is not tape compliant. Please enter a Tape address if one is needed.");
                            }

                        }

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
