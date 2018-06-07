using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ebsco.svc.customer.contract.FeatureFlags
{
    public class FeaturesEnum
    {
        public const string CreditsAndAdjustmentsProfile = "CA.F17009.CreditsAndAdjustmentsProfile";
        public const string CcisAddedToInvoicesProfile = "CA.F13205.CcisAddedToInvoicesProfile";
        public const string EJSCustomer = "CA.US265488.EJSCustomer";
        public const string AtoZCustomer = "CA.US265498.AtoZCustomer";
        public const string NetPublisherLogic = "CA.US265490.NetPublisherLogic";
        public const string AToZCustomerWithLinksource = "CA.US265486.AtoZCustomerWithLinksource";
        public const string AToZCustomerWithMarcUpdates = "CA.US265486.AtoZCustomerWithMarcUpdates";
        public const string EmailCSRForEJournalUpdates = "CA.US265496.EmailCSRForEJournalUpdates";
        public const string CcisAddedToRenewalsProfile = "CA.F17008.CcisAddedToRenewalsProfile";
        public const string CcisMovedToRenewalsProfile = "CA.F17008.CcisMovedToRenewalsProfile";
        public const string CcisAddedToOrdersProfile = "CA.F20159.CcisAddedToOrdersProfile";
        public const string AddJetsDropAddress = "CA.F14903.JetsDropAddressAddedToShippingLocation";
        public const string AccountSearchPagination = "CA.US296170.AccountSearchPagination";
        public const string ManageSuffixes = "CA.F16926.ManageSuffixes";
        public const string IsolationLevelReadCommitted = "CA.US310457.IsolationLevelReadCommitted";
        public const string HoldUntilCurrentRatesAvailable = "CA.F21916.US326748.HoldUntilCurrentRatesAvailable";
        public const string SyncEmployeeDetailToSAP = "CA.F13895.US324130.SyncEmployeeDetailToSAP";
        public const string PricingClassification = "CA.F20329.US324244.SyncPricingClassificationToMF";
        public const string CustomerValidation = "CA.F13895.US352519.EnableCustomerValidation";
        public const string Employee = "CA.F13895.US324085.SyncEmployeeToMF";
        public const string ManageBillingAddresses = "CA.F7222.US326097.BillingLocationSAPSync";
        public const string SplitTaxExemptAndVatOnShippingProfile = "CA.F7222.US308867.SplitTaxExemptAndVat";
        public const string FundCodeFields = "CA.F20178.US364214.FundCodeFields";
        public const string EDISystem = "CA.F24216.US362302.AddEDISystemToInvoiceProfile";
        public const string AddInflationRatesToPricingProfile = "CA.F25193.US366167.AddInflationRatesToPricingProfile";
        public const string ValidateBillingLocationInSAPForAllUpdates = "CA.F7222.US372552.ValidateBillingLocationInSAPForAllUpdates";
        public const string AddRemainingCCILines = "CA.F25195.AddRemainingCCILines";

    }
}