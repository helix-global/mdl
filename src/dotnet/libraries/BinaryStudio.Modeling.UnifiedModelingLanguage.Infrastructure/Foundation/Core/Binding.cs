using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Binding : Dependency
        {
        [Multiplicity("1..*")] TemplateArgument[] argument { get; }
        }
    }
