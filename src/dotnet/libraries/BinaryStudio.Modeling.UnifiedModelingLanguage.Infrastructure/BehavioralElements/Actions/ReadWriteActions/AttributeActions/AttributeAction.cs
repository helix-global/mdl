namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AttributeAction : PrimitiveAction
        {
        InputPin @object { get; }
        Attribute attribute { get; }
        }
    }
