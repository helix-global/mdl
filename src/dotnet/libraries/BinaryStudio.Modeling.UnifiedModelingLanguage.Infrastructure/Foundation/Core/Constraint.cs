namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Constraint : ModelElement
        {
        BooleanExpression body { get; }
        ModelElement[] constrainedElement { get; }
        Stereotype constrainedStereotype { get; }
        }
    }
