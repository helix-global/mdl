namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Pseudostate : StateVertex
        {
        PseudostateKind kind { get; }
        }
    }
