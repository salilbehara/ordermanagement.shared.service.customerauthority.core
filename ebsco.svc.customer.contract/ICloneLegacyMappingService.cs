using ebsco.svc.customer.contract.MessageContracts.Requests;
using ebsco.svc.customer.contract.MessageContracts.Responses;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface ICloneLegacyMappingService
    {
        [OperationContract]
        GetSuffixIsDeletedResponse GetSuffixIsDeleted(GetSuffixIsDeletedRequest request);

        [OperationContract]
        CloneLegacyMappingResponse CloneLegacyMapping(CloneLegacyMappingRequest request);
    }
}
