using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EComment : EElement,Comment
        {
        [IsIDREF] public IList<Element> AnnotatedElement { get; }
        public String Body { get;set; }

        public EComment()
            {
            AnnotatedElement = new List<Element>();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return $"Comment";
            }
        #endregion
        }
    }