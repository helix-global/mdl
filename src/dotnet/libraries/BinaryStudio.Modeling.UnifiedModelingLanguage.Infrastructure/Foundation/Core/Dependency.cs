using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Dependency : Relationship
        {
        [Multiplicity("1..*")] ModelElement[] client { get; }
        [Multiplicity("1..*")] ModelElement[] supplier { get; }
        }
    }
