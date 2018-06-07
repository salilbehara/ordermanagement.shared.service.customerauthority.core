using ebsco.svc.customer.contract.AddressFormatters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ebsco.svc.customer.contract
{
    public class MainframeShippingAddressOverride : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Mainframe Override Address Name is required.")]
        [MainframeAddressFormat("{Attention}")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage ="Mainframe Override Address Line 1 length cannot exceed 30 characters")]
        [MainframeAddressFormat("{Addressee}")]
        public string Line1 { get; set; }

        [MaxLength(30, ErrorMessage = "Mainframe Override Address Line 2 length cannot exceed 30 characters")]
        [MainframeAddressFormat("{Address1}")]
        public string Line2 { get; set; }

        [MaxLength(30, ErrorMessage = "Mainframe Override Address Line 3 length cannot exceed 30 characters")]
        [MainframeAddressFormat("{Address2}")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Mainframe Override Address Line 4 is required.")]
        [MaxLength(30, ErrorMessage = "Mainframe Override Address Line 4 length cannot exceed 30 characters")]
        [MainframeAddressFormat(FormatString = "{City} {StateProvinceShortName} {PostalCode}")] //DEFAULT FORMAT
        [MainframeAddressFormat(Countries = new[] { "US" }, FormatString = "{City}")]
        [MainframeAddressFormat(Countries = new[] { "CA" }, FormatString = "{City} {StateProvinceShortName}  {PostalCode}")]
        [MainframeAddressFormat(Countries = new[] { "BR", "NG", "PG", "VE" }, FormatString = "{City} {PostalCode} {StateProvinceShortName}")]
        [MainframeAddressFormat(Countries = new[] { "BT", "BW", "KH", "TD", "EG", "FJ", "GA", "GD", "IN", "MV", "NZ", "PK", "LK", "SH", "SR", "TW", "TK", "TT", "VN" }, FormatString = "{StateProvinceShortName} {City} {PostalCode}")]
        [MainframeAddressFormat(Countries = new[] { "MG", "SY" }, FormatString = "{StateProvinceShortName} {PostalCode} {City}")]
        [MainframeAddressFormat(Countries = new[] { "AD", "AL", "AM", "AR", "AT", "AZ", "BA", "BE", "BG", "BY", "CH", "CL", "CR", "CV", "CY", "CZ", "DE", "DK", "DZ", "EC", "EE", "ES", "ET", "FI", "FO", "FR", "GF", "GL", "GN", "GP",
                                "GQ", "GR", "GT", "GW", "HN", "HR", "HT", "HU", "IL", "IR", "IS", "IT", "KG", "KW", "LA", "LI", "LR", "LT", "LU", "MA", "MC", "MD", "ME", "MK", "MN", "MQ", "MX", "MY", "MZ", "NC",
                                "NI", "NL", "NO", "OM", "PA", "PF", "PH", "PL", "PM", "PT", "PY", "RE", "RO", "RS", "SD", "SE", "SI", "SJ", "SK", "SM", "SN", "SV", "TF", "TJ", "TM", "TN", "TR", "TZ", "UY", "UZ",
                                "VA", "WF", "YT", "ZM" }, FormatString = "{PostalCode} {City} {StateProvinceShortName}")]
        public string Line4 { get; set; }

        [MaxLength(27, ErrorMessage = "Mainframe Override Address Line 5 length cannot exceed 30 characters")]
        [MainframeAddressFormat("{CountryName}")]
        public string Line5 { get; set; }

        [MaxLength(30, ErrorMessage = "Mainframe Override Address City length cannot exceed 30 characters")]
        [MainframeAddressFormat("{City}")]
        public string City { get; set; }

        [MaxLength(2, ErrorMessage = "Mainframe Override Address State Province length must be 2 characters")]
        [MinLength(2, ErrorMessage = "Mainframe Override Address State Province length must be 2 characters")]
        [MainframeAddressFormat("{StateProvinceCode}")]
        public string StateProvince { get; set; }

        [MaxLength(5, ErrorMessage = "Mainframe Override Address Postal Code length must be 5 characters")]
        [MinLength(5, ErrorMessage = "Mainframe Override Address Postal Code length must be 5 characters")]
        [MainframeAddressFormat("{PostalCode}")]
        public string PostalCode { get; set; }

        [MaxLength(2, ErrorMessage = "Mainframe Override Address Country Code length must be 2 characters")]
        [MinLength(2, ErrorMessage = "Mainframe Override Address Country Code length must be 2 characters")]
        [MainframeAddressFormat("{CountryCode}")]
        [Required(ErrorMessage="Mainframe Override Address Country Code is required.")]
        public string CountryCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (CountryCode == "US")
            {
                if (string.IsNullOrEmpty(PostalCode))
                    results.Add(new ValidationResult("Mainframe Override Address Postal Code is required.", new[] { "PostalCode" }));
                if (string.IsNullOrEmpty(StateProvince))
                    results.Add(new ValidationResult("Mainframe Override Address State is required.", new[] { "StateProvince" }));
            }
            else
            {
                if (!string.IsNullOrEmpty(PostalCode))
                    results.Add(new ValidationResult("Mainframe Override Address Postal Code is not valid.", new[] { "PostalCode" }));
                if (!string.IsNullOrEmpty(StateProvince))
                    results.Add(new ValidationResult("Mainframe Override Address State/Province is not valid", new[] { "StateProvince" }));
            }

            return results;
        }

        internal string CombinedAddress
        {
            get
            {
                var sb = new StringBuilder();

                sb.AppendLine(Name);

                if (!string.IsNullOrWhiteSpace(Line1))
                    sb.AppendLine(Line1);

                if (!string.IsNullOrWhiteSpace(Line2))
                    sb.AppendLine(Line2);

                if (!string.IsNullOrWhiteSpace(Line3))
                    sb.AppendLine(Line3);

                if (!string.IsNullOrWhiteSpace(Line4))
                    sb.AppendLine(Line4);

                if (!string.IsNullOrWhiteSpace(Line5))
                    sb.AppendLine(Line5);

                if (!string.IsNullOrWhiteSpace(StateProvince) && !string.IsNullOrWhiteSpace(PostalCode))
                    sb.AppendLine(string.Format("{0}, {1}", StateProvince, PostalCode));

                sb.AppendLine(CountryCode);

                return sb.ToString();
            }
        }
    }
}
