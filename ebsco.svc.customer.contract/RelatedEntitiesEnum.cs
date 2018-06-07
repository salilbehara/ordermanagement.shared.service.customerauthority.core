using System;
using System.Runtime.Serialization;

namespace ebsco.svc.customer.contract
{
    [Flags]
    public enum RelatedEntitiesEnum
    {
        [EnumMember]
        LegacyMappings = 0,
        [EnumMember]
        Contacts = 1,
        [EnumMember]
        BillingLocations = 2,
        [EnumMember]
        ShippingLocations = 4,
        [EnumMember]
        CustomerRepresentatives = 8,
        [EnumMember]
        SecondaryCustomerProfiles = 16,
        [EnumMember]
        RenewalProfiles = 32,
        [EnumMember]
        InvoiceProfiles = 64,
        [EnumMember]
        OrderProfiles = 128,
        [EnumMember]
        PricingProfiles = 256,
        [EnumMember]
        IlsProfiles = 512,
        [EnumMember]
        CCICodingProfiles = 1024,
        [EnumMember]
        FteCounts = 2048,
        [EnumMember]
        CreditsAndAdjustmentsProfiles = 4096,
        [EnumMember]
        ReportingProfiles = 8192,
        [EnumMember]
        IPAddresses = 16384,
        [EnumMember]
        PricingClassifications = 32768
    }
}
