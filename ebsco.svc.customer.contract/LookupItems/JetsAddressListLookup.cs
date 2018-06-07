namespace ebsco.svc.customer.contract.LookupItems
{
    public class JetsAddressListLookup : LookupItem
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string StateProvinceCode { get; set; }
        public decimal? USZipCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string JetsDatabase { get; set; }
        public string JetsServiceCenter { get; set; }
    }
}
