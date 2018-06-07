using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    public interface ICloneMainframeSuffixRepository
    {
        [OperationContract]
        string CloneMainframeSuffix(string CloneSuffixFrom, string CloneSuffixTo);

        [OperationContract]
        string GetMainframeSuffixState(string CloneSuffixTo);

    }
}
