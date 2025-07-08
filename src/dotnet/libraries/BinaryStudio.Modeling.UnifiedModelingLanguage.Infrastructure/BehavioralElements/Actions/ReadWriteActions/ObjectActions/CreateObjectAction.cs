namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class CreateObjectAction : PrimitiveAction
        {
        Classifier classifier { get; }
        OutputPin result { get; }
        }
    }
