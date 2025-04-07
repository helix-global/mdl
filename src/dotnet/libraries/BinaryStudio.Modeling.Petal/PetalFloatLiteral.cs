using System;

namespace BinaryStudio.Modeling.Petal
    {
    using Float=Double;
    public class PetalFloatLiteral : PetalLiteral<Float>
        {
        public PetalFloatLiteral(Float value)
            : base(value)
            {
            }
        }
    }