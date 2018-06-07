namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateLegacyMappingRequest : UpdateRequestBase
    {
        public LegacyMapping LegacyMapping { get; set; }
    }
}
