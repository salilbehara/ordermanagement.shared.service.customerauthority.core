using ebsco.svc.customer.contract.LookupItems;
using ebsco.svc.customer.contract.MessageContracts.Requests;
using ebsco.svc.customer.contract.MessageContracts.Responses;
using System;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public interface IRepository : IDisposable
    {
        Customer GetCustomer(int id, RelatedEntitiesEnum? relatedEntities = null);
        Customer GetCustomerWithDeletedEntities(int id, RelatedEntitiesEnum? relatedEntities = null);


        Customer GetCustomer(string id, RelatedEntitiesEnum? relatedEntities = null);
        Customer GetCustomerWithDeletedEntities(string id, RelatedEntitiesEnum? relatedEntities = null);

        Customer CreateCustomer(Customer customer, string changedBy = "Service");
        Customer UpdateCustomer(Customer customer, string changedBy = "Service");

        bool IsExternalIdUsed(string id);

        void DeleteCustomer(int id, string changedBy = "Service");

        SecondaryCustomerProfile GetSecondaryCustomerProfile(int id);
        SecondaryCustomerProfile UpdateSecondaryCustomerProfile(SecondaryCustomerProfile profile, string changedBy = "Service");

        void DeleteSecondaryCustomerProfile(int id, string changedBy = "Service");

        RenewalProfile GetRenewalProfile(int id);
        RenewalProfile UpdateRenewalProfile(RenewalProfile profile, string changedBy = "Service");

        void DeleteRenewalProfile(int id, string changedBy = "Service");

        PricingProfile GetPricingProfile(int id);
        PricingProfile UpdatePricingProfile(PricingProfile profile, string changedBy = "Service");

        void DeletePricingProfile(int id, string changedBy = "Service");

        InvoiceProfile GetInvoiceProfile(int id);
        InvoiceProfile UpdateInvoiceProfile(InvoiceProfile profile, string changedBy = "Service");

        void DeleteInvoiceProfile(int id, string changedBy = "Service");

        OrderProfile GetOrderProfile(int id);
        OrderProfile UpdateOrderProfile(OrderProfile profile, string changedBy = "Service");

        void DeleteOrderProfile(int id, string changedBy = "Service");

        IlsProfile GetIlsProfile(int id);
        IlsProfile UpdateIlsProfile(IlsProfile profile, string changedBy = "Service");

        void DeleteIlsProfile(int id, string changedBy = "Service");

        CCICodingProfile GetCCICodingProfile(int id);
        CCICodingProfile UpdateCCICodingProfile(CCICodingProfile profile, string changedBy = "Service");

        void DeleteCCICodingProfile(int id, string changedBy = "Service");

        CreditsAndAdjustmentsProfile GetCreditsAndAdjustmentsProfile(int id);
        CreditsAndAdjustmentsProfile UpdateCreditsAndAdjustmentsProfile(CreditsAndAdjustmentsProfile profile, string changedBy = "Service");
        void DeleteCreditsAndAdjustmentsProfile(int id, string changedBy = "Service");

        ReportingProfile GetReportingProfile(int id);
        ReportingProfile UpdateReportingProfile(ReportingProfile profile, string changedBy = "Service");
        void DeleteReportingProfile(int id, string changedBy = "Service");

        Contact GetContact(int id);

        Contact UpdateContact(Contact contact, string changedBy = "Service");

        void DeleteContact(int id, string changedBy = "Service");

        Employee GetEmployee(int id);

        Employee GetEmployee(string sid);

        IEnumerable<int> GetCustomersHavingEmployee(int employeeId);

        IEnumerable<int> GetCustomersHavingEmployeeAndRole(int employeeId, string role);

        Employee UpdateEmployee(Employee employee, string changedBy = "Service");

        ShippingLocation UpdateShippingLocation(ShippingLocation location, string changedBy = "Service");

        ShippingLocation GetShippingLocation(int id);

        void DeleteShippingLocation(int id, string changedBy = "Service");

        BillingLocation UpdateBillingLocation(BillingLocation location, string changedBy = "Service");

        BillingLocation GetBillingLocation(int id);

        IEnumerable<BillingLocation> GetBillingLocationsByCustomerId(int customerId);

        void DeleteBillingLocation(int id, string changedBy = "Service");

        CustomerIPAddress GetIPAddress(int id);

        IEnumerable<CustomerIPAddress> GetIPAddressesByCustomerId(int customerId);

        IEnumerable<CustomerIPAddress> GetIPAddressesByCustomerIdAndLegacySystem(int customerId, LegacySystemName legacySystem);

        CustomerIPAddress UpdateIPAddress(CustomerIPAddress address, string changedBy = "Service");

        void DeleteIPAddress(int id, string changedBy = "Service");

        void DeleteEmployee(int id, string changedBy = "Service");

        LegacyMapping GetLegacyMapping(int id);

        LegacyMapping UpdateLegacyMapping(LegacyMapping mapping, string changedBy = "Service");

        void DeleteLegacyMapping(int id, string changedBy = "Service");

        IEnumerable<contract.CustomerSearchResult> SearchCustomers(string customerName, string externalId, string legacyIdentifier, string ddeCustomerID, int skip, int take, out int numRecords);

        IEnumerable<CustomerSearchResult> SearchCustomers(string searchString, int skip, int take, out int numRecords);

        IEnumerable<CustomerAddressSearchResult> SearchCustomersByAddress(string address, string city, string state, string postalCode, string country, LocationType locationType, int skip, int take, out int numRecords);

        IEnumerable<CustomerContactSearchResult> SearchContacts(string firstName, string lastName, string middleName, string emailAddress, string phoneNumber, string title, string contactType, int? customerId, int skip, int take, out int numRecords);

        IEnumerable<T> GetLookupValues<T>() where T : LookupItem;

        IEnumerable<CountryLookup> GetCountries();

        IEnumerable<JetsAddressListLookup> GetJetsAddressList();

        IEnumerable<DropAddressListLookup> GetDropAddressList();

        IEnumerable<StatesProvincesLookup> GetStateProvinces(string countryCode);

        void SetSyncStatus(string syncType, string entityType, int entityId, int? customerId, bool success, string failureReason = null);

        MassUpdateRequest GetMassUpdateRequest(int Id);

        MassUpdateRequest UpdateMassUpdateRequest(MassUpdateRequest request);

        IEnumerable<MassUpdateExportItem> GenerateMassExportList(string query, IEnumerable<string> properties);

        MainframeShippingAddressOverride GetFormattedAddress(ShippingLocation location);

        MainframeBillingAddressOverride GetFormattedAddress(BillingLocation location);

        string GetFormattedAddressString(ShippingLocation location);

        void ValidateEntity(object entity);

        void ValidateEntities<T>(List<T> entities);

        void ValidateRelatedLegacyMappingEntities(List<LegacyMapping> legacyMappings);

        UnassociatedIds UnAssociateAllProfiles(LegacyMapping mapping);

        //string GetActiveDirectorySecurityId(GetActiveDirectorySecurityIdRequest request);

        EmployeeSearchResults SearchActiveDirectory(string name, string emailAddress, int skip, int take);
        GetActiveDirectoryEmployeeResponse GetActiveDirectoryEmployee(GetActiveDirectoryEmployeeRequest getActiveDirectoryEmployeeRequest);

        List<contract.Employee> GetEmployeesByRole(string role);

        void LogActivateDeactivateCustomerAccount(Customer customer, string changedBy, bool isActive);

        List<CustomerPricingInfo> GetCustomerPricingInfos(List<CustomerAccountIdentifier> customerAccounts);
    }
}
