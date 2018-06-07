using ebsco.svc.customer.contract.LookupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ebsco.svc.customer.contract.AddressFormatters
{
    public class MainframeAddressFormatter
    {
        //private IListLookupService _listLookupService;
        private IEnumerable<StatesProvincesLookup> _stateProvinces;
        private IEnumerable<CountryLookup> _countries;
        private IEnumerable<JetsAddressListLookup> _jetsAddressList;
        private IEnumerable<DropAddressListLookup> _dropAddressList;
        private IEnumerable<OfficeLookup> _officeList;

        public MainframeAddressFormatter(IRepository repository )
        {
            _stateProvinces = ListCacheHelper.GetStateProvinceCodes(repository);
            _countries = ListCacheHelper.GetCountries(repository);
            _jetsAddressList = ListCacheHelper.GetJetsAddressList(repository);
            _dropAddressList = ListCacheHelper.GetDropAddressList(repository);
            _officeList = ListCacheHelper.GetOfficeList(repository);
        }

        private string GetFormat(PropertyInfo prop, Address address, string officeCode = null)
        {
            var atts = prop.GetCustomAttributes<MainframeAddressFormatAttribute>();
            if (atts.Count() == 0)
                return null;
            var att = atts.FirstOrDefault(x => x.Countries.Contains(address.CountryCode)) ?? atts.First(x => x.Countries == null || x.Countries.Count() == 0);
            var format = att.FormatString
                .Replace("Attention", "0")
                .Replace("Addressee", "1")
                .Replace("Address1", "2")
                .Replace("Address2", "3")
                .Replace("City", "4")
                .Replace("StateProvinceShortName", "5")
                .Replace("StateProvinceCode", "6")
                .Replace("PostalCode", "7")
                .Replace("CountryCode", "8")
                .Replace("CountryNameIfForeignToOffice", "9")
                .Replace("CountryName", "10");
            var stateProvinceLookup = _stateProvinces.FirstOrDefault(x => x.CountryCode == address.CountryCode && x.Value == address.StateProvince);
            var stateProvinceName = stateProvinceLookup != null ? stateProvinceLookup.ShortName ?? stateProvinceLookup.MainframeDescription : address.StateProvince;
            var stateProvinceCode = stateProvinceLookup != null ? stateProvinceLookup.Value : null;
            var country = _countries?.FirstOrDefault(x => x.Value == address.CountryCode);
            var postalCode = address?.CountryCode == "US" ? address.PostalCode.Split('-')[0] : address.PostalCode;

            var countryCode = country?.MainframeShortCode ?? country?.Value;
            var countryName = country != null ? country.MainframeDescription ?? country.Description : address.CountryCode;


            var officeIsoCountry = officeCode != null ? _officeList.First(x => x.Value == officeCode).IsoCountryCode : null;
            var addressForeignToOffice = officeIsoCountry != null && country != null && country.Value != officeIsoCountry;

            var returnstring = string.Format(format,
                address.Attention,
                address.Addressee,
                address.Address1,
                address.Address2,
                address.City,
                stateProvinceName,
                stateProvinceCode,
                postalCode,
                countryCode,
                addressForeignToOffice ? countryName : null,
                countryName
                );

            return returnstring.Trim();
        }

        public MainframeShippingAddressOverride ConvertShippingAddress(Address address)
        {
            var props = typeof(MainframeShippingAddressOverride).GetProperties().ToDictionary(x => x.Name);

            var overrideAddress = new MainframeShippingAddressOverride
            {
                Name = GetFormat(props["Name"], address),
                Line1 = GetFormat(props["Line1"], address),
                Line2 = GetFormat(props["Line2"], address),
                Line3 = GetFormat(props["Line3"], address),
                Line4 = GetFormat(props["Line4"], address),
                Line5 = GetFormat(props["Line5"], address),
                City = GetFormat(props["City"], address),
                StateProvince = GetFormat(props["StateProvince"], address),
                CountryCode = GetFormat(props["CountryCode"], address),
                PostalCode = GetFormat(props["PostalCode"], address),
            };

            return overrideAddress;
        }

        public MainframeBillingAddressOverride ConvertBillingAddress(BillingLocation address)
        {
            var props = typeof(MainframeBillingAddressOverride).GetProperties().ToDictionary(x => x.Name);
            var office = address.LegacyMappings.FirstOrDefault(x => x.LegacySystemName == LegacySystemNames.Account.Name)?.LegacyIdentifier.Substring(0, 2);

            return new MainframeBillingAddressOverride
            {
                Name = GetFormat(props["Name"], address, office),
                Line1 = GetFormat(props["Line1"], address, office),
                Line2 = GetFormat(props["Line2"], address, office),
                Line3 = GetFormat(props["Line3"], address, office),
                City = GetFormat(props["City"], address, office),
                StateProvince = GetFormat(props["StateProvince"], address, office),
                CountryCode = GetFormat(props["CountryCode"], address, office),
                PostalCode = GetFormat(props["PostalCode"], address, office),
            };
        }

        public CountryLookup ConvertCountryCode(string CACountyCode)
        {
            var country = _countries.FirstOrDefault(x => x.Value == CACountyCode);
            return country;
        }

        public JetsAddressListLookup ConvertJetsAddress(string CAOfficeCode, string CAJetsAddress)
        {
            var convertedJetsAddress = _jetsAddressList.FirstOrDefault(x => (x.Value == CAOfficeCode || x.Value.ToUpper() == "ALL") && x.Description == CAJetsAddress);
            return convertedJetsAddress;
        }

        public DropAddressListLookup ConvertDropAddress(string CAOfficeCode, string CADropAddress)
        {
            var convertedDropAddress = _dropAddressList.FirstOrDefault(x => (x.Value == CAOfficeCode || x.Value.ToUpper() == "ALL") && x.Description == CADropAddress);
            return convertedDropAddress;
        }

    }
}
