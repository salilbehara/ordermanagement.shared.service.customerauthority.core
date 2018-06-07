namespace ebsco.svc.customer.contract
{
    public class EbookMarcOptions
    {
        public bool? ExcludeMarcSalesChannels { get; set; }

        public bool? MarcRecordPsWeb { get; set; }

        public string MarcCustomizationInfo { get; set; }

        public string oclcHoldingCode { get; set; }

        public string oclcSymbol { get; set; }

        public bool? oclcCollectionsManager { get; set; }
    }
}
