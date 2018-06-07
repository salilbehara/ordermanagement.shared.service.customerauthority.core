using CommonServiceLocator;
using ebsco.svc.changehistory.contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "AlternateAddress")]
    public class TapeAddress: IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tape Address Attention is required.")]
        [MaxLength(24, ErrorMessage = "Tape Address Attention cannot exceed 24 characters")]
        public string Attention { get; set; }

        [MaxLength(24, ErrorMessage = "Tape Address Addressee cannot exceed 24 characters")]
        public string Addressee { get; set; }

        [MaxLength(24, ErrorMessage = "Tape Address Address cannot exceed 24 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Tape Address City is required.")]
        [MaxLength(15, ErrorMessage = "Tape Address City cannot exceed 15 characters")]
        public string City { get; set; }

        public string StateProvince { get; set; }

        [MaxLength(13, ErrorMessage = "Tape Address Postal Code cannot exceed 13 characters")]
        public string Postal { get; set; }

        [Required(ErrorMessage = "Tape Address Country is required.")]
        [MaxLength(2, ErrorMessage = "Tape Address Country cannot exceed 2 characters")]
        public string CountryCode { get; set; }

        private bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        [ChangeHistory(Name = "TAPE Address")]
        internal string CombinedAddress
        {
            get
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
                var _stateProvinces = ListCacheHelper.GetStateProvinceCodes(lookupService);
                var _countries = ListCacheHelper.GetCountries(lookupService);

                var countryCode = _countries.FirstOrDefault(x => x.Value == CountryCode);
                var countryName = countryCode != null ? countryCode.Description : string.Empty;
                var stateProvinceCode = _stateProvinces.FirstOrDefault(x => x.CountryCode == CountryCode && x.Value == StateProvince);
                var stateProvinceName = stateProvinceCode != null ? stateProvinceCode.ShortName ?? stateProvinceCode.Description : StateProvince;

                var sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(Attention))
                    sb.AppendLine(Attention);

                if (!string.IsNullOrWhiteSpace(Addressee))
                    sb.AppendLine(Addressee);
                
                if (!string.IsNullOrWhiteSpace(Address))
                    sb.AppendLine(Address);

                if (!string.IsNullOrWhiteSpace(City))
                    sb.AppendLine(City);

                //if (!string.IsNullOrWhiteSpace(StateProvince) && !string.IsNullOrWhiteSpace(Postal))
                //    sb.AppendLine(string.Format("{0}, {1}", StateProvince, Postal));
                if (!string.IsNullOrWhiteSpace(stateProvinceName) && !string.IsNullOrWhiteSpace(Postal))
                    sb.AppendLine(string.Format("{0}, {1}", stateProvinceName, Postal));

                //sb.AppendLine(CountryCode);
                sb.AppendLine(countryName);

                return sb.ToString();
            }
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if ((new[] { "US", "CA" }.Contains(CountryCode)) && string.IsNullOrWhiteSpace(Postal))
                results.Add(new ValidationResult("Tape Address Postal Code is required.", new[] { "Postal" }));

            if (CountryCode == "US" && Postal != null && !Regex.Match(Postal, @"^\d{1,5}(\-\d{4})?$").Success)
                results.Add(new ValidationResult("Tape Address Postal Code is not valid.", new[] { "Postal" }));

            if ((new[] { "US", "CA", "BR", "AU", "IT", "MX" }.Contains(CountryCode)) && string.IsNullOrWhiteSpace(StateProvince))
                results.Add(new ValidationResult("Tape Address State/Province is required.", new[] { "StateProvince" }));

            if (CountryCode == "CA" && !string.IsNullOrWhiteSpace(Postal))
            {
                if (!Regex.Match(Postal, @"(\D\d\D\s\d\D\d)").Success)
                    results.Add(new ValidationResult("Tape Address Postal Code is not valid.", new[] { "Postal" }));

                var canadaPostalValidations = new[]
                {
                        new Tuple<string, string> ("T", "AB"),
                        new Tuple<string, string> ("V", "BC"),
                        new Tuple<string, string> ("R", "MB"),
                        new Tuple<string, string> ("E", "NB"),
                        new Tuple<string, string> ("A", "NL"),
                        new Tuple<string, string> ("B", "NS"),
                        new Tuple<string, string> ("X", "NT"),
                        new Tuple<string, string> ("K", "ON"),
                        new Tuple<string, string> ("L", "ON"),
                        new Tuple<string, string> ("M", "ON"),
                        new Tuple<string, string> ("N", "ON"),
                        new Tuple<string, string> ("P", "ON"),
                        new Tuple<string, string> ("C", "PE"),
                        new Tuple<string, string> ("G", "QC"),
                        new Tuple<string, string> ("H", "QC"),
                        new Tuple<string, string> ("J", "QC"),
                        new Tuple<string, string> ("S", "SK"),
                        new Tuple<string, string> ("Y", "YT")
                    };

                if (!canadaPostalValidations.Any(x => x.Item1 == Postal.Substring(0, 1).ToUpper() && StateProvince == x.Item2))
                    results.Add(new ValidationResult("Tape Address State/Province and Postal Code is not a valid combination.", new[] { "Postal" }));
            }

            return results;
        }
    }
}
