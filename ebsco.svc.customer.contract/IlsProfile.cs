using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class IlsProfile : IValidatableObject
    {
        public IlsProfile()
        {
            LegacyMappings = new List<LegacyMapping>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CustomerId { get; set; }
        [ChangeHistory(Name = "Legacy Mappings")]
        public virtual List<LegacyMapping> LegacyMappings { get; set; }
        [ChangeHistory(Name = "ILS Required")]
        public bool ILSRequired { get; set; }

        [MaxLength(525)]
        [ChangeHistory(Name = "ILS Required Comments")]
        public string ILSRequiredComments { get; set; }

        [MaxLength(50)]
        [ChangeHistory(Name = "ILS Organization")]
        public string ILSOrganization { get; set; }

        [MaxLength(50)]
        [ChangeHistory(Name = "ILS System")]
        public string ILSSystem { get; set; }

        [MaxLength(50)]
        public string Version { get; set; }
        [ChangeHistory(Name = "Integrate with Order API")]
        public bool IntegrateWithOrderAPI { get; set; }

        [MaxLength(256)]
        [ChangeHistory(Name = "ILS Passcode")]
        public string ILSPasscode { get; set; }

        [MaxLength(256)]
        [ChangeHistory(Name = "ILS Owner")]
        public string ILSOwner { get; set; }

        [MaxLength(256)]
        [ChangeHistory(Name = "Vendor Code")]
        public string VendorCode { get; set; }

        [MaxLength(256)]
        [ChangeHistory(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [ChangeHistory(Name = "ILS System for Claims")]
        public string ILSSystemForClaims { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            #region ILSRequiredComments
            if (!string.IsNullOrWhiteSpace(ILSRequiredComments) && !(ILSRequired))
                results.Add(new ValidationResult("Comments cannot be entered unless ILS Required is Yes.", new[] { "ILSRequiredComments" }));
            #endregion

            #region IntegrateWithOrderAPI
            if ((IntegrateWithOrderAPI) && (ILSSystem != "ALMA"))
                results.Add(new ValidationResult("Can only integrate with Orders API if ILS System is ALMA.", new[] { "IntegrateWithOrderAPI" }));
            #endregion

            #region ILSPasscode
            if (string.IsNullOrWhiteSpace(ILSPasscode) && (IntegrateWithOrderAPI))
                results.Add(new ValidationResult("ILS Passcode is required in order to integrate with order API.", new[] { "ILSPasscode" }));
            #endregion

            #region ILSOwner
            if (string.IsNullOrWhiteSpace(ILSOwner) && (IntegrateWithOrderAPI))
                results.Add(new ValidationResult("ILS Owner is required in order to integrate with order API.", new[] { "ILSOwner" }));
            #endregion

            #region ILSVendor
            if (string.IsNullOrWhiteSpace(VendorCode) && (IntegrateWithOrderAPI))
                results.Add(new ValidationResult("Vendor Code is required in order to Integrate with Orders API.", new[] { "ILSVendor" }));
            #endregion

            #region ILSVendorAccount
            if (string.IsNullOrWhiteSpace(CustomerCode) && (IntegrateWithOrderAPI))
                results.Add(new ValidationResult("Customer Code is required in order to Integrate with Orders API.", new[] { "ILSVendorAccount" }));
            #endregion

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
                if (!validationRepository.ValidateProfile(this, out errorMessage))
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
            }


            return results;
        }

    }
}
