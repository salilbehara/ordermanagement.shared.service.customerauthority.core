using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CommonServiceLocator;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class CustomerIPAddress : IValidatableObject, IHasLegacyMappings
    {
        [ChangeHistory(Name = "Legacy Mappings")]
        public List<LegacyMapping> LegacyMappings { get; set; } = new List<LegacyMapping>();

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public byte IpAddressFromNode1 { get; set; }
        public byte IpAddressFromNode2 { get; set; }
        public byte IpAddressFromNode3 { get; set; }
        public byte IpAddressFromNode4 { get; set; }
        public byte? IpAddressToNode1 { get; set; }
        public byte? IpAddressToNode2 { get; set; }
        public byte? IpAddressToNode3 { get; set; }
        public byte? IpAddressToNode4 { get; set; }
        public DateTime StartDate { get; set; }

        [ChangeHistory(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        [ChangeHistory(Name = "Comments")]
        public string Notes { get; set; }
        public override string ToString()
        {
            var address1String = $"{IpAddressFromNode1}.{IpAddressFromNode2}.{IpAddressFromNode3}.{IpAddressFromNode4}";
            var address2String = IpAddressToNode1 == null
                                 ? ""
                                 : $"-{IpAddressToNode1}.{IpAddressToNode2}.{IpAddressToNode3}.{IpAddressToNode4}";
            return $"({address1String}{address2String})";
        }

        public bool IsDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var range = default(V4IPRange);
            try
            {
                range = new V4IPRange(this);
            }
            catch (Exception e)
            {
                results.Add(new ValidationResult(e.Message));
            }

            if (TerminationDate.HasValue)
            {
                if (TerminationDate < DateTime.UtcNow)
                {
                    results.Add(new ValidationResult("Termination date cannot be a date in the past."));
                }
                if (TerminationDate < StartDate)
                {
                    results.Add(new ValidationResult("Termination date cannot come before the start date."));
                }
            }

            // Check to see if IP address range is public
            if (!range.IsIPAddressPublic())
            {
                results.Add(new ValidationResult("IP address or range of address contains non-public IP addresses."));
            }

            if (!IsDeleted)
            {
                if (LegacyMappings != null)
                {
                    if (!(LegacyMappings.Where(x => x.IsActive).ToList().Count > 0))
                    {
                        results.Add(new ValidationResult(
                            "IP address must be mapped to at least one account, subscriber, or suffix."));
                    }
                }
            }

            if (results.Count > 0)
            {
                return results;
            }

            IRepository repository = null;
            try
            {
                repository = ServiceLocator.IsLocationProviderSet ? ServiceLocator.Current.GetInstance<IRepository>() : null;
            }
            catch (Exception)
            {
                return results;
            }
            if (repository == null)
            {
                return results;
            }

            using (repository)
            {
                // Check to make sure edits do not modify ip address values or start date
                if (Id > 0)
                {
                    var oldRecord = repository.GetIPAddress(Id);
                    if (oldRecord == null)
                    {
                        results.Add(
                            new ValidationResult("Unable to find existing IP Address record to validate against"));
                        return results;
                    }
                    if (IpAddressFromNode1 != oldRecord.IpAddressFromNode1
                        || IpAddressFromNode2 != oldRecord.IpAddressFromNode2
                        || IpAddressFromNode3 != oldRecord.IpAddressFromNode3
                        || IpAddressFromNode4 != oldRecord.IpAddressFromNode4
                        || IpAddressToNode1 != oldRecord.IpAddressToNode1
                        || IpAddressToNode2 != oldRecord.IpAddressToNode2
                        || IpAddressToNode3 != oldRecord.IpAddressToNode3
                        || IpAddressToNode4 != oldRecord.IpAddressToNode4
                        || StartDate.Date != oldRecord.StartDate.Date)
                    {
                        results.Add(new ValidationResult("IP Address values and start date cannot be updated. "));
                        return results;
                    }
                }

                // Check for overlaps with existing account, suffix, and subscriber mappings
                var overlaps = repository.GetIPAddressesByCustomerId(CustomerId)
                    .Where(ip => ip.Id != Id &&
                                 new V4IPRange(ip).HasOverlap(range) &&
                                 ip.LegacyMappings.Any(lm => LegacyMappings.Any(nlm => nlm.Id == lm.Id)))
                    .ToList();

                if (overlaps.Count > 0)
                {
                    foreach (var overlap in overlaps)
                    {
                        var mappingStrings = overlap.LegacyMappings
                            .Where(lm => LegacyMappings.Any(nlm => lm.Id == nlm.Id))
                            .Select(GetLegacyShortDescription);
                        var mappingListString = string.Concat(mappingStrings).TrimEnd(',');

                        results.Add(new ValidationResult(
                            $"The IP address range {range} overlaps with exising IP address range {new V4IPRange(overlap)}, and both have the following matching mappings:{mappingListString}."));
                    }
                }
            }

            return results;
        }

        private string GetLegacyShortDescription(LegacyMapping mapping)
        {
            if (mapping.LegacySystemName == LegacySystemNames.Account.Name)
            {
                return " Account,";
            }
            if (mapping.LegacySystemName == LegacySystemNames.Suffix.Name)
            {
                return $" Suffix ({mapping.LegacyIdentifier.Substring(8, 2)}),";
            }
            if (mapping.LegacySystemName == LegacySystemNames.Subscriber.Name)
            {
                return $" Subscriber ({mapping.LegacyIdentifier.Substring(8, 2)}),";
            }
            return string.Empty;
        }
    }
}
