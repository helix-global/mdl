namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface WriteVariableAction : VariableAction
        {
        InputPin value { get; }
        }
    }
