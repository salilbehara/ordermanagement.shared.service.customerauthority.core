using System;
using System.Collections.Generic;

namespace ebsco.svc.customer.contract
{
    public struct V4IPRange :IEquatable<V4IPRange>
    {
        public static readonly List<V4IPRange> PrivateIPRanges =
            new List<V4IPRange>
            {
                new V4IPRange(new V4IpAddress(10, 0, 0, 0), new V4IpAddress(10,255,255,255)),
                new V4IPRange(new V4IpAddress(172, 16, 0, 0), new V4IpAddress(172,31,255,255)),
                new V4IPRange(new V4IpAddress(192, 168, 0, 0), new V4IpAddress(192,168,255,255))
            };

        public V4IPRange(V4IpAddress start, V4IpAddress end)
        {
            if (start > end)
            {
                throw new ArgumentException("End IP address cannot be less than start address.");
            }
            Start = start;
            End = end;
        }

        public V4IPRange(CustomerIPAddress address)
        {
            var toIpAllNull = address.IpAddressToNode1 == null
                              && address.IpAddressToNode2 == null
                              && address.IpAddressToNode3 == null
                              && address.IpAddressToNode4 == null;

            var toIpAllNotNull = address.IpAddressToNode1 != null
                                 && address.IpAddressToNode2 != null
                                 && address.IpAddressToNode3 != null
                                 && address.IpAddressToNode4 != null;

            if (!toIpAllNull && !toIpAllNotNull)
            {
                throw new ArgumentException("The to IP address must be either completely null or completely defined");
            }

            var start = new V4IpAddress(address.IpAddressFromNode1, address.IpAddressFromNode2, address.IpAddressFromNode3,
                address.IpAddressFromNode4);
            var end = toIpAllNotNull
                ? new V4IpAddress(address.IpAddressToNode1.Value, address.IpAddressToNode2.Value, address.IpAddressToNode3.Value,
                    address.IpAddressToNode4.Value)
                : new V4IpAddress(address.IpAddressFromNode1, address.IpAddressFromNode2, address.IpAddressFromNode3,
                    address.IpAddressFromNode4);

            if (start > end)
            {
                throw new ArgumentException("End IP address cannot be less than start address.");
            }
            Start = start;
            End = end;
        }

        public static bool HasOverlap(V4IPRange range1, V4IPRange range2)
        {
            return range1.Start <= range2.End
                   && range1.End >= range2.Start;
        }

        public bool HasOverlap(V4IPRange otherRange)
        {
            return HasOverlap(this, otherRange);
        }

        public bool IsIPAddressPublic()
        {
            foreach (var range in PrivateIPRanges)
            {
                if (HasOverlap(range))
                {
                    return false;
                }
            }
            return true;
        }
        public V4IpAddress Start { get; }
        public V4IpAddress End { get; }

        public bool Equals(V4IPRange other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is V4IPRange && Equals((V4IPRange) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Start.GetHashCode() * 397) ^ End.GetHashCode();
            }
        }

        public static bool operator ==(V4IPRange left, V4IPRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(V4IPRange left, V4IPRange right)
        {
            return !left.Equals(right);
        }
        public override string ToString()
        {
            return $"({Start}-{End})";
        }
    }
}
