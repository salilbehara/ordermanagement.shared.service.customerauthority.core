namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class GetCustomerRequest
    {
        public int? Id { get; set; }

        public string CRMID { get; set; }

        public RelatedEntitiesEnum? RelatedEntitiesToRetrieve { get; set; }


        
    }
}
