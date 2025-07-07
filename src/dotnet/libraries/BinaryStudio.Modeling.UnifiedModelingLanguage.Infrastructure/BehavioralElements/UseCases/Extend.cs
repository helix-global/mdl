namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Extend : Relationship
        {
        BooleanExpression condition { get; }
        UseCase @base { get; }
        UseCase extension { get; }
        ExtensionPoint[] extensionPoint { get; }
        }
    }
