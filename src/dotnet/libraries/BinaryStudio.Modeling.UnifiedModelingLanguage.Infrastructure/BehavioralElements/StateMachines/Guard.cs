namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Guard : ModelElement
        {
        BooleanExpression expression { get; }
        Transition transition { get; }
        }
    }
