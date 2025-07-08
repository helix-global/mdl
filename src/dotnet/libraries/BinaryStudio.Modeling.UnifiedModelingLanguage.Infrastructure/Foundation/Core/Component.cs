using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Component : Classifier
        {
        Node[] deploymentLocation { get; }
        Artifact[] implementation { get; }
        IList<ElementResidence> resident { get; }
        }
    }
