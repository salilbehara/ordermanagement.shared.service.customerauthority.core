using ebsco.svc.customer.contract.MessageContracts.Faults;
using ebsco.svc.customer.contract.MessageContracts.Requests;
using ebsco.svc.customer.contract.MessageContracts.Responses;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    [ServiceKnownType(typeof(BillingLocation))]
    [ServiceKnownType(typeof(ShippingLocation))]
    public interface ICustomerService
    {
        [OperationContract]
        GetCustomerResponse GetCustomer(GetCustomerRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateSecondaryCustomerProfileResponse CreateSecondaryCustomerProfile(CreateSecondaryCustomerProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateSecondaryCustomerProfileResponse UpdateSecondaryCustomerProfile(UpdateSecondaryCustomerProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteSecondaryCustomerProfileResponse DeleteSecondaryCustomerProfile(DeleteSecondaryCustomerProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateRenewalProfileResponse CreateRenewalProfile(CreateRenewalProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateRenewalProfileResponse UpdateRenewalProfile(UpdateRenewalProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteRenewalProfileResponse DeleteRenewalProfile(DeleteRenewalProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreatePricingProfileResponse CreatePricingProfile(CreatePricingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdatePricingProfileResponse UpdatePricingProfile(UpdatePricingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeletePricingProfileResponse DeletePricingProfile(DeletePricingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateInvoiceProfileResponse CreateInvoiceProfile(CreateInvoiceProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateInvoiceProfileResponse UpdateInvoiceProfile(UpdateInvoiceProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteInvoiceProfileResponse DeleteInvoiceProfile(DeleteInvoiceProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateOrderProfileResponse CreateOrderProfile(CreateOrderProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateOrderProfileResponse UpdateOrderProfile(UpdateOrderProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteOrderProfileResponse DeleteOrderProfile(DeleteOrderProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateIlsProfileResponse CreateIlsProfile(CreateIlsProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateIlsProfileResponse UpdateIlsProfile(UpdateIlsProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteIlsProfileResponse DeleteIlsProfile(DeleteIlsProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateCCICodingProfileResponse CreateCCICodingProfile(CreateCCICodingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateCCICodingProfileResponse UpdateCCICodingProfile(UpdateCCICodingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteCCICodingProfileResponse DeleteCCICodingProfile(DeleteCCICodingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateCreditsAndAdjustmentsProfileResponse CreateCreditsAndAdjustmentsProfile(CreateCreditsAndAdjustmentsProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateCreditsAndAdjustmentsProfileResponse UpdateCreditsAndAdjustmentsProfile(UpdateCreditsAndAdjustmentsProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteCreditsAndAdjustmentsProfileResponse DeleteCreditsAndAdjustmentsProfile(DeleteCreditsAndAdjustmentsProfileRequest request);


        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateReportingProfileResponse CreateReportingProfile(CreateReportingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateReportingProfileResponse UpdateReportingProfile(UpdateReportingProfileRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteReportingProfileResponse DeleteReportingProfile(DeleteReportingProfileRequest request);

        [OperationContract]
        AccountSearchResponse AccountSearch(AccountSearchRequest request);

        [OperationContract]
        AddressSearchResponse AddressSearch(AddressSearchRequest request);

        [OperationContract]
        ActiveDirectorySearchResponse ActiveDirectorySearch(ActiveDirectorySearchRequest request);

        [OperationContract]
        ContactSearchResponse ContactSearch(ContactSearchRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateContactResponse CreateContact(CreateContactRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateShippingLocationResponse CreateShippingLocation(CreateShippingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateShippingLocationResponse UpdateShippingLocation(UpdateShippingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteShippingLocationResponse DeleteShippingLocation(DeleteShippingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateBillingLocationResponse CreateBillingLocation(CreateBillingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateBillingLocationResponse UpdateBillingLocation(UpdateBillingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteBillingLocationResponse DeleteBillingLocation(DeleteBillingLocationRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        CreateCustomerIPAddressResponse CreateCustomerIPAddress(CreateCustomerIPAddressRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        UpdateCustomerIPAddressResponse UpdateCustomerIPAddress(UpdateCustomerIPAddressRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteCustomerIPAddressResponse DeleteCustomerIPAddress(DeleteCustomerIPAddressRequest request);

        [OperationContract]
        UpdateContactResponse UpdateContact(UpdateContactRequest request);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        DeleteContactResponse DeleteContact(DeleteContactRequest request);

        [OperationContract]
        UpdateCustomerResponse UpdateCustomer(UpdateCustomerRequest request);

        [OperationContract]
        CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);

        [OperationContract]
        DeactivateCustomerResponse DeactivateCustomer(DeactivateCustomerRequest request);

        [OperationContract]
        ActivateCustomerResponse ActivateCustomer(ActivateCustomerRequest request);

        [OperationContract]
        UpdateEmployeeResponse UpdateEmployee(UpdateEmployeeRequest request);

        [OperationContract]
        GetCustomerByLegacyMappingResponse GetCustomerByLegacyMapping(GetCustomerByLegacyMappingRequest request);

        [OperationContract]
        CreateLegacyMappingResponse CreateLegacyMapping(CreateLegacyMappingRequest request);

        [OperationContract]
        UpdateLegacyMappingResponse UpdateLegacyMapping(UpdateLegacyMappingRequest request);

        [OperationContract]
        UpdateLegacyMappingsResponse UpdateLegacyMappings(UpdateLegacyMappingsRequest request);

        [OperationContract]
        DeleteLegacyMappingResponse DeleteLegacyMapping(DeleteLegacyMappingRequest request);

        [OperationContract]
        GetFormattedAddressResponse GetFormattedAddress(GetFormattedAddressRequest request);

        [OperationContract]
        GetFormattedBillingAddressResponse GetFormattedBillingAddress(GetFormattedBillingAddressRequest request);

        [OperationContract]
        GetActiveDirectoryEmployeeResponse GetActiveDirectoryEmployee(GetActiveDirectoryEmployeeRequest request);

        [OperationContract]
        GetEmployeeResponse GetEmployeeBySid(GetEmployeeBySidRequest request);

        [OperationContract]
        GetEmployeeResponse GetEmployeeById(GetEmployeeByIdRequest request);

        [OperationContract]
        GetEmployeesByRoleResponse GetEmployeesByRoleType(GetEmployeesByRoleRequest request);

        [OperationContract]
        GetNextAvailableAccountNumberResponse GetNextAvailableAccountNumber(GetNextAvailableAccountNumberRequest request);

        [OperationContract]
        GetCustomerPricingInfoResponse GetCustomerPricingInfo(GetCustomerPricingInfoRequest request);
    }


}
