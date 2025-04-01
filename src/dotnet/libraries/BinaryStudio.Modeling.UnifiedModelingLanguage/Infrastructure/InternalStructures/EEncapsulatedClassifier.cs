using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EEncapsulatedClassifier : EStructuredClassifier,EncapsulatedClassifier
        {
        public IList<Port> OwnedPort { get; }
        public Port[] ownedPort()
            {
            throw new System.NotImplementedException();
            }
        }
    }