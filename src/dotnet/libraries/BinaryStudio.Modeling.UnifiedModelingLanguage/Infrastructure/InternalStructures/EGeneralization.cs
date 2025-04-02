using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EGeneralization : EDirectedRelationship,Generalization
        {
        [IsIDREF] public Classifier General { get;set; }
        public IList<GeneralizationSet> GeneralizationSet { get; }
        public Boolean? IsSubstitutable { get;set; }
        public Classifier Specific { get;set; }

        public EGeneralization()
            {
            GeneralizationSet = new List<GeneralizationSet>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return $"Generalization";
            }
        #endregion
        }
    }