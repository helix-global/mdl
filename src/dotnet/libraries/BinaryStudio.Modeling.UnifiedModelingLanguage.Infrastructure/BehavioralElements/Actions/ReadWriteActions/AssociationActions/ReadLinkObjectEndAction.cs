namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ReadLinkObjectEndAction : PrimitiveAction
        {
        OutputPin result { get; }
        InputPin @object { get; }
        AssociationEnd end { get; }
        }
    }
