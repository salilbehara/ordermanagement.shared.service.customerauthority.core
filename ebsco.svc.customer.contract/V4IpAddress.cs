using System;

namespace ebsco.svc.customer.contract
{
    public struct V4IpAddress : IComparable, IComparable<V4IpAddress>, IEquatable<V4IpAddress>
    {
        public V4IpAddress(byte node1, byte node2, byte node3, byte node4)
        {
            Node1 = node1;
            Node2 = node2;
            Node3 = node3;
            Node4 = node4;
        }

        public byte Node1 { get; }

        public byte Node2 { get; }

        public byte Node3 { get; }

        public byte Node4 { get; }

        public int CompareTo(V4IpAddress other)
        {
            if (Node1 > other.Node1)
            {
                return 1;
            }
            if (Node1 < other.Node1)
            {
                return -1;
            }
            if (Node2 > other.Node2)
            {
                return 1;
            }
            if (Node2 < other.Node2)
            {
                return -1;
            }
            if (Node3 > other.Node3)
            {
                return 1;
            }
            if (Node3 < other.Node3)
            {
                return -1;
            }
            if (Node4 > other.Node4)
            {
                return 1;
            }
            if (Node4 < other.Node4)
            {
                return -1;
            }
            return 0;
        }

        public bool Equals(V4IpAddress other)
        {
            return Node1 == other.Node1 && Node2 == other.Node2 && Node3 == other.Node3 && Node4 == other.Node4;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Node1.GetHashCode() ^ Node2.GetHashCode() ^ Node3.GetHashCode() ^ Node4.GetHashCode();
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is V4IpAddress))
            {
                return 1;
            }
            return CompareTo((V4IpAddress) obj);
        }

        public static bool operator ==(V4IpAddress left, V4IpAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(V4IpAddress left, V4IpAddress right)
        {
            return !(left == right);
        }

        public static bool operator >(V4IpAddress left, V4IpAddress right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <(V4IpAddress left, V4IpAddress right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(V4IpAddress left, V4IpAddress right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <=(V4IpAddress left, V4IpAddress right)
        {
            return left.CompareTo(right) <= 0;
        }

        public override string ToString()
        {
            return $"{Node1}.{Node2}.{Node3}.{Node4}";
        }
    }
}
