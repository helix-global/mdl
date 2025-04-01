using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EGeneralization : EDirectedRelationship,Generalization
        {
        public Classifier General { get; set; }
        public IList<GeneralizationSet> GeneralizationSet { get; }
        public Boolean? IsSubstitutable { get; set; }
        public Classifier Specific { get; set; }

        public EGeneralization()
            {
            GeneralizationSet = new List<GeneralizationSet>();
            }
        }
    }