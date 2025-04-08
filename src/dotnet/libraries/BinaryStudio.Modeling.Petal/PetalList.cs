using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalList : PetalNode
        {
        public String Name { get;internal set; }
        public IList<PetalNode> Nodes { get; }

        public PetalList()
            :base()
            {
            Nodes = new List<PetalNode>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"LIST:{{{Name}}}";
            }
        #endregion
        }
    }