using System;

namespace BinaryStudio.Modeling.MetadataInterchange
    {
    public class IsIDREFAttribute : Attribute
        {
        public static readonly IsIDREFAttribute No  = new IsIDREFAttribute(false);
        public static readonly IsIDREFAttribute Yes = new IsIDREFAttribute(true);
        public static readonly IsIDREFAttribute Default = No;

        public Boolean IsIDREF { get; }
        public IsIDREFAttribute(Boolean value)
            {
            IsIDREF = value;
            }

        public IsIDREFAttribute()
            :this(true)
            {
            }

        #region M:IsDefaultAttribute:Boolean
        /// <summary>When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.</summary>
        /// <returns><see langword="true"/> if this instance is the default attribute for the class; otherwise, <see langword="false"/>.</returns>
        public override Boolean IsDefaultAttribute()
            {
            return Equals(Default);
            }
        #endregion
        #region M:GetHashCode:Int32
        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override Int32 GetHashCode()
            {
            return IsIDREF.GetHashCode();
            }
        #endregion
        #region M:Equals(Object):Boolean
        /// <summary>Returns a value that indicates whether this instance is equal to a specified object.</summary>
        /// <param name="other">An <see cref="T:System.Object"/> to compare with this instance or <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="other"/> and this instance are of the same type and have identical field values; otherwise, <see langword="false"/>.</returns>
        public override Boolean Equals(Object other) {
            if (ReferenceEquals(other,this)) { return true; }
            return (other is IsIDREFAttribute attribute) && (IsIDREF == attribute.IsIDREF);
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return IsIDREF
                ? "Yes"
                : "No";
            }
        #endregion
        }
    }