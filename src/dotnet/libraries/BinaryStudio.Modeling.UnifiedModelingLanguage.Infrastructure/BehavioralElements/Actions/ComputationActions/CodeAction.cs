using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class CodeAction : PrimitiveAction
        {
        String language { get; }
        String encoding { get; }
        InputPin[] argument { get; }
        OutputPin[] result { get; }
        }
    }
