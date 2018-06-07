namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteLegacyMappingRequest : UpdateRequestBase
    {
        public int LegacyMappingId { get; set; }
    }
}
