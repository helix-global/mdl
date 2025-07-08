using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ApplyFunctionAction : PrimitiveAction
        {
        InputPin[] argument { get; }
        PrimitiveFunction function { get; }
        [Multiplicity("1..*")] OutputPin[] result { get; }
        }
    }
