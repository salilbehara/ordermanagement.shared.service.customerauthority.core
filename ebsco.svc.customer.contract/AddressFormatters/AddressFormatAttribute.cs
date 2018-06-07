namespace ebsco.svc.customer.contract.AddressFormatters
{
    public abstract class AddressFormatAttribute: System.Attribute
    {
        public enum AddressTypeEnum
        {
            Billing,
            Shipping,
            Both
        }

        public string[] Countries { get; set; }
        public string FormatString { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        protected AddressFormatAttribute()
        {
            Countries = new string[0];
        }

        protected AddressFormatAttribute(string formatString)
        {
            FormatString = formatString;
            Countries = new string[0];
            AddressType = AddressTypeEnum.Both;
        }

        protected AddressFormatAttribute(string formatString, AddressTypeEnum addressType)
        {
            FormatString = formatString;
            Countries = new string[0];
            AddressType = addressType;
        }


    }
}
