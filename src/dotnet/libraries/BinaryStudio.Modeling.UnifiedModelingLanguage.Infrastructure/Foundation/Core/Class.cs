using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Class : Classifier
        {
        Boolean isActive { get; }
        }
    }
