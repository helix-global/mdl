using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalObject : PetalNode
        {
        public String Name { get;internal set; }
        public List<String> PetalStrings { get; }
        public PetalTag Tag { get;internal set; }
        public IList<PetalProperty> Properties { get; }

        public PetalObject()
            :base()
            {
            PetalStrings = new List<String>();
            Properties = new List<PetalProperty>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"OBJECT:{{{Name}}}";
            }
        #endregion
        }
    }