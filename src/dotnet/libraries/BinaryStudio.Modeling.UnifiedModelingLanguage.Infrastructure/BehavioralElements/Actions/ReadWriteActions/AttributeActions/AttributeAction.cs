namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class AttributeAction : PrimitiveAction
        {
        InputPin @object { get; }
        Attribute attribute { get; }
        }
    }
