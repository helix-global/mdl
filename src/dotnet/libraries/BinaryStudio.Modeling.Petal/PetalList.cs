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
        }
    }