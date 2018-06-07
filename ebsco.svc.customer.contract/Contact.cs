using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class Contact : IValidatableObject, IHasLegacyMappings
    {
        public Contact()
        {
            //PhoneNumbers = new List<Phone>();
            //EmailAddresses = new List<Email>();
            //Categories = new List<string>();
            //Comments = new List<string>();
            LegacyMappings = new List<LegacyMapping>();
            ContactTypes = new List<ContactType>();
            EmailAddresses = new List<Email>();
            PhoneNumbers = new List<Phone>();
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }
        [ChangeHistory(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [ChangeHistory(Name = "Last Name")]
        public string LastName { get; set; }
        [ChangeHistory(Name = "Middle Name")]
        public string MiddleName { get; set; }

        public List<Phone> PhoneNumbers { get; set; }

        [ChangeHistory(Name = "Email Address")]
        public List<Email> EmailAddresses { get; set; }
        public string Honorific { get; set; }

        [ChangeHistory(Name = "Comments")]
        public string Comment { get; set; }
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ChangeHistory(Name = "Legacy Mappings")]
        public List<LegacyMapping> LegacyMappings { get; set; }

        [ChangeHistory(Name = "Contact Type")]
        public List<ContactType> ContactTypes { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex expr = new Regex(@"([0-9])+");

            var results = new List<ValidationResult>();

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                if (expr.Match(FirstName).Success)
                {
                    results.Add(new ValidationResult("First Name cannot contain numerals."));
                }
            }

            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                if (expr.Match(MiddleName).Success)
                {
                    results.Add(new ValidationResult("Middle Name cannot contain numerals."));
                }
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                if (expr.Match(LastName).Success)
                {
                    results.Add(new ValidationResult("Last Name cannot contain numerals."));
                }
            }

            foreach (var email in EmailAddresses)
            {
                Validator.TryValidateObject(email,
                                                       new ValidationContext(email, null, null),
                                                       results,
                                                       true);
                
            }

            foreach (var phone in PhoneNumbers)
            {

                Validator.TryValidateObject(phone,
                                                       new ValidationContext(phone, null, null),
                                                       results,
                                                       true);

            }

            IValidationRepository validationRepository = null;
            if (ServiceLocator.IsLocationProviderSet)
                try
                {
                    validationRepository = ServiceLocator.Current.GetInstance(typeof(IValidationRepository)) as IValidationRepository;
                }
                catch (ActivationException)
                {
                    //do nothing
                }

            if (validationRepository != null)
            {
                string errorMessage;
                if (!validationRepository.ValidateContact(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Account failed SAP validation: {0}", errorMessage), null));
            }

            return results;
        }
    }
}

