using ebsco.svc.changehistory.contract;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{
    public class Email
    {
        public int Id { set; get; }


        //public int ContactID { get; set; }
        [ChangeHistory(Name = "Email Address")]
        [RegularExpression(@"^(([a-zA-Z0-9_\-\.']+)@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,63}|[0-9]{1,3})(\]?))$", ErrorMessage = "Email Address is invalid.")]
        //[RegularExpression(@"@@", ErrorMessage = "Email Address is invalid.")]
        public string EmailAddress { get; set; }

        // public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }
    }
}
