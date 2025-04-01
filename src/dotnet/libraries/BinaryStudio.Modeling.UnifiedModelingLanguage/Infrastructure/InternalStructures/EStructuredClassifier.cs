using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EStructuredClassifier : EClassifier,StructuredClassifier
        {
        public IList<Property> OwnedAttribute { get; }
        public IList<Connector> OwnedConnector { get; }
        public IList<Property> Part { get; }
        public IList<ConnectableElement> Role { get; }
        public ConnectableElement[] allRoles()
            {
            throw new System.NotImplementedException();
            }

        public Property[] part()
            {
            throw new System.NotImplementedException();
            }
        }
    }