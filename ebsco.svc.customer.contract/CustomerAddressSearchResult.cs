using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using ebsco.svc.customer.contract.AddressFormatters;
using CommonServiceLocator;

namespace ebsco.svc.customer.contract
{
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{City} {StateProvince} {PostalCode}\n{Country}")] //DEFAULT FORMAT
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "US" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{City}, {StateProvince} {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "CA" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{City} {StateProvince}  {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "BR", "NG", "PG", "VE" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{City} {PostalCode} {StateProvince}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "BT", "BW", "KH", "TD", "EG", "FJ", "GA", "GD", "IN", "MV", "NZ", "PK", "LK", "SH", "SR", "TW", "TK", "TT", "VN" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{StateProvince} {City} {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "MG", "SY" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{StateProvince} {PostalCode} {City}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "AD", "AL", "AM", "AR", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CL", "CR", "CV", "CY", "CZ", "DE", "DK", "DZ", "EC", "EE", "ES", "ET", "FI", "FO", "FR", "GF", "GL", "GN", "GP",
                                              "GQ", "GR", "GT", "GW", "HN", "HR", "HT", "HU", "IL", "IR", "IS", "IT", "KG", "KW", "LA", "LI", "LR", "LT", "LU", "MA", "MC", "MD", "ME", "MK", "MN", "MQ", "MX", "MY", "MZ", "NC",
                                              "NI", "NL", "NO", "OM", "PA", "PF", "PH", "PL", "PM", "PT", "PY", "RE", "RO", "RS", "SD", "SE", "SI", "SJ", "SK", "SM", "SN", "SV", "TF", "TJ", "TM", "TN", "TR", "TZ", "UY", "UZ",
                                              "VA", "WF", "YT", "ZM" }, FormatString = "{Addressee}\n{Attention}\n{Address1}\n{Address2}\n{PostalCode} {City} {StateProvince}\n{Country}")]

    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{City} {StateProvince} {PostalCode}\n{Country}")] //DEFAULT FORMAT
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "US" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{City}, {StateProvince} {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "CA" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{City} {StateProvince}  {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "BR", "NG", "PG", "VE" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{City} {PostalCode} {StateProvince}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "BT", "BW", "KH", "TD", "EG", "FJ", "GA", "GD", "IN", "MV", "NZ", "PK", "LK", "SH", "SR", "TW", "TK", "TT", "VN" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{StateProvince} {City} {PostalCode}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "MG", "SY" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{StateProvince} {PostalCode} {City}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "AD", "AL", "AM", "AR", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CL", "CR", "CV", "CY", "CZ", "DE", "DK", "DZ", "EC", "EE", "ES", "ET", "FI", "FO", "FR", "GF", "GL", "GN", "GP",
                                              "GQ", "GR", "GT", "GW", "HN", "HR", "HT", "HU", "IL", "IR", "IS", "IT", "KG", "KW", "LA", "LI", "LR", "LT", "LU", "MA", "MC", "MD", "ME", "MK", "MN", "MQ", "MX", "MY", "MZ", "NC",
                                              "NI", "NL", "NO", "OM", "PA", "PF", "PH", "PL", "PM", "PT", "PY", "RE", "RO", "RS", "SD", "SE", "SI", "SJ", "SK", "SM", "SN", "SV", "TF", "TJ", "TM", "TN", "TR", "TZ", "UY", "UZ",
                                              "VA", "WF", "YT", "ZM" }, FormatString = "{Attention}\n{Addressee}\n{Address1}\n{Address2}\n{PostalCode} {City} {StateProvince}\n{Country}")]
   

    public class CustomerAddressSearchResult: CustomerSearchResult
    {

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string CountryCode { get; set; }

        public string Country { get; set; }

        public string Addressee { get; set; }

        public string Attention { get; set; }

        public string PostalCode { get; set; }

        public string AddressType { get; set; }

        //public string DisplayAddress
        //{
        //    get
        //    {
        //        IListLookupService lookupService = null;
        //        if (ServiceLocator.IsLocationProviderSet)
        //            try
        //            {
        //                lookupService = ServiceLocator.Current.GetInstance(typeof(IListLookupService)) as IListLookupService;
        //            }
        //            catch (ActivationException)
        //            {
        //                return string.Empty;
        //            }

        //        var formatter = new CustomerAddressSearchFormatter(lookupService);
        //        return formatter.ConvertAddress(this);
        //    }
        //}

        [NotMapped]
        public string DisplayAddress { get; set; }

    }

    [ExcludeFromCodeCoverage]
    public static class CustomerAddressSearchResultFormatter
    {
        public static string FormatAddress(CustomerAddressSearchResult address)
        {
            IRepository lookupService = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    lookupService = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
                }
                catch (ActivationException)
                {
                    return string.Empty;
                }

            var formatter = new CustomerAddressSearchFormatter(lookupService);
            return formatter.ConvertAddress(address);
        }
    }
    
}
