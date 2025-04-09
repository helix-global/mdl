using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalReference : PetalLiteral
        {
        public Int64 Tag { get; }
        public PetalReference(Int64 tag)
            {
            Tag = tag;
            }
        }
    }