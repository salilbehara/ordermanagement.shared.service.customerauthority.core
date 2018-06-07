namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetCustomerByLegacyMappingRequest: RequestBase
    {
        public string LegacySystemName { get; set; }

        public string LegacyIdentifier { get; set; }

        public RelatedEntitiesEnum? RelatedEntitiesToRetrieve { get; set; }
    }
}
