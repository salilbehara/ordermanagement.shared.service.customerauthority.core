namespace ebsco.svc.customer.contract
{
    public class CustomerPricingInfo
    {
        public string OfficeCode { get; set; }

        public int AccountNumber { get; set; }

        public int Suffix { get; set; }

        public decimal? ForeignERMPercent { get; set; }

        public decimal? DomesticERMPercent { get; set; }

        public bool ApplyERMToBillLaterAndStandingOrders { get; set; }
    }
}