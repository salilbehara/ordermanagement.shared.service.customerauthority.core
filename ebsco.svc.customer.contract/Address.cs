using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;
using ebsco.svc.customer.contract.AddressFormatters;

namespace ebsco.svc.customer.contract
{
    [Flags]
    public enum CustomerAddressType
    {
        None = 0,
        Shipping = 1,
        Billing = 2
    }

    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{City} {StateProvince} {Postal}\n{Country}")] //DEFAULT FORMAT
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "US" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{City}, {StateProvince} {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "CA" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{City} {StateProvince}  {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "BR", "NG", "PG", "VE" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{City} {Postal} {StateProvince}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "BT", "BW", "KH", "TD", "EG", "FJ", "GA", "GD", "IN", "MV", "NZ", "PK", "LK", "SH", "SR", "TW", "TK", "TT", "VN" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{StateProvince} {City} {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "MG", "SY" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{StateProvince} {Postal} {City}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Billing, Countries = new[] { "AD", "AL", "AM", "AR", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CL", "CR", "CV", "CY", "CZ", "DE", "DK", "DZ", "EC", "EE", "ES", "ET", "FI", "FO", "FR", "GF", "GL", "GN", "GP",
                                              "GQ", "GR", "GT", "GW", "HN", "HR", "HT", "HU", "IL", "IR", "IS", "IT", "KG", "KW", "LA", "LI", "LR", "LT", "LU", "MA", "MC", "MD", "ME", "MK", "MN", "MQ", "MX", "MY", "MZ", "NC",
                                              "NI", "NL", "NO", "OM", "PA", "PF", "PH", "PL", "PM", "PT", "PY", "RE", "RO", "RS", "SD", "SE", "SI", "SJ", "SK", "SM", "SN", "SV", "TF", "TJ", "TM", "TN", "TR", "TZ", "UY", "UZ",
                                              "VA", "WF", "YT", "ZM" }, FormatString = "{Addressee}\n{Attention}\n{Line1}\n{Line2}\n{Postal} {City} {StateProvince}\n{Country}")]

    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{City} {StateProvince} {Postal}\n{Country}")] //DEFAULT FORMAT
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "US" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{City}, {StateProvince} {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "CA" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{City} {StateProvince}  {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "BR", "NG", "PG", "VE" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{City} {Postal} {StateProvince}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "BT", "BW", "KH", "TD", "EG", "FJ", "GA", "GD", "IN", "MV", "NZ", "PK", "LK", "SH", "SR", "TW", "TK", "TT", "VN" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{StateProvince} {City} {Postal}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "MG", "SY" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{StateProvince} {Postal} {City}\n{Country}")]
    [AddressDisplayFormat(AddressType = AddressFormatAttribute.AddressTypeEnum.Shipping, Countries = new[] { "AD", "AL", "AM", "AR", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CL", "CR", "CV", "CY", "CZ", "DE", "DK", "DZ", "EC", "EE", "ES", "ET", "FI", "FO", "FR", "GF", "GL", "GN", "GP",
                                              "GQ", "GR", "GT", "GW", "HN", "HR", "HT", "HU", "IL", "IR", "IS", "IT", "KG", "KW", "LA", "LI", "LR", "LT", "LU", "MA", "MC", "MD", "ME", "MK", "MN", "MQ", "MX", "MY", "MZ", "NC",
                                              "NI", "NL", "NO", "OM", "PA", "PF", "PH", "PL", "PM", "PT", "PY", "RE", "RO", "RS", "SD", "SE", "SI", "SJ", "SK", "SM", "SN", "SV", "TF", "TJ", "TM", "TN", "TR", "TZ", "UY", "UZ",
                                              "VA", "WF", "YT", "ZM" }, FormatString = "{Attention}\n{Addressee}\n{Line1}\n{Line2}\n{Postal} {City} {StateProvince}\n{Country}")]
    public abstract class Address : IHasLegacyMappings
    {
        public abstract CustomerAddressType AddressType { get; }

        public string Note { get; set; }

        //Commented out special char validation b/c decistion pending to add allowed characters or change to Tape Addres.
        //[RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Shipping Address Attention line cannot contain special characters")]
        public virtual string Attention { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Shipping Address Line 1 line cannot contain special characters")]
        public string Address1 { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Shipping Address Line 2 line cannot contain special characters")]
        public string Address2 { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Shipping Address City line cannot contain special characters")]
        public string City { get; set; }


        public string StateProvince { get; set; }

        [Required]
        public string CountryCode { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9- ]*$", ErrorMessage = "Shipping Address Addressee line cannot contain special characters")]
        public virtual string Addressee { get; set; }
        
        public string PostalCode { get; set; }

        [ChangeHistory(Name = "Legacy Mappings")]
        public List<LegacyMapping> LegacyMappings { get; set; }
        
        [ChangeHistory(Name = "FTE Comments")]
        public string FTEComment { get; set; }
        
        [ChangeHistory(Name = "Carnegie Classification")]
        public string CarnegieClassification { get; set; }
        
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ChangeHistory(Name = "Shipping Address")]
        public string DisplayAddressMain { get; set; }
      


    }
}
