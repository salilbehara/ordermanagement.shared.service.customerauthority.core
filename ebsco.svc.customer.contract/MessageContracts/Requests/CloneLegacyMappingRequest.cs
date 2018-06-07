namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CloneLegacyMappingRequest
    {
        public int CustomerId { get; set; }
        public string CloneLegacyMappingFrom { get; set; }
        public string CloneLegacyMappingTo { get; set; }

        public bool SaveDeletedSuffixOverride { get; set; } = false;
    }
}
