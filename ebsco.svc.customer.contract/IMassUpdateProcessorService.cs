using ebsco.svc.customer.contract.MessageContracts.Requests;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface IMassUpdateProcessorService
    {
        [OperationContract(IsOneWay = true)]
        void ExecuteMassUpdate(ExecuteMassUpdateRequest request);
    }
}
