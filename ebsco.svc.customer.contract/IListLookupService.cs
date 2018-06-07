using ebsco.svc.customer.contract.LookupItems;
using ebsco.svc.customer.contract.MessageContracts.Requests;
using ebsco.svc.customer.contract.MessageContracts.Responses;
using System;
using System.ServiceModel;

namespace ebsco.svc.customer.contract
{
    [ServiceContract]
    [ServiceKnownType(typeof(ProductTypeLookup))]
    [ServiceKnownType(typeof(CustomerCategoryCodeLookup))]
    [ServiceKnownType(typeof(VLIPIndicatorLookup))]
    [ServiceKnownType(typeof(ServiceChargeDiscountTypeLookup))]
    [ServiceKnownType(typeof(SatelliteOfficeLookup))]
    [ServiceKnownType(typeof(ContactType))]
    [ServiceKnownType(typeof(EDIMethodLookup))]
    [ServiceKnownType(typeof(EmployeeRoleTypeLookup))]
    [ServiceKnownType(typeof(EPTerritoryLookup))]
    [ServiceKnownType(typeof(ESSOfficeLookup))]
    [ServiceKnownType(typeof(FTECountTypeLookup))]
    [ServiceKnownType(typeof(FTESourceLookup))]
    [ServiceKnownType(typeof(CarnegieClassificationLookup))]
    [ServiceKnownType(typeof(ILSSystemLookup))]
    [ServiceKnownType(typeof(ILSFormatLookup))]
    [ServiceKnownType(typeof(ILSOrganizationLookup))]
    [ServiceKnownType(typeof(InvoiceTypeLookup))]
    [ServiceKnownType(typeof(LegacySystemLookup))]
    [ServiceKnownType(typeof(MARCRequestSalesChannelLookup))]
    [ServiceKnownType(typeof(MarketSegmentLookup))]
    [ServiceKnownType(typeof(OfficeLookup))]
    [ServiceKnownType(typeof(OPSTeamLookup))]
    [ServiceKnownType(typeof(StatesProvincesLookup))]
    [ServiceKnownType(typeof(CountryLookup))]
    [ServiceKnownType(typeof(CustomerClassLookup))]
    [ServiceKnownType(typeof(ARCurrencyCodeLookup))]
    [ServiceKnownType(typeof(RenewalCycleLookup))]
    [ServiceKnownType(typeof(CashDiscountLookup))]
    [ServiceKnownType(typeof(ConsolidatedInvoiceParameterLookup))]
    [ServiceKnownType(typeof(LongTerm1Lookup))]
    [ServiceKnownType(typeof(LongTerm2Lookup))]
    [ServiceKnownType(typeof(CumulativeReportFrequencyLookup))]
    [ServiceKnownType(typeof(SplitInvoiceByLookup))]
    [ServiceKnownType(typeof(MailInvoicesToLookup))]
    [ServiceKnownType(typeof(PrintCommentLinesLookup))]
    [ServiceKnownType(typeof(PurchaseOrderFlagLookup))]
    [ServiceKnownType(typeof(ClaimCheckerReportLookup))]
    [ServiceKnownType(typeof(ClaimCheckerAgeLookup))]
    [ServiceKnownType(typeof(EJSCustomerLookup))]
    [ServiceKnownType(typeof(EDISystemLookup))]
    [ServiceKnownType(typeof(FirmFixedAccountLookup))]
    [ServiceKnownType(typeof(MailRenewalsToLookup))]
    [ServiceKnownType(typeof(RenewalsCopyToMailLookup))]
    [ServiceKnownType(typeof(RenewalOrderLookup))]
    [ServiceKnownType(typeof(ARClerkLookup))]
    [ServiceKnownType(typeof(SalesmanCodeLookup))]
    [ServiceKnownType(typeof(FundCodeRequiredLookup))]
    [ServiceKnownType(typeof(ERMRatesLookup))]
    public interface IListLookupService: IDisposable
    {
        [OperationContract]
        GetLookupValuesResponse<ProductTypeLookup> GetProductTypes();

        [OperationContract]
        GetLookupValuesResponse<CustomerCategoryCodeLookup> GetCustomerCategoryCodes();

        [OperationContract]
        GetLookupValuesResponse<VLIPIndicatorLookup> GetVLIPIndicators();

        [OperationContract]
        GetLookupValuesResponse<ServiceChargeDiscountTypeLookup> GetServiceChargeDiscountTypes();

        [OperationContract]
        GetLookupValuesResponse<ContactTypeLookup> GetContactTypes();

        [OperationContract]
        GetLookupValuesResponse<EDIMethodLookup> GetEDIMethods();

        [OperationContract]
        GetLookupValuesResponse<EmployeeRoleTypeLookup> GetEmployeeRoleTypes();

        [OperationContract]
        GetLookupValuesResponse<EPTerritoryLookup> GetEPTerritories();

        [OperationContract]
        GetLookupValuesResponse<ESSOfficeLookup> GetESSOffices();

        [OperationContract]
        GetLookupValuesResponse<FTECountTypeLookup> GetFTECountTypes();
        [OperationContract]
        GetLookupValuesResponse<FTESourceLookup> GetFTESource();

        [OperationContract]
        GetLookupValuesResponse<CarnegieClassificationLookup> GetCarnegieClassifications();

        [OperationContract]
        GetLookupValuesResponse<ILSSystemLookup> GetILSSystems(GetILSSystemRequest request);

