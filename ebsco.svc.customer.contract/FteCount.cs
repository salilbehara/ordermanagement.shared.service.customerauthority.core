using System;
using System.ComponentModel.DataAnnotations;
using ebsco.svc.changehistory.contract;

namespace ebsco.svc.customer.contract
{
    public abstract class FteCount
    {
        [ChangeHistory(Ignore = true)]
        public int Id { get; set; }

        [ChangeHistory(Name = "FTE Type")]
        [Required]
        public string CountType { get; set; }

        [Required]
        [Range(minimum:0, maximum:9999999, ErrorMessage ="FTE Count must be between 0 and 9999999.")]
        public int Count { get; set; }
        public string Source { get; set; }

        [ChangeHistory(Name = "Fte Date")]
        public DateTime? FteDate { get; set; }

        [ChangeHistory(Ignore = true)]
        public DateTime? CreatedAt { get; set; }

        [ChangeHistory(Ignore = true)]
        public DateTime? UpdatedAt { get; set; }

    }
}

