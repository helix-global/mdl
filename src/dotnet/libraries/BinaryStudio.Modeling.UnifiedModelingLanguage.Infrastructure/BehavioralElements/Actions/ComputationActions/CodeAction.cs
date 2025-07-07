using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CodeAction : PrimitiveAction
        {
        String language { get; }
        String encoding { get; }
        InputPin[] argument { get; }
        OutputPin[] result { get; }
        }
    }
