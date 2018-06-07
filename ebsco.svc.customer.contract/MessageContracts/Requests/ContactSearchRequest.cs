using ebsco.svc.changehistory.contract.Messages.Request;

namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class ContactSearchRequest : BaseRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactType { get; set; }

        public string Title { get; set; }

        public int? CustomerId { get; set; }
    }
}
