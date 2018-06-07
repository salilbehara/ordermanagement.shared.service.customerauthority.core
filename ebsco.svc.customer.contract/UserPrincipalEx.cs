using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.AccountManagement;

namespace ebsco.svc.customer.contract
{
    [ExcludeFromCodeCoverage]
    public class UserPrincipalExSearchFilter : AdvancedFilters
    {
        public UserPrincipalExSearchFilter(Principal p) : base(p) { }
    }

    [ExcludeFromCodeCoverage]
    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("User")]
    public class UserPrincipalEx : UserPrincipal
    {
        // Inplement the constructor using the base class constructor. 
        public UserPrincipalEx(PrincipalContext context) : base(context)
        { }

        // Implement the constructor with initialization parameters.    
        public UserPrincipalEx(PrincipalContext context,
                             string samAccountName,
                             string password,
                             bool enabled) : base(context, samAccountName, password, enabled)
        { }

        UserPrincipalExSearchFilter searchFilter;

        new public UserPrincipalExSearchFilter AdvancedSearchFilter
        {
            get
            {
                if (null == searchFilter)
                    searchFilter = new UserPrincipalExSearchFilter(this);

                return searchFilter;
            }
        }

        // Create the "Title" property.    
        [DirectoryProperty("title")]
        public string Title
        {
            get
            {
                if (ExtensionGet("title").Length != 1)
                    return string.Empty;

                return (string)ExtensionGet("title")[0];
            }
            set { ExtensionSet("title", value); }
        }

        [DirectoryProperty("telephoneNumber")]
        public string PhoneNumber
        {
            get
            {
                if (ExtensionGet("telephoneNumber").Length != 1)
                    return string.Empty;

                return (string)ExtensionGet("telephoneNumber")[0];
            }
            set { ExtensionSet("telephoneNumber", value); }
        }

        // Implement the overloaded search method FindByIdentity.
        public static new UserPrincipalEx FindByIdentity(PrincipalContext context, string identityValue)
        {
            return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityValue);
        }

        // Implement the overloaded search method FindByIdentity. 
        public static new UserPrincipalEx FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            return (UserPrincipalEx)FindByIdentityWithType(context, typeof(UserPrincipalEx), identityType, identityValue);
        }
    }
}
