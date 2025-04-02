using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EStructuredClassifier : EClassifier,StructuredClassifier
        {
        public IList<Property> OwnedAttribute { get; }
        public IList<Connector> OwnedConnector { get; }
        public IList<Property> Part { get; }
        public IList<ConnectableElement> Role { get; }

        protected EStructuredClassifier()
            {
            OwnedAttribute = new List<Property>();
            }

        public ConnectableElement[] allRoles()
            {
            throw new System.NotImplementedException();
            }

        public Property[] part()
            {
            throw new System.NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"StructuredClassifier"
                : $"StructuredClassifier{{{Name}}}";
            }
        #endregion
        }
    }