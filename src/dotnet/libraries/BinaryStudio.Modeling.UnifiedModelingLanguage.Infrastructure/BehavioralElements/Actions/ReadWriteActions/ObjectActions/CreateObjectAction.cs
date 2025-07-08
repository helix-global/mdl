namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CreateObjectAction : PrimitiveAction
        {
        Classifier classifier { get; }
        OutputPin result { get; }
        }
    }
