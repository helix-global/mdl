using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EElement : Element
        {
        public IList<Comment> OwnedComment { get; }
        public IList<Element> OwnedElement { get; }
        public Element Owner { get; }

        protected EElement()
            {
            OwnedComment = new List<Comment>();
            }

        public Element[] allOwnedElements()
            {
            throw new NotImplementedException();
            }

        public Boolean mustBeOwned()
            {
            throw new NotImplementedException();
            }
        }
    }