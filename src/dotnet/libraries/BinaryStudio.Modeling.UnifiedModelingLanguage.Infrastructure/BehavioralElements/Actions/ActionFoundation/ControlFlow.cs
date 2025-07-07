namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ControlFlow : ModelElement
        {
        Action predecessor { get; }
        Action successor { get; }
        }
    }
