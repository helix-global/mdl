using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadIsClassifiedObjectAction : PrimitiveAction
        {
        Boolean isDirect { get; }
        Classifier classifier { get; }
        InputPin input { get; }
        OutputPin result { get; }
        }
    }
