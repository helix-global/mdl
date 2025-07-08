namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface VariableAction : PrimitiveAction
        {
        Variable variable { get; }
        }
    }
