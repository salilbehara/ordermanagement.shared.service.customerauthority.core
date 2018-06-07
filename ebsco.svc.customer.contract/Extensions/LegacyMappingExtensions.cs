using System;
using System.Collections.Generic;
using System.Linq;

namespace ebsco.svc.customer.contract.Extensions
{
    public static class LegacyMappingExtensions
    {
        /// <summary>
        /// Filters a list of items with legacy mappings by subscriber code.
        /// Throws ArgumentException if subscriber code is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemList"></param>
        /// <param name="subscriberFilter"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilterBySubscriber<T>(this IEnumerable<T> itemList, string subscriberFilter)
            where T : IHasLegacyMappings
        {
            if (string.IsNullOrEmpty(subscriberFilter))
            {
                throw new ArgumentException("Value cannot be null or empty", nameof(subscriberFilter));
            }
            return itemList.Where(item => item.LegacyMappings.Any(
                lmapping => lmapping.LegacySystemName == LegacySystemName.SubscriberName && lmapping
                                .LegacyIdentifier.Substring(8, 2)
                                .ToUpper()
                                .Contains(subscriberFilter.ToUpper())));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemList"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilterBySuffix<T>(this IEnumerable<T> itemList, int suffix)
            where T : IHasLegacyMappings
        {
            return itemList.Where(item => item.LegacyMappings.Any(
                lmapping => lmapping.LegacySystemName == LegacySystemName.SuffixName && lmapping
                                .LegacyIdentifier.Substring(8, 2)
                                .EndsWith(suffix.ToString("00"))));
        }
    }
}
