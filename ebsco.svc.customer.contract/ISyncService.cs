using ebsco.svc.customer.contract.MessageContracts.Requests;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface ISyncService
    {
        [OperationContract(IsOneWay = true)]
        void SyncCustomerEntity(SyncCustomerEntityRequest request);

        [OperationContract(IsOneWay = true)]
        void ClearSyncFailure(ClearSyncFailureRequest request);
    }

}
