namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface NodeInstance : Instance
        {
        ComponentInstance[] resident { get; }
        }
    }
