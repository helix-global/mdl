namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LinkEnd : ModelElement
        {
        AssociationEnd associationEnd { get; }
        Instance instance { get; }
        Link link { get; }
        AttributeLink[] qualifierValue { get; }
        }
    }
