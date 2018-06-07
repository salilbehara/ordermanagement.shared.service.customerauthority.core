using ebsco.svc.customer.contract.MessageContracts.Requests;
using ebsco.svc.customer.contract.MessageContracts.Responses;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface IMassUpdateService
    {


        [OperationContract]
        SubmitMassUpdateResponse SubmitMassUpdate(SubmitMassUpdateRequest request);

        [OperationContract]
        GenerateMassUpdateSpreadsheetResponse GenerateMassUpdateSpreadsheet(GenerateMassUpdateSpreadsheetRequest request);

        [OperationContract]
        UpdateMassUpdateResponse UpdateMassUpdateRequest(UpdateMassUpdateRequest request);

        [OperationContract]
        GetMassUpdateResponse GetMassUpdateRequest(GetMassUpdateRequest request);

    }
}
