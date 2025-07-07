namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadVariableAction : VariableAction
        {
        OutputPin result { get; }
        }
    }
