using System;

namespace ebsco.svc.customer.contract.AddressFormatters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class AddressDisplayFormatAttribute : AddressFormatAttribute
    {
        public AddressDisplayFormatAttribute() : base()
        {

        }
    }
}
