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
        }
    }