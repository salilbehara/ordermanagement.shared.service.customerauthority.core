using System;

namespace ebsco.svc.customer.contract
{
    public interface IValidationRepository : IDisposable
    {
        bool HasPendingConsolidatedInvoices(LegacyMapping legacyMapping);

        bool HasActiveInvoices(LegacyMapping legacyMapping);

        bool ValidateProfile(InvoiceProfile profile, out string errorMessage);

        bool ValidateProfile(SecondaryCustomerProfile profile, out string errorMessage);

        bool ValidateProfile(RenewalProfile profile, out string errorMessage);

        bool ValidateProfile(PricingProfile profile, out string errorMessage);

        bool ValidateProfile(OrderProfile profile, out string errorMessage);

        bool ValidateProfile(IlsProfile profile, out string errorMessage);

        bool ValidateProfile(CCICodingProfile profile, out string errorMessage);

        bool ValidateProfile(CreditsAndAdjustmentsProfile profile, out string errorMessage);

        bool ValidateProfile(ReportingProfile profile, out string errorMessage);

        bool ValidateContact(Contact contact, out string errorMessage);

        bool ValidateBillingLocation(BillingLocation location, out string errorMessage);

        bool ValidateTaxAddress(Address address);

        bool ValidateConsolidatedInvoices(InvoiceProfile invoiceProfile, SecondaryCustomerProfile secondaryProfile, out string errorMessage);

        bool HasMatchingEbscoAndISOCurrencies(string ISOBillingCurrency, string EbscoBillingCurrency, out string errorMessage);

        int GetNextAvailableAccountNumber(string officeCode, int beginAccountNumber);

        bool DoesAccountNumberExist(string officeCode, int accountNumber);
    }
}
