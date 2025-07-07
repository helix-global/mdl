using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    using Integer=Int64;
    public interface MultiplicityRange
        {
        Integer lower { get; }
        UnlimitedInteger upper { get; }
        Multiplicity multiplicity { get; }
        }
    }
