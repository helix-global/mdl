namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ReadLinkObjectQualifierAction : PrimitiveAction
        {
        OutputPin result { get; }
        InputPin @object { get; }
        Attribute qualifier { get; }
        }
    }
