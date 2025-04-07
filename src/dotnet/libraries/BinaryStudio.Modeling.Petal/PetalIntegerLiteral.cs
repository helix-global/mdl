using System;

namespace BinaryStudio.Modeling.Petal
    {
    using Integer=Int64;
    public class PetalIntegerLiteral : PetalLiteral<Integer>
        {
        public PetalIntegerLiteral(Integer value)
            :base(value)
            {
            }
        }
    }