using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Expression
        {
        String language { get; }
        String body { get; }
        Procedure procedure { get; }
        }
    }
