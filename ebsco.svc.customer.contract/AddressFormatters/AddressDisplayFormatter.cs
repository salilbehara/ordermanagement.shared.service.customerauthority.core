using ebsco.svc.customer.contract.LookupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ebsco.svc.customer.contract.AddressFormatters
{
    public class AddressDisplayFormatter
    {
        private IEnumerable<StatesProvincesLookup> _stateProvinces;
        private IEnumerable<CountryLookup> _countries;

        public AddressDisplayFormatter(IRepository repository)
        {
            _stateProvinces = ListCacheHelper.GetStateProvinceCodes(repository);
            _countries = ListCacheHelper.GetCountries(repository);
        }

        public string ConvertAddress<T>(T address) where T:Address
        {
            var atts = typeof(T).GetCustomAttributes<AddressFormatAttribute>();
            if (address.AddressType == CustomerAddressType.Billing)
                atts = atts.Where(x => x.AddressType == AddressFormatAttribute.AddressTypeEnum.Billing || x.AddressType == AddressFormatAttribute.AddressTypeEnum.Both);
            else if(address.AddressType == CustomerAddressType.Shipping)
                atts = atts.Where(x => x.AddressType == AddressFormatAttribute.AddressTypeEnum.Shipping || x.AddressType == AddressFormatAttribute.AddressTypeEnum.Both);

            var att = atts.FirstOrDefault(x => x.Countries.Contains(address.CountryCode)) ?? atts.First(x => x.Countries == null || x.Countries.Count() == 0);
            var format = att.FormatString
                .Replace("Attention", "0")
                .Replace("Addressee", "1")
                .Replace("Line1", "2")
                .Replace("Line2", "3")
                .Replace("City", "4")
                .Replace("StateProvince", "5")
                .Replace("Postal", "6")
                .Replace("Country", "7");

            var countryCode = _countries.FirstOrDefault(x => x.Value == address.CountryCode);
            var countryName = countryCode != null ? countryCode.Description : string.Empty;
            var stateProvinceCode = _stateProvinces.FirstOrDefault(x => x.CountryCode == address.CountryCode && x.Value == address.StateProvince);
            var stateProvinceName = stateProvinceCode != null ? stateProvinceCode.ShortName ?? stateProvinceCode.Description : address.StateProvince;

            return string.Format(format,
                address.Attention,
                address.Addressee,
                address.Address1,
                address.Address2,
                address.City,
                stateProvinceName,
                address.PostalCode,
                countryName
                ).Trim();
        }
    }
}
