using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalValue : PetalLiteral
        {
        public String Name { get;internal set; }
        public String PetalString { get;internal set; }

        public PetalValue()
            :base()
            {
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"VALUE:{{{Name}}}";
            }
        #endregion
        }
    }