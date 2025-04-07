using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalTag : PetalLiteral
        {
        public Int64 Tag { get; }
        public PetalTag(Int64 tag)
            {
            Tag = tag;
            }
        }
    }