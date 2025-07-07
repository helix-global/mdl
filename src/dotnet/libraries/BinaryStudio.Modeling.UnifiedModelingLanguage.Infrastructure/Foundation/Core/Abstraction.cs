namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Abstraction : Dependency
        {
        MappingExpression mapping { get; }
        }
    }