        [OperationContract]
        GetLookupValuesResponse<ILSFormatLookup> GetILSFormats();

        [OperationContract]
        GetLookupValuesResponse<ILSOrganizationLookup> GetILSOrganizations();

        [OperationContract]
        GetLookupValuesResponse<InvoiceTypeLookup> GetInvoiceTypes();

        [OperationContract]
        GetLookupValuesResponse<LegacySystemLookup> GetLegacySystems();

        [OperationContract]
        GetLookupValuesResponse<MARCRequestSalesChannelLookup> GetMARCRequestSalesChannels();

        [OperationContract]
        GetLookupValuesResponse<MarketSegmentLookup> GetMarketSegments();

        [OperationContract]
        GetLookupValuesResponse<OfficeLookup> GetOffices();

        [OperationContract]
        GetLookupValuesResponse<OPSTeamLookup> GetOPSTeams();

        [OperationContract]
        GetLookupValuesResponse<CustomerClassLookup> GetCustomerClasses();

        [OperationContract]
        GetLookupValuesResponse<ARCurrencyCodeLookup> GetARCurrencies();

        [OperationContract]
        GetLookupValuesResponse<LanguageKeyLookup> GetLanguageKeys(GetLanguageKeysRequest request);

        [OperationContract]
        GetLookupValuesResponse<JetsAddressListLookup> GetJetsAddressList(GetJetsAddressListRequest request);

        [OperationContract]
        GetLookupValuesResponse<DropAddressListLookup> GetDropAddressList(GetDropAddressListRequest request);

        [OperationContract]
        GetLookupValuesResponse<PricingMethodLookup> GetPricingMethods();

        [OperationContract]
        GetLookupValuesResponse<StatesProvincesLookup> GetStatesProvinces(GetStateProvincesRequest request);


        [OperationContract]
        GetLookupValuesResponse<SatelliteOfficeLookup> GetSatelliteOffices(GetSatelliteOfficesRequest request);

        [OperationContract]
        GetLookupValuesResponse<CountryLookup> GetCountries();

        [OperationContract]
        GetLookupValuesResponse<RenewalCycleLookup> GetRenewalCycles();

        [OperationContract]
        GetLookupValuesResponse<PriceIncreaseAlertLookup> GetPriceIncreaseAlerts();

        [OperationContract]
        GetLookupValuesResponse<CashDiscountLookup> GetCashDiscounts();

        [OperationContract]
        GetLookupValuesResponse<ConsolidatedInvoiceParameterLookup> GetConsolidatedInvoiceParameters();

        [OperationContract]
        GetLookupValuesResponse<PrintCommentLinesLookup> GetPrintCommentLines();

        [OperationContract]
        GetLookupValuesResponse<MailInvoicesToLookup> GetMailInvoicesTo();

        [OperationContract]
        GetLookupValuesResponse<LongTerm1Lookup> GetLongTerm1();

        [OperationContract]
        GetLookupValuesResponse<LongTerm2Lookup> GetLongTerm2();

        [OperationContract]
        GetLookupValuesResponse<CumulativeReportFrequencyLookup> GetCumulativeReportFrequency();

        [OperationContract]
        GetLookupValuesResponse<SplitInvoiceByLookup> GetSplitInvoiceBy();

        [OperationContract]
        GetLookupValuesResponse<SortByISCLookup> GetSortByISC();

        [OperationContract]
        GetLookupValuesResponse<PurchaseOrderFlagLookup> GetPurchaseOrderFlags();

        [OperationContract]
        GetLookupValuesResponse<ClaimCheckerAgeLookup> GetClaimCheckerAges();

        [OperationContract]
        GetLookupValuesResponse<ClaimCheckerReportLookup> GetClaimCheckerReports();

        [OperationContract]
        GetLookupValuesResponse<DeliveryMethodLookup> GetDeliveryMethods();

        [OperationContract]
        GetLookupValuesResponse<FormatCodeLookup> GetFormatCodes();

        [OperationContract]
        GetLookupValuesResponse<PostageLookup> GetPostages();

        [OperationContract]
        GetLookupValuesResponse<PreferenceCodeLookup> GetPreferenceCodes();

        [OperationContract]
        GetLookupValuesResponse<RateClassLookup> GetRateClasses();

        [OperationContract]
        GetLookupValuesResponse<EJSCustomerLookup> GetEJSCustomers();

        [OperationContract]
        GetLookupValuesResponse<EDISystemLookup> GetEDISystems();

        [OperationContract]
        GetLookupValuesResponse<FirmFixedAccountLookup> GetFirmFixedAccount();

        [OperationContract]
        GetLookupValuesResponse<MailRenewalsToLookup> GetMailRenewalsTo();

        [OperationContract]
        GetLookupValuesResponse<RenewalsCopyToMailLookup> GetRenewalsCopyToMail();

        [OperationContract]
        GetLookupValuesResponse<RenewalOrderLookup> GetRenewalOrderLookup();

        [OperationContract]
        GetLookupValuesResponse<ARClerkLookup> GetARClerkLookup();
        
        [OperationContract]
        GetLookupValuesResponse<SalesmanCodeLookup> GetSalesmanCodeLookup();

        [OperationContract]
        GetLookupValuesResponse<FundCodeRequiredLookup> GetFundCodeRequired();

        [OperationContract]
        GetLookupValuesResponse<ERMRatesLookup> GetERMRates();

    }
}
