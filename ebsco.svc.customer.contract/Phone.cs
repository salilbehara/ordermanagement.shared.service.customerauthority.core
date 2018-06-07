using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public class Phone
    {
        
        public int Id { get; set; }
        

        [ChangeHistory(Name = "Phone Number")]
        [MaxLength(18)]
        public string PhoneNumber { get; set; }

        [ChangeHistory(Name = "Extension")]
        public string ExtensionNumber { get; set; }

        [ChangeHistory(Name = "Phone Type")]
        public string PhoneType { get; set; }
       
    }
}
