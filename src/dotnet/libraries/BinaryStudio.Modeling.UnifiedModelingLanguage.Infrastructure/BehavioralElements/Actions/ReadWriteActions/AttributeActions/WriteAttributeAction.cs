namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface WriteAttributeAction : AttributeAction
        {
        InputPin value { get; }
        }
    }
