using System;
using System.Collections.Generic;

namespace pre
    {
    public class ObjectIdentifier : IEquatable<ObjectIdentifier>
        {
        public static readonly ObjectIdentifier Empty = new ObjectIdentifier();

        public String[] Values { get; }
        public ObjectIdentifier(params String [] args)
            {
            if (args.Length == 0) { throw new ArgumentOutOfRangeException(nameof(args)); }
            Values = args;
            }

        private ObjectIdentifier()
            {
            Values = Array.Empty<String>();
            }

        public ObjectIdentifier Append(ObjectIdentifier other) {
            if (other == null) { return this; }
            var r = new List<String>(Values);
            r.AddRange(other.Values);
            return new ObjectIdentifier(r.ToArray());
            }

        public override Int32 GetHashCode() {
            var r = 0;
            foreach (var value in Values) {
                r = HashCodeCombiner.GetHashCode(r,value.GetHashCode());
                }
            return r;
            }

        public override String ToString() {
            if (Values.Length == 0) { return "{none}"; }
            return String.Join(".",Values);
            }

        public bool Equals(ObjectIdentifier other)
            {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(ToString(),other.ToString());
            }

        public override bool Equals(object obj)
            {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ObjectIdentifier) obj);
            }
        }
    }