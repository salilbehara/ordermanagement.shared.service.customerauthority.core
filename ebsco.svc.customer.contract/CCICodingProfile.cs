using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class CCICodingProfile : IValidatableObject
    {
        public CCICodingProfile()
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
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 01")]
        public string CCILine01 { get; set; }
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 02")]
        public string CCILine02  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 03")]
        public string CCILine03  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 04")]
        public string CCILine04  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 05")]
        public string CCILine05 { get; set; }
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 06")]
        public string CCILine06  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 07")]
        public string CCILine07  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 08")]
        public string CCILine08  {get; set;}
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 09")]
        public string CCILine09 { get; set; }
        
        [MaxLength(600)]
        [ChangeHistory(Name = "CCI Line 4800")]
        public string CCILine4800 { get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

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
                {
                    results.Add(new ValidationResult(string.Format("Profile failed SAP validation: {0}", errorMessage), null));
                }
            }

            return results;
        }
    }
}
