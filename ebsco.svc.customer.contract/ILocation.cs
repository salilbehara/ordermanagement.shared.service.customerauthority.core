using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceKnownType(typeof(BillingLocation))]
    [ServiceKnownType(typeof(ShippingLocation))]
    public interface ILocation
    {
        Address Address
        {
            get;
            set;
        }
    }
}
