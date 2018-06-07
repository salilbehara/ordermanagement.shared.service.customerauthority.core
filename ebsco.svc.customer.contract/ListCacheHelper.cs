using ebsco.svc.customer.contract.LookupItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace ebsco.svc.customer.contract
{
    public static class ListCacheHelper
    {
        public static IEnumerable<StatesProvincesLookup> GetStateProvinceCodes(IRepository repository)
        {
            ObjectCache cache = MemoryCache.Default;
            var stateProvinceCodes = cache["StateProvinceCodes"] as StatesProvincesLookup[];
            if (stateProvinceCodes == null || stateProvinceCodes.Count() == 0)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                stateProvinceCodes = repository.GetStateProvinces(null).ToArray();
                cache.Set("StateProvinceCodes", stateProvinceCodes, DateTime.Now.AddHours(1));
            }
            return stateProvinceCodes.ToArray();
        }

        public static IEnumerable<CountryLookup> GetCountries(IRepository repository)
        {
            ObjectCache cache = MemoryCache.Default;
            var countries = cache["Countries"] as CountryLookup[];
            if (countries == null || countries.Count() == 0)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                countries = repository.GetCountries().ToArray();
                cache.Set("Countries", countries, DateTime.Now.AddHours(1));
            }
            return countries;
        }

        public static IEnumerable<JetsAddressListLookup> GetJetsAddressList(IRepository repository)
        {
            ObjectCache cache = MemoryCache.Default;
            var jetsAddressList = cache["JetsAddressList"] as JetsAddressListLookup[];
            if (jetsAddressList == null || jetsAddressList.Count() == 0)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                jetsAddressList = repository.GetJetsAddressList().ToArray();
                cache.Set("JetsAddressList", jetsAddressList, DateTime.Now.AddHours(1));
            }
            return jetsAddressList;
        }

        public static IEnumerable<DropAddressListLookup> GetDropAddressList(IRepository repository)
        {
            ObjectCache cache = MemoryCache.Default;
            var dropAddressList = cache["DropAddressList"] as DropAddressListLookup[];
            if (dropAddressList == null || dropAddressList.Count() == 0)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                dropAddressList = repository.GetDropAddressList().ToArray();
                cache.Set("DropAddressList", dropAddressList, DateTime.Now.AddHours(1));
            }
            return dropAddressList;
        }

        public static IEnumerable<OfficeLookup> GetOfficeList(IRepository repository)
        {
            ObjectCache cache = MemoryCache.Default;
            var OfficeList = cache["OfficeList"] as OfficeLookup[];
            if (OfficeList == null || OfficeList.Count() == 0)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                OfficeList = repository.GetLookupValues<OfficeLookup>().ToArray();
                cache.Set("OfficeList", OfficeList, DateTime.Now.AddHours(1));
            }
            return OfficeList;
        }
    }
}
