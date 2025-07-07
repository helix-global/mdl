namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface TemplateArgument
        {
        Binding binding { get; }
        ModelElement modelElement { get; }
        }
    }
