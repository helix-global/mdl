namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ReadLinkObjectQualifierAction : PrimitiveAction
        {
        OutputPin result { get; }
        InputPin @object { get; }
        Attribute qualifier { get; }
        }
    }
