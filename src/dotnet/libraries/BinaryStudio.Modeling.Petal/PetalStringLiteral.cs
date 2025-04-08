using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalStringLiteral : PetalLiteral<String>
        {
        public PetalStringLiteral(String value)
            : base(value)
            {
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $@"""{LiteralValue}""";
            }
        #endregion
        }
    }