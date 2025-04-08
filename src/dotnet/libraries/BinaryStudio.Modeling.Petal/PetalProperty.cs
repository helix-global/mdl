using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalProperty
        {
        public String Name { get; }
        public PetalNode Value { get; }
        public PetalProperty(String name,PetalNode value)
            {
            Name = name;
            Value = value;
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"{Name}={Value}";
            }
        #endregion
        }
    }