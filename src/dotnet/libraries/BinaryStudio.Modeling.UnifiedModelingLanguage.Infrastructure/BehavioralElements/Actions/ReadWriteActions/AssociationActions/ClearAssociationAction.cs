namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class ClearAssociationAction : PrimitiveAction
        {
        Association association { get; }
        InputPin @object { get; }
        }
    }
