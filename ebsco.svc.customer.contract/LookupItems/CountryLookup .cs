namespace ebsco.svc.customer.contract.LookupItems
{
    public class CountryLookup: LookupItem
    {
        public string MainframeDescription { get; set; }

        public string MainframeShortCode { get; set; }

        public int IsoNumericCode { get; set; }

        public string IsoLongCode { get; set; }
    }
}
