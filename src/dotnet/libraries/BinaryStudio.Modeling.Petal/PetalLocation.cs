using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalLocation : PetalNode
        {
        public Int64 X { get;internal set; }
        public Int64 Y { get;internal set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"LOC:({X},{Y})";
            }
        #endregion
        }
    }