using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class PrimitiveFunction : ModelElement
        {
        String language { get; }
        String encoding { get; }
        ArgumentSpecification[] inputSpec { get; }
        ArgumentSpecification[] outputSpec { get; }
        }
    }
