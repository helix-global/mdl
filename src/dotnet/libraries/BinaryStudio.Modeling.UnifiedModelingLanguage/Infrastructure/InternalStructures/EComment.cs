using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EComment : EElement,Comment
        {
        public IList<Element> AnnotatedElement { get; }
        public String Body { get;set; }

        public EComment()
            {
            AnnotatedElement = new List<Element>();
            }
        }
    }