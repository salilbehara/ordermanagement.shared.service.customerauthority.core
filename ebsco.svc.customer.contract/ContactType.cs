using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class ContactType
    {
        public int Id { get; set; }
        //public int ContactId { get; set; }
        [ChangeHistory(Name = "Contact Type")]
        public string Type { get; set; }
    }
}
