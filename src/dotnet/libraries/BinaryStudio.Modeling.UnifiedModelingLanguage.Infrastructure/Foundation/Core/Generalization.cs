using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Generalization : Relationship
        {
        String discriminator { get; }
        GeneralizableElement child { get; }
        GeneralizableElement parent { get; }
        Classifier powertype { get; }
        }
    }
