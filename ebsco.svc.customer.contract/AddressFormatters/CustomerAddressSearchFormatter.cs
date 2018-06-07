using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ebsco.svc.customer.contract.LookupItems;

namespace ebsco.svc.customer.contract.AddressFormatters
{
    public class CustomerAddressSearchFormatter
    {
        private IEnumerable<StatesProvincesLookup> _stateProvinces;
        private IEnumerable<CountryLookup> _countries;

        public CustomerAddressSearchFormatter(IRepository repository)
        {
            _stateProvinces = ListCacheHelper.GetStateProvinceCodes(repository);
            _countries = ListCacheHelper.GetCountries(repository);
        }

        public string ConvertAddress(CustomerAddressSearchResult address)
        {
            var atts = typeof(CustomerAddressSearchResult).GetCustomAttributes<AddressFormatAttribute>();
            if (address.AddressType == "Billing")
                atts = atts.Where(x => x.AddressType == AddressFormatAttribute.AddressTypeEnum.Billing || x.AddressType == AddressFormatAttribute.AddressTypeEnum.Both);
            else if (address.AddressType == "Shipping")
                atts = atts.Where(x => x.AddressType == AddressFormatAttribute.AddressTypeEnum.Shipping || x.AddressType == AddressFormatAttribute.AddressTypeEnum.Both);

            var att = atts.FirstOrDefault(x => x.Countries.Contains(address.CountryCode)) ?? atts.First(x => x.Countries == null || x.Countries.Count() == 0);
            var format = att.FormatString
                .Replace("Addressee", "0")
                .Replace("Attention", "1")
                .Replace("Address1", "2")
                .Replace("Address2", "3")
                .Replace("City", "4")
                .Replace("StateProvince", "5")
                .Replace("PostalCode", "6")
                .Replace("Country", "7");

            var countryCode = _countries.FirstOrDefault(x => x.Value == address.CountryCode);
            var countryName = countryCode != null ? countryCode.Description : string.Empty;
            var stateProvinceCode = _stateProvinces.FirstOrDefault(x => x.CountryCode == address.CountryCode && x.Value == address.StateProvince);
            var stateProvinceName = stateProvinceCode != null ? stateProvinceCode.ShortName ?? stateProvinceCode.Description : address.StateProvince;

            return string.Format(format,
                address.Addressee,
                address.Attention,
                address.Address1,
                address.Address2,
                address.City,
                stateProvinceName,
                address.PostalCode,
                countryName
                );
        }
    }
}
