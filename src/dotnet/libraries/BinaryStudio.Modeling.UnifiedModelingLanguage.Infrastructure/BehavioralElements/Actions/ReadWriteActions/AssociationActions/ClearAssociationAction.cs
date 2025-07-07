namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ClearAssociationAction : PrimitiveAction
        {
        Association association { get; }
        InputPin @object { get; }
        }
    }
