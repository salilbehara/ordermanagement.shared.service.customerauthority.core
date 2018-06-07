using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    [ChangeHistory(Name = "Fte")]
    public class ShippingFteCount: FteCount
    {


        //public int ShippingLocationId { get; set; }
    }
}
