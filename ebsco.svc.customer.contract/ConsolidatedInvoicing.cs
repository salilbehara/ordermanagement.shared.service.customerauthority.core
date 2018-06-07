using System;
using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract
{
    public class ConsolidatedInvoicing
    {
        public bool ConsolidatedInvoice { get; set; }
        public string OfficeCode { get; set; }
        public string EbscoAccount { get; set; }
        public int? AccountSuffix { get; set; }
        public bool MergeAccountSufffix { get; set; }
        public MonthFlag ConsolidateProcessFlag { get; set; }
    }

    [DataContract]
    [Flags]
    public enum MonthFlag
    {
        [EnumMember]
        None = 0x0,
        [EnumMember]
        Jan = 0x01,
        [EnumMember]
        Feb = 0x2,
        [EnumMember]
        Mar = 0x4,
        [EnumMember]
        Apr = 0x8,
        [EnumMember]
        May = 0x10,
        [EnumMember]
        Jun = 0x20,
        [EnumMember]
        Jul = 0x40,
        [EnumMember]
        Aug = 0x80,
        [EnumMember]
        Sept = 0x100,
        [EnumMember]
        Oct = 0x200,
        [EnumMember]
        Nov = 0x400,
        [EnumMember]
        Dec = 0x800,
    }
}
