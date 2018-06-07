using ebsco.svc.changehistory.contract.Messages.Request;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class PerformBulkUpdateRequest : BaseRequest
    {
        public EntityTypeEnum entityType { get; set; }
            
        public string SearchString { get; set; }

        public string PropertyName { get; set; }

        public string UpdatedValue { get; set; }
    }
}
