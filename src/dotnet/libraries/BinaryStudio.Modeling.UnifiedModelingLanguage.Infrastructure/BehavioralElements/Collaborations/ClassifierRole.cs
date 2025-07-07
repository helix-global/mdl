using System.Dynamic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ClassifierRole : Classifier
        {
        ModelElement[] availableContents { get; }
        Feature[] availableFeature { get; }
        Classifier[] @base { get; }
        Instance[] conformingInstance { get; }
        Message[] message { get; }
        Multiplicity multiplicity { get; }
        }
    }