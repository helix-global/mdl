namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AttributeLink : ModelElement
        {
        Attribute attribute { get; }
        Instance instance { get; }
        LinkEnd linkEnd { get; }
        Instance value { get; }
        }
    }
