namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ControlFlow : ModelElement
        {
        Action predecessor { get; }
        Action successor { get; }
        }
    }
