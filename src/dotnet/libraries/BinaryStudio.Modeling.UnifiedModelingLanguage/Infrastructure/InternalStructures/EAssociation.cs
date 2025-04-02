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

        public EAssociation()
            {
            MemberEnd = new List<Property>();
            OwnedEnd = new List<Property>();
            }

        public Type[] endType()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Association"
                : $"Association{{{Name}}}";
            }
        #endregion
        }
    }