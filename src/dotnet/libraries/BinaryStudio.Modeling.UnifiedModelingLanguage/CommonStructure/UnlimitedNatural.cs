using System;
using System.ComponentModel;
using System.Globalization;
using UType=System.Type;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    
    [TypeConverter(typeof(UnlimitedNaturalTypeConverter))]
    public struct UnlimitedNatural
        {
        public static readonly UnlimitedNatural Zero = new UnlimitedNatural();
        public static readonly UnlimitedNatural Unlimited = new UnlimitedNatural(true);

        private UInt64 Value {get;}
        public Boolean IsUnlimited {get;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public UnlimitedNatural(UInt64 source) {
            Value = source;
            IsUnlimited = false;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        private UnlimitedNatural(Boolean source) {
            Value = 0;
            IsUnlimited = source;
            }

        public override String ToString() {
            return IsUnlimited
                ? "*"
                : Value.ToString();
            }
        }

    public class UnlimitedNaturalTypeConverter : TypeConverter
        {
        /// <summary>Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns><see langword="true"/> if this converter can perform the conversion; otherwise, <see langword="false"/>.</returns>
        public override Boolean CanConvertFrom(ITypeDescriptorContext context,UType sourceType) {
            if (sourceType == typeof(String)) { return true; }
            if (sourceType == typeof(UnlimitedNatural)) { return true; }
            if (sourceType == typeof(UInt16)) { return true; }
            if (sourceType == typeof(UInt32)) { return true; }
            if (sourceType == typeof(UInt64)) { return true; }
            return base.CanConvertFrom(context, sourceType);
            }

        /// <summary>Converts the given object to the type of this converter, using the specified context and culture information.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <returns>An <see cref="T:System.Object"/> that represents the converted value.</returns>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
        public override Object ConvertFrom(ITypeDescriptorContext context,CultureInfo culture,Object value) {
            if (value is String S) {
                if (S == "*") { return UnlimitedNatural.Unlimited; }
                if (UInt64.TryParse(S,out var UI8)) { return new UnlimitedNatural(UI8); }
                }
            return base.ConvertFrom(context, culture, value);
            }
        }
    }