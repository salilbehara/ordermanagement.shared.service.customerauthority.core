namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class CreateCustomerRequest: UpdateRequestBase
    {
        public string AccountName { get; set; }

        public string OfficeCode { get; set; }

        public int Suffix { get; set; }

        public int AccountNumber { get; set; }

        public string SatelliteOfficeCode { get; set; }

        public string EBSCOCurrencyCode { get; set; }

        public string ISOCurrencyCode { get; set; }
    }
}
