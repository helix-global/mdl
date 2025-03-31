using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes
    {
    public class OrderedAttribute : Attribute
        {
        public Boolean IsOrdered { get; }
        public OrderedAttribute(Boolean ordered)
            {
            IsOrdered = ordered;
            }

        public OrderedAttribute()
            :this(true)
            {
            }
        }
    }