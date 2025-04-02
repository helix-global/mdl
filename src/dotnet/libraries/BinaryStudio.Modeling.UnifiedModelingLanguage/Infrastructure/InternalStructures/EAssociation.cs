using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EAssociation : EClassifier,Association
        {
        public IList<Element> RelatedElement { get; }
        public IList<Type> EndType { get; }
        public Boolean IsDerived { get;set; }
        public IList<Property> MemberEnd { get; }
        public IList<Property> NavigableOwnedEnd { get; }
        public IList<Property> OwnedEnd { get; }
        public Type[] endType()
            {
            throw new NotImplementedException();
            }

        public EAssociation()
            {
            MemberEnd = new List<Property>();
            }
        }
    }