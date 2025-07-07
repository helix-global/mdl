namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadExtentAction : PrimitiveAction
        {
        OutputPin result { get; }
        Classifier classifier { get; }
        }
    }
