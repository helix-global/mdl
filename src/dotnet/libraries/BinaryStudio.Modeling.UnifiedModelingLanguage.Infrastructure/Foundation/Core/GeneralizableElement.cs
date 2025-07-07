using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface GeneralizableElement : ModelElement
        {
        Boolean isRoot { get; }
        Boolean isLeaf { get; }
        Boolean isAbstract { get; }
        Generalization[] generalization { get; }
        Generalization[] specialization { get; }
        }
    }
