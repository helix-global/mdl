namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TemplateParameter
        {
        ModelElement defaultElement { get; }
        ModelElement parameter { get; }
        ModelElement template { get; }
        }
    }
