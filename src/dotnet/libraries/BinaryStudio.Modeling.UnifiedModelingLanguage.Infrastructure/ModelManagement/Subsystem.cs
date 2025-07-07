using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Subsystem : Classifier,Package
        {
        Boolean isInstantiable { get; }
        }
    }
