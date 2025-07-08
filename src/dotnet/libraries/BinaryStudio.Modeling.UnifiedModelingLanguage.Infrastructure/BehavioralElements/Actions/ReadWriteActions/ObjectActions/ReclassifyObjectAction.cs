using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReclassifyObjectAction : PrimitiveAction
        {
        Boolean isReplaceAll { get; }
        Classifier[] oldClassifier { get; }
        Classifier[] newClassifier { get; }
        InputPin input { get; }
        }
    }
