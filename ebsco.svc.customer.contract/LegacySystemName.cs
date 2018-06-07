using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ebsco.svc.customer.contract
{
    [ExcludeFromCodeCoverage]
    public class LegacySystemName
    {
        private string _name;
        public static readonly string AccountName = "Mainframe - Account";
        public static readonly string SuffixName = "Mainframe - Suffix";
        public static readonly string SubscriberName = "Mainframe - Subscriber";
        public static readonly string DDECustomerID = "DDE Customer ID";

        public LegacySystemName(string name)
        {
            Name = name;
        }

        public static readonly HashSet<string> AllowedNames = new HashSet<string>
        {
            AccountName,
            SuffixName,
            SubscriberName,
            DDECustomerID
        };

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (AllowedNames.Contains(value))
                {
                    _name = value;
                    return;
                }
                throw new ApplicationException("System name is invalid");
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class LegacySystemNames
    {
        public static readonly LegacySystemName Account = new LegacySystemName(LegacySystemName.AccountName);
        public static readonly LegacySystemName Suffix = new LegacySystemName(LegacySystemName.SuffixName);
        public static readonly LegacySystemName Subscriber = new LegacySystemName(LegacySystemName.SubscriberName);
        public static readonly LegacySystemName DDECustomerID = new LegacySystemName(LegacySystemName.DDECustomerID);

        public static readonly HashSet<LegacySystemName> AllowedSystems = new HashSet<LegacySystemName>
        {
            Account,
            Suffix,
            Subscriber,
            DDECustomerID
        };
    }
}
