namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateLegacyMappingRequest : UpdateRequestBase
    {
        public LegacyMapping LegacyMapping { get; set; }
    }
}
