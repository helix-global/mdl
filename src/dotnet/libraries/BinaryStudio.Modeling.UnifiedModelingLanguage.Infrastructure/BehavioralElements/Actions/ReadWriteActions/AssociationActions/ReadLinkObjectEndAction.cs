namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadLinkObjectEndAction : PrimitiveAction
        {
        OutputPin result { get; }
        InputPin @object { get; }
        AssociationEnd end { get; }
        }
    }
