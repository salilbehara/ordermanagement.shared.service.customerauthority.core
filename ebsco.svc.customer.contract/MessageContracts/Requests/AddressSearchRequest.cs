using ebsco.svc.changehistory.contract.Messages.Request;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class AddressSearchRequest: BaseRequest
    {
        public string Addressee { set; get; }
        public string Attention { set; get; }
        public string Address { set; get; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public LocationType LocationType { set; get; }
    }

    public enum LocationType
    {
        Billing =1,
        Shipping =2,
        Both=0
    }
}
