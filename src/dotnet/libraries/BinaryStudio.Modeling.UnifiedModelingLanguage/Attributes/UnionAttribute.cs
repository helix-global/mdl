using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes
    {
    public class UnionAttribute : Attribute
        {
        public Boolean IsUnion { get; }
        public UnionAttribute(Boolean union)
            {
            IsUnion = union;
            }

        public UnionAttribute()
            :this(true)
            {
            }
        }
    }