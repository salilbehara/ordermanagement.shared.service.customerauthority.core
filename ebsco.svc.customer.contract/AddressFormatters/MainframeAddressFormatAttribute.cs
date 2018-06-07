using System;

namespace ebsco.svc.customer.contract.AddressFormatters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class MainframeAddressFormatAttribute: AddressFormatAttribute
    {
        public MainframeAddressFormatAttribute() : base()
        {

        }

        public MainframeAddressFormatAttribute(string formatString) : base(formatString)
        {

        }
    }
}
