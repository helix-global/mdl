using System;

namespace BinaryStudio.Modeling.Petal
    {
    public abstract class PetalLiteral : PetalNode
        {
        }

    public abstract class PetalLiteral<T> : PetalLiteral
        {
        public T LiteralValue { get; }
        protected PetalLiteral(T value)
            {
            LiteralValue = value;
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return LiteralValue.ToString();
            }
        #endregion
        }
    }