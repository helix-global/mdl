using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface PrimitiveFunction : ModelElement
        {
        String language { get; }
        String encoding { get; }
        ArgumentSpecification[] inputSpec { get; }
        ArgumentSpecification[] outputSpec { get; }
        }
    }
