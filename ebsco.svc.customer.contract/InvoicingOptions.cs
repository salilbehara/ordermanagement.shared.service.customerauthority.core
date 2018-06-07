namespace ebsco.svc.customer.contract
{
    public class InvoicingOptions
    {
        //cci 14

        //cci 16 //*New*

        //cci 18 //*New*

        //cci 25 //*New*

        //cci 26 //*New*

        //CCI 75 //*New* //*New*

        //CCI 90//*New*//*New*

        //CCI 105//*New*

        //cci210

        //CCI 520
        public bool SplitInvoiceByIscHegis { get; set; }
        //CCI 521
        public bool SplitInvoiceBySubscriber { get; set; }

        //cci 600

        //cci 601

        //650
        //public string DoNotCombineShipTos { get; set; }

        //cci 700
        public bool CombinePurchaseOrders { get; set; }

        public string CombinePurchaseOrdersComments { get; set; }

        //cci 850
        //cci 900

        //cci 1300

        //cci 1450

        //cci 1600
        public bool CommentLineRequired { get; set; }

        //cci 1650
        public bool PrintInvoicesSimplex { get; set; }

        public decimal? MaximumInvoiceAmount { get; set; }

        public int? MaximumInvoiceLineItems { get; set; }

        public bool ConsolidateInvoicing { get; set; }

        public int? NumberOfInvoiceCopies { get; set; }


    }
}
