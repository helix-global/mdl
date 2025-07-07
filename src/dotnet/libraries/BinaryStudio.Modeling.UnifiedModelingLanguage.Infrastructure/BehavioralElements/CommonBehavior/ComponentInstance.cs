namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ComponentInstance : Instance
        {
        NodeInstance nodeInstance { get; }
        Instance[] resident { get; }
        }
    }
