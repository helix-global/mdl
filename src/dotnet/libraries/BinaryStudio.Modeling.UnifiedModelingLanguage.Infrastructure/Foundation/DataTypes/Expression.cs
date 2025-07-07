using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Expression
        {
        Name language { get; }
        String body { get; }
        Procedure procedure { get; }
        }
    }
