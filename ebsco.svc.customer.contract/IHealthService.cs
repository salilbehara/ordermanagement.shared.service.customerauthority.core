using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface IHealthService
    {
        [OperationContract]
        void CheckSAPStatus();

        [OperationContract]
        void CheckTaxServiceStatus();
    }
}
